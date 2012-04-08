using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Collections;
using MCLawl;

namespace MCDek
{

    public static class Heartbeat
    {
        //static int _timeout = 60 * 1000;

        static string hash;
        public static string serverURL;
        static string staticVars;
        static string players = "";
        static string worlds = "";

        //static BackgroundWorker worker;
        static HttpWebRequest request;
        static Random dekBeatSeed = new Random(Process.GetCurrentProcess().Id);
        static StreamWriter beatlogger;

        static System.Timers.Timer heartbeatTimer = new System.Timers.Timer(500);
        static System.Timers.Timer dekBeatTimer;

        public static void Init()
        {
            if (Server.logbeat)
            {
                if (!File.Exists("heartbeat.log"))
                {
                    File.Create("heartbeat.log").Close();
                }
            }
            dekBeatTimer = new System.Timers.Timer(1000 + dekBeatSeed.Next(0, 2500));
            staticVars = "port=" + Server.port +
                            "&max=" + Server.players +
                            "&name=" + UrlEncode(Server.name) +
                            "&public=" + Server.pub +
                            "&version=" + Server.version;

            Thread backupThread = new Thread(new ThreadStart(delegate
            {
                heartbeatTimer.Elapsed += delegate
                {
                    heartbeatTimer.Interval = 55000;
                    try
                    {
                        Pump(Beat.Minecraft);
                        // Pump(Beat.TChalo);
                    }
                    catch (Exception e) { Server.ErrorLog(e); }
                };
                heartbeatTimer.Start();

                dekBeatTimer.Elapsed += delegate
                {
                    dekBeatTimer.Interval = 300000;
                    try
                    {
                        Pump(Beat.MCDek); ;
                    }
                    catch (Exception e)
                    {
                        Server.ErrorLog(e);
                    }
                };
                dekBeatTimer.Start();
            }));
            backupThread.Start();
        }

        public static bool Pump(Beat type)
        {
            string postVars = staticVars;

            string url = "http://www.minecraft.net/heartbeat.jsp";
            int totalTries = 0;
        retry: try
            {
                int hidden = 0;
                totalTries++;
                // append additional information as needed
                switch (type)
                {
                    case Beat.Minecraft:
                        if (Server.logbeat)
                        {
                            beatlogger = new StreamWriter("heartbeat.log", true);
                        }
                        postVars += "&salt=" + Server.salt;
                        goto default;
                    case Beat.MCDek:
                        if (hash == null)
                        {
                            throw new Exception("Hash not set");
                        }

                        url = "http://www.dekemaserv.com/hbannounce.php";

                        if (Player.number > 0)
                        {
                            players = "";
                            foreach (Player p in Player.players)
                            {
                                if (p.hidden)
                                {
                                    hidden++;
                                    continue;
                                }
                                players += p.name + " (" + p.group.name + ")" + ",";
                            }
                            if (Player.number - hidden > 0)
                                postVars += "&players=" + players.Substring(0, players.Length - 1);
                        }

                        worlds = "";
                        foreach (Level l in Server.levels)
                        {
                            worlds += l.name + ",";
                            postVars += "&worlds=" + worlds.Substring(0, worlds.Length - 1);
                        }

                        postVars += "&motd=" + UrlEncode(Server.motd) +
                                "&lvlcount=" + (byte)Server.levels.Count +
                                "&dekversion=" + Server.Version.Replace(".0", "") +
                                "&hash=" + hash;

                        goto default;
                    case Beat.TChalo:
                        if (hash == null)
                            throw new Exception("Hash not set");

                        url = "http://minecraft.tchalo.com/announce.php";

                        if (Player.number > 0)
                        {
                            players = "";
                            foreach (Player p in Player.players)
                            {
                                if (p.hidden)
                                {
                                    hidden++;
                                    continue;
                                }
                                players += p.name + ",";
                            }
                            if (Player.number - hidden > 0)
                                postVars += "&players=" + players.Substring(0, players.Length - 1);
                        }

                        worlds = "";
                        foreach (Level l in Server.levels)
                        {
                            worlds += l.name + ",";
                            postVars += "&worlds=" + worlds.Substring(0, worlds.Length - 1);
                        }

                        postVars += "&motd=" + UrlEncode(Server.motd) +
                                "&hash=" + hash +
                                "&data=" + Server.Version + "," + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() +
                                "&server=MCDek" +
                                "&details=Running MCDek version " + Server.Version;

                        goto default;
                    default:
                        postVars += "&users=" + (Player.number - hidden);
                        break;

                }

                request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                byte[] formData = Encoding.ASCII.GetBytes(postVars);
                request.ContentLength = formData.Length;
                request.Timeout = 15000;

            retryStream: try
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(formData, 0, formData.Length);
                        if (type == Beat.Minecraft && Server.logbeat)
                        {
                            beatlogger.WriteLine("Request sent at " + DateTime.Now.ToString());
                        }
                        requestStream.Close();
                    }
                }
                catch (WebException e)
                {
                    //Server.ErrorLog(e);
                    if (e.Status == WebExceptionStatus.Timeout)
                    {
                        if (type == Beat.Minecraft && Server.logbeat)
                        {
                            beatlogger.WriteLine("Timeout detected at " + DateTime.Now.ToString());
                        }
                        goto retryStream;
                        //throw new WebException("Failed during request.GetRequestStream()", e.InnerException, e.Status, e.Response);
                    }
                    else if (type == Beat.Minecraft && Server.logbeat)
                    {
                        beatlogger.WriteLine("Non-timeout exception detected: " + e.Message);
                        beatlogger.Write("Stack Trace: " + e.StackTrace);
                    }
                }

                //if (hash == null)
                //{
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
                    {
                        if (hash == null)
                        {
                            string line = responseReader.ReadLine();
                            if (type == Beat.Minecraft && Server.logbeat)
                            {
                                beatlogger.WriteLine("Response received at " + DateTime.Now.ToString());
                                beatlogger.WriteLine("Received: " + line);
                            }
                            hash = line.Substring(line.LastIndexOf('=') + 1);
                            serverURL = line;

                            //serverURL = "http://" + serverURL.Substring(serverURL.IndexOf('.') + 1);
                            Server.s.UpdateUrl(serverURL);
                            File.WriteAllText("text/externalurl.txt", serverURL);
                            Server.s.Log("URL found: " + serverURL);
                        }
                        else if (type == Beat.Minecraft && Server.logbeat)
                        {
                            beatlogger.WriteLine("Response received at " + DateTime.Now.ToString());
                        }
                    }
                }
                //}
                //Server.s.Log(string.Format("Heartbeat: {0}", type));
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.Timeout)
                {
                    if (type == Beat.Minecraft && Server.logbeat)
                    {
                        beatlogger.WriteLine("Timeout detected at " + DateTime.Now.ToString());
                    }
                    Pump(type);
                }
            }
            catch
            {
                if (type == Beat.Minecraft && Server.logbeat)
                {
                    beatlogger.WriteLine("Heartbeat failure #" + totalTries + " at " + DateTime.Now.ToString());
                }
                if (totalTries < 3) goto retry;
                if (type == Beat.Minecraft && Server.logbeat)
                {
                    beatlogger.WriteLine("Failed three times.  Stopping.");
                    beatlogger.Close();
                }
                return false;
            }
            finally
            {
                request.Abort();
            }
            if (beatlogger != null)
            {
                beatlogger.Close();
            }
            return true;
        }

        public static string UrlEncode(string input)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= '0' && input[i] <= '9') ||
                    (input[i] >= 'a' && input[i] <= 'z') ||
                    (input[i] >= 'A' && input[i] <= 'Z') ||
                    input[i] == '-' || input[i] == '_' || input[i] == '.' || input[i] == '~')
                {
                    output.Append(input[i]);
                }
                else if (Array.IndexOf<char>(reservedChars, input[i]) != -1)
                {
                    output.Append('%').Append(((int)input[i]).ToString("X"));
                }
            }
            return output.ToString();
        }

        /* public static Int32 MACToInt()
        {
            var nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            if (Server.mono)
            {
                foreach (var nic in nics)
                {
                    if (nic.Name != "l0")
                    {
                        nics[0] = nic;
                        break;
                    }
                }
            }
            string MAC = nics[0].GetPhysicalAddress().ToString();
            Regex regex = new Regex(@"[^0-9a-f]");
            MAC = regex.Replace(MAC, "");
            Int32 seed = 0;
     retry: try
            {
                seed = Convert.ToInt32(MAC);
            }
            catch (OverflowException)
            {
                MAC = MAC.Remove(MAC.Length - 1);
                goto retry;
            }
            catch(FormatException)
            {
                seed = new Random().Next();
            }
            return seed;
        } */

        public static char[] reservedChars = { ' ', '!', '*', '\'', '(', ')', ';', ':', '@', '&',
                                                 '=', '+', '$', ',', '/', '?', '%', '#', '[', ']' };
    }

    public enum Beat { Minecraft, TChalo, MCDek }
}
