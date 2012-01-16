/*
	Copyright 2010 MCSharp team (Modified for use with MCZall/MCLawl) Licensed under the
	Educational Community License, Version 2.0 (the "License"); you may
	not use this file except in compliance with the License. You may
	obtain a copy of the License at
	
	http://www.osedu.org/licenses/ECL-2.0
	
	Unless required by applicable law or agreed to in writing,
	software distributed under the License is distributed on an "AS IS"
	BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
	or implied. See the License for the specific language governing
	permissions and limitations under the License.
*/
using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Data;

//using MySql.Data.MySqlClient;
//using MySql.Data.Types;

using MonoTorrent.Client;

namespace MCLawl
{
    public class Server
    {
        public delegate void LogHandler(string message);
        public delegate void HeartBeatHandler();
        public delegate void MessageEventHandler(string message);
        public delegate void PlayerListHandler(List<Player> playerList);
        public delegate void VoidHandler();

        public event LogHandler OnLog;
        public event LogHandler OnSystem;
        public event LogHandler OnCommand;
        public event LogHandler OnError;
        public event HeartBeatHandler HeartBeatFail;
        public event MessageEventHandler OnURLChange;
        public event PlayerListHandler OnPlayerListChange;
        public event VoidHandler OnSettingsUpdate;

        public static Thread locationChecker;

        public static Thread blockThread;
        public static List<MySql.Data.MySqlClient.MySqlCommand> mySQLCommands = new List<MySql.Data.MySqlClient.MySqlCommand>();

        public static int speedPhysics = 250;

        public static string Version { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }

        public static Socket listen;
        public static System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();
        public static System.Timers.Timer updateTimer = new System.Timers.Timer(100);
        //static System.Timers.Timer heartbeatTimer = new System.Timers.Timer(60000);     //Every 45 seconds
        static System.Timers.Timer messageTimer = new System.Timers.Timer(60000 * 5);   //Every 5 mins
        public static System.Timers.Timer cloneTimer = new System.Timers.Timer(5000);

        //public static Thread physThread;
        //public static bool physPause;
        //public static DateTime physResume = DateTime.Now;
        //public static System.Timers.Timer physTimer = new System.Timers.Timer(1000);
        // static Thread botsThread;

        //CTF STUFF
        public static List<CTFGame> CTFGames = new List<CTFGame>();

        public static PlayerList bannedIP;
        public static PlayerList whiteList;
        public static PlayerList ircControllers;
        public static List<string> devs = new List<string>(new string[] { "lawlcat", "valek", "zallist" });

        public static List<TempBan> tempBans = new List<TempBan>();
        public struct TempBan { public string name; public DateTime allowedJoin; }

        public static MapGenerator MapGen;

        public static PerformanceCounter PCCounter = null;
        public static PerformanceCounter ProcessCounter = null;

        public static Level mainLevel;
        public static List<Level> levels;
        //public static List<levelID> allLevels = new List<levelID>();
        public struct levelID { public int ID; public string name; }

        public static List<string> afkset = new List<string>();
        public static List<string> afkmessages = new List<string>();
        public static List<string> messages = new List<string>();

        public static DateTime timeOnline;

        //auto updater stuff
        public static bool autoupdate;
        public static bool autonotify;
        public static string restartcountdown = "";
        public static string selectedrevision = "";
        public static bool autorestart;
        public static DateTime restarttime;

        public static bool chatmod = false;


        //Settings
        #region Server Settings
        public const byte version = 7;
        public static string salt = "";

        public static string name = "[MCLawl] Default";
        public static string motd = "Welcome!";
        public static byte players = 12;
        public static byte maps = 5;
        public static int port = 25565;
        public static bool pub = true;
        public static bool verify = true;
        public static bool worldChat = true;
        public static bool guestGoto = false;

        public static string ZallState = "Alive";

        //public static string[] userMOTD;

        public static string level = "main";
        public static string errlog = "error.log";

        public static bool console = false;
        public static bool reportBack = true;

        public static bool irc = false;
        public static int ircPort = 6667;
        public static string ircNick = "MCZall_Minecraft_Bot";
        public static string ircServer = "irc.esper.net";
        public static string ircChannel = "#changethis";
        public static string ircOpChannel = "#changethistoo";
        public static bool ircIdentify = false;
        public static string ircPassword = "";

        public static bool restartOnError = true;

        public static bool antiTunnel = true;
        public static byte maxDepth = 4;
        public static int Overload = 1500;
        public static int rpLimit = 500;
        public static int rpNormLimit = 10000;

        public static int backupInterval = 300;
        public static int blockInterval = 60;
        public static string backupLocation = Application.StartupPath + "/levels/backups";

        public static bool physicsRestart = true;
        public static bool deathcount = true;
        public static bool AutoLoad = false;
        public static int physUndo = 60000;
        public static int totalUndo = 200;
        public static bool rankSuper = true;
        public static bool oldHelp = false;
        public static bool parseSmiley = true;
        public static bool useWhitelist = false;
        public static bool forceCuboid = false;
        public static bool repeatMessage = false;

        public static bool checkUpdates = true;

        public static bool useMySQL = true;
        public static string MySQLHost = "127.0.0.1";
        public static string MySQLPort = "3306";
        public static string MySQLUsername = "root";
        public static string MySQLPassword = "password";
        public static string MySQLDatabaseName = "MCZallDB";
        public static bool MySQLPooling = true;

        public static string DefaultColor = "&e";
        public static string IRCColour = "&5";

        public static int afkminutes = 10;
        public static int afkkick = 45;

        public static string defaultRank = "guest";

        public static bool dollardollardollar = true;

        public static bool cheapMessage = true;
        public static string cheapMessageGiven = " is now being cheap and being immortal";
        public static bool customBan = false;
        public static string customBanMessage = "You're banned!";
        public static bool customShutdown = false;
        public static string customShutdownMessage = "Server shutdown. Rejoin in 10 seconds.";
        public static string moneys = "moneys";
        public static LevelPermission opchatperm = LevelPermission.Operator;
        public static bool logbeat = false;

        public static bool mono = false;

        public static bool flipHead = false;

        public static bool shuttingDown = false;
        #endregion

        public static MainLoop ml;
        public static Server s;
        public Server()
        {
            ml = new MainLoop("server");
            Server.s = this;
        }
        public void Start()
        {
            shuttingDown = false;
            Log("Starting Server");

            if (!Directory.Exists("properties")) Directory.CreateDirectory("properties");
            if (!Directory.Exists("bots")) Directory.CreateDirectory("bots");
            if (!Directory.Exists("text")) Directory.CreateDirectory("text");

            if (!Directory.Exists("extra")) Directory.CreateDirectory("extra");
            if (!Directory.Exists("extra/undo")) Directory.CreateDirectory("extra/undo");
            if (!Directory.Exists("extra/undoPrevious")) Directory.CreateDirectory("extra/undoPrevious");
            if (!Directory.Exists("extra/copy/")) { Directory.CreateDirectory("extra/copy/"); }
            if (!Directory.Exists("extra/copyBackup/")) { Directory.CreateDirectory("extra/copyBackup/"); }

            try
            {
                if (File.Exists("server.properties")) File.Move("server.properties", "properties/server.properties");
                if (File.Exists("rules.txt")) File.Move("rules.txt", "text/rules.txt");
                if (File.Exists("welcome.txt")) File.Move("welcome.txt", "text/welcome.txt");
                if (File.Exists("messages.txt")) File.Move("messages.txt", "text/messages.txt");
                if (File.Exists("externalurl.txt")) File.Move("externalurl.txt", "text/externalurl.txt");
                if (File.Exists("autoload.txt")) File.Move("autoload.txt", "text/autoload.txt");
                if (File.Exists("IRC_Controllers.txt")) File.Move("IRC_Controllers.txt", "ranks/IRC_Controllers.txt");
                if (Server.useWhitelist) if (File.Exists("whitelist.txt")) File.Move("whitelist.txt", "ranks/whitelist.txt");
            } catch { }

            Properties.Load("properties/server.properties");
            Updater.Load("properties/update.properties");

            Group.InitAll();
            Command.InitAll();
            GrpCommands.fillRanks();
            Block.SetBlocks();
            Awards.Load();

            if (File.Exists("text/emotelist.txt"))
            {
                foreach (string s in File.ReadAllLines("text/emotelist.txt"))
                {
                    Player.emoteList.Add(s);
                }
            }
            else
            {
                File.Create("text/emotelist.txt");
            }

            timeOnline = DateTime.Now;

            try
            {
                MySQL.executeQuery("CREATE DATABASE if not exists `" + MySQLDatabaseName + "`", true);
            }
            catch (Exception e)
            {
                Server.s.Log("MySQL settings have not been set! Please reference the MySQL_Setup.txt file on setting up MySQL!");
                Server.ErrorLog(e);
                //process.Kill();
                return;
            }

            MySQL.executeQuery("CREATE TABLE if not exists Players (ID MEDIUMINT not null auto_increment, Name VARCHAR(20), IP CHAR(15), FirstLogin DATETIME, LastLogin DATETIME, totalLogin MEDIUMINT, Title CHAR(20), TotalDeaths SMALLINT, Money MEDIUMINT UNSIGNED, totalBlocks BIGINT, totalKicked MEDIUMINT, color VARCHAR(6), title_color VARCHAR(6), PRIMARY KEY (ID));");

            // Check if the color column exists.
            DataTable colorExists = MySQL.fillData("SHOW COLUMNS FROM Players WHERE `Field`='color'");

            if (colorExists.Rows.Count == 0)
            {
                MySQL.executeQuery("ALTER TABLE Players ADD COLUMN color VARCHAR(6) AFTER totalKicked");
            }
            colorExists.Dispose();

            // Check if the title color column exists.
            DataTable tcolorExists = MySQL.fillData("SHOW COLUMNS FROM Players WHERE `Field`='title_color'");
            
            if (tcolorExists.Rows.Count == 0)
            {
                MySQL.executeQuery("ALTER TABLE Players ADD COLUMN title_color VARCHAR(6) AFTER color");
            }
            tcolorExists.Dispose();

            if (levels != null)
                foreach (Level l in levels) { l.Unload(); }
            ml.Queue(delegate
            {
                try
                {
                    levels = new List<Level>(Server.maps);
                    MapGen = new MapGenerator();

                    Random random = new Random();

                    if (File.Exists("levels/" + Server.level + ".lvl"))
                    {
                        mainLevel = Level.Load(Server.level);
                        mainLevel.unload = false;
                        if (mainLevel == null)
                        {
                            if (File.Exists("levels/" + Server.level + ".lvl.backup"))
                            {
                                Log("Attempting to load backup.");
                                File.Copy("levels/" + Server.level + ".lvl.backup", "levels/" + Server.level + ".lvl", true);
                                mainLevel = Level.Load(Server.level);
                                if (mainLevel == null)
                                {
                                    Log("BACKUP FAILED!");
                                    Console.ReadLine(); return;
                                }
                            }
                            else
                            {
                                Log("mainlevel not found");
                                mainLevel = new Level(Server.level, 128, 64, 128, "flat");

                                mainLevel.permissionvisit = LevelPermission.Guest;
                                mainLevel.permissionbuild = LevelPermission.Guest;
                                mainLevel.Save();
                            }
                        }
                    }
                    else
                    {
                        Log("mainlevel not found");
                        mainLevel = new Level(Server.level, 128, 64, 128, "flat");

                        mainLevel.permissionvisit = LevelPermission.Guest;
                        mainLevel.permissionbuild = LevelPermission.Guest;
                        mainLevel.Save();
                    }
                    addLevel(mainLevel);
                    mainLevel.physThread.Start();
                } catch (Exception e) { Server.ErrorLog(e); }
            });

            ml.Queue(delegate
            {
                bannedIP = PlayerList.Load("banned-ip.txt", null);
                ircControllers = PlayerList.Load("IRC_Controllers.txt", null);

                foreach (Group grp in Group.GroupList)
                    grp.playerList = PlayerList.Load(grp.fileName, grp);
                if (Server.useWhitelist)
                    whiteList = PlayerList.Load("whitelist.txt", null);
            });

            ml.Queue(delegate
            {
                if (File.Exists("text/autoload.txt"))
                {
                    try
                    {
                        string[] lines = File.ReadAllLines("text/autoload.txt");
                        foreach (string line in lines)
                        {
                            //int temp = 0;
                            string _line = line.Trim();
                            try
                            {
                                if (_line == "") { continue; }
                                if (_line[0] == '#') { continue; }
                                int index = _line.IndexOf("=");

                                string key = _line.Split('=')[0].Trim();
                                string value;
                                try
                                {
                                    value = _line.Split('=')[1].Trim();
                                }
                                catch
                                {
                                    value = "0";
                                }

                                if (!key.Equals(mainLevel.name))
                                {
                                    Command.all.Find("load").Use(null, key + " " + value);
                                    Level l = Level.FindExact(key);
                                }
                                else
                                {
                                    try
                                    {
                                        int temp = int.Parse(value);
                                        if (temp >= 0 && temp <= 3)
                                        {
                                            mainLevel.setPhysics(temp);
                                        }
                                    }
                                    catch
                                    {
                                        Server.s.Log("Physics variable invalid");
                                    }
                                }


                            }
                            catch
                            {
                                Server.s.Log(_line + " failed.");
                            }
                        }
                    }
                    catch
                    {
                        Server.s.Log("autoload.txt error");
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                else
                {
                    Log("autoload.txt does not exist");
                }
            });

            ml.Queue(delegate
            {
                Log("Creating listening socket on port " + Server.port + "... ");
                if (Setup())
                {
                    s.Log("Done.");
                }
                else
                {
                    s.Log("Could not create socket connection.  Shutting down.");
                    return;
                }
            });

            ml.Queue(delegate
            {
                updateTimer.Elapsed += delegate
                {
                    Player.GlobalUpdate();
                    PlayerBot.GlobalUpdatePosition();
                };

                updateTimer.Start();
            });


            // Heartbeat code here:

            ml.Queue(delegate
            {
                try
                {
                    Heartbeat.Init();
                }
                catch (Exception e)
                {
                    Server.ErrorLog(e);
                }
            });

            // END Heartbeat code

            /*
            Thread processThread = new Thread(new ThreadStart(delegate
            {
                try
                {
                    PCCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                    ProcessCounter = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);
                    PCCounter.BeginInit();
                    ProcessCounter.BeginInit();
                    PCCounter.NextValue();
                    ProcessCounter.NextValue();
                }
                catch { }
            }));
            processThread.Start();
            */

            ml.Queue(delegate
            {
                messageTimer.Elapsed += delegate
                {
                    RandomMessage();
                };
                messageTimer.Start();

                process = System.Diagnostics.Process.GetCurrentProcess();

                if (File.Exists("text/messages.txt"))
                {
                    StreamReader r = File.OpenText("text/messages.txt");
                    while (!r.EndOfStream)
                        messages.Add(r.ReadLine());
                    r.Dispose();
                }
                else File.Create("text/messages.txt").Close();

                if (Server.irc)
                {
                    new IRCBot();
                }
            

                //      string CheckName = "FROSTEDBUTTS";

                //       if (Server.name.IndexOf(CheckName.ToLower())!= -1){ Server.s.Log("FROSTEDBUTTS DETECTED");}
                new AutoSaver(Server.backupInterval);     //2 and a half mins

                blockThread = new Thread(new ThreadStart(delegate
                {
                    while (true)
                    {
                        Thread.Sleep(blockInterval * 1000);
                        foreach (Level l in levels)
                        {
                            l.saveChanges();
                        }
                    }
                }));
                blockThread.Start();

                locationChecker = new Thread(new ThreadStart(delegate
                {
                    while (true)
                    {
                        Thread.Sleep(3);
                        for (int i = 0; i < Player.players.Count; i++)
                        {
                            try
                            {
                                Player p = Player.players[i];

                                if (p.frozen)
                                {
                                    unchecked { p.SendPos((byte)-1, p.pos[0], p.pos[1], p.pos[2], p.rot[0], p.rot[1]); } continue;
                                }
                                else if (p.following != "")
                                {
                                    Player who = Player.Find(p.following);
                                    if (who == null || who.level != p.level) 
                                    { 
                                        p.following = "";
                                        if (!p.canBuild)
                                        {
                                            p.canBuild = true;
                                        }
                                        if (who != null && who.possess == p.name)
                                        {
                                            who.possess = "";
                                        }
                                        continue; 
                                    }
                                    if (p.canBuild)
                                    {
                                        unchecked { p.SendPos((byte)-1, who.pos[0], (ushort)(who.pos[1] - 16), who.pos[2], who.rot[0], who.rot[1]); }
                                    }
                                    else
                                    {
                                        unchecked { p.SendPos((byte)-1, who.pos[0], who.pos[1], who.pos[2], who.rot[0], who.rot[1]); }
                                    }
                                } else if (p.possess != "") {
                                    Player who = Player.Find(p.possess);
                                    if (who == null || who.level != p.level)
                                        p.possess = "";
                                }

                                ushort x = (ushort)(p.pos[0] / 32);
                                ushort y = (ushort)(p.pos[1] / 32);
                                ushort z = (ushort)(p.pos[2] / 32);

                                if (p.level.Death) 
                                    p.RealDeath(x, y, z);
                                p.CheckBlock(x, y, z);

                                p.oldBlock = (ushort)(x + y + z);
                            } catch (Exception e) { Server.ErrorLog(e); }
                        }
                    }
                }));

                locationChecker.Start();

                Log("Finished setting up server");
            });
        }
        
        public static bool Setup()
        {
            try
            {
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, Server.port);
                listen = new Socket(endpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listen.Bind(endpoint);
                listen.Listen((int)SocketOptionName.MaxConnections);

                listen.BeginAccept(new AsyncCallback(Accept), null);
                return true;
            }
            catch (SocketException e) { ErrorLog(e); return false; }
            catch (Exception e) { ErrorLog(e); return false; }
        }

        static void Accept(IAsyncResult result)
        {
            if (shuttingDown == false)
            {
                // found information: http://www.codeguru.com/csharp/csharp/cs_network/sockets/article.php/c7695
                // -Descention
                Player p = null;
                try
                {
                    p = new Player(listen.EndAccept(result));
                    listen.BeginAccept(new AsyncCallback(Accept), null);
                }
                catch (SocketException e)
                {
                    if (p != null)
                        p.Disconnect();
                }
                catch (Exception e)
                {
                    ErrorLog(e);
                    if (p != null)
                        p.Disconnect();
                }
            }
        }

        public static void Exit()
        {
            List<string> players = new List<string>();
            foreach (Player p in Player.players) { p.save(); players.Add(p.name); }
            foreach (string p in players)
            {
                if (!Server.customShutdown)
                {
                    Player.Find(p).Kick("Server shutdown. Rejoin in 10 seconds.");
                }
                else
                {
                    Player.Find(p).Kick(Server.customShutdownMessage);
                }
            }

            //Player.players.ForEach(delegate(Player p) { p.Kick("Server shutdown. Rejoin in 10 seconds."); });
            Player.connections.ForEach(
            delegate(Player p)
            {
                if (!Server.customShutdown)
                {
                    p.Kick("Server shutdown. Rejoin in 10 seconds.");
                }
                else
                {
                    p.Kick(Server.customShutdownMessage);
                }
            }
            );
            shuttingDown = true;
            if (listen != null)
            {
                listen.Close();
            }
        }

        public static void addLevel(Level level)
        {
            levels.Add(level);
        }

        public void PlayerListUpdate()
        {
            if (Server.s.OnPlayerListChange != null) Server.s.OnPlayerListChange(Player.players);
        }

        public void FailBeat()
        {
            if (HeartBeatFail != null) HeartBeatFail();
        }

        public void UpdateUrl(string url)
        {
            if (OnURLChange != null) OnURLChange(url);
        }

        public void Log(string message, bool systemMsg = false)
        {
            if (OnLog != null)
            {
                if (!systemMsg)
                {
                    OnLog(DateTime.Now.ToString("(HH:mm:ss) ") + message);
                }
                else
                {
                    OnSystem(DateTime.Now.ToString("(HH:mm:ss) ") + message);
                }
            }

            Logger.Write(DateTime.Now.ToString("(HH:mm:ss) ") + message + Environment.NewLine);
        }

        public void ErrorCase(string message)
        {
            if (OnError != null)
                OnError(message);
        }

        public void CommandUsed(string message)
        {
            if (OnCommand != null) OnCommand(DateTime.Now.ToString("(HH:mm:ss) ") + message);
            Logger.Write(DateTime.Now.ToString("(HH:mm:ss) ") + message + Environment.NewLine);
        }

        public static void ErrorLog(Exception ex)
        {
            Logger.WriteError(ex);
            try
            {
                s.Log("!!!Error! See " + Logger.ErrorLogPath + " for more information.");
            } catch { }
        }

        public static void RandomMessage()
        {
            if (Player.number != 0 && messages.Count > 0)
                Player.GlobalMessage(messages[new Random().Next(0, messages.Count)]);
        }

        internal void SettingsUpdate()
        {
            if (OnSettingsUpdate != null) OnSettingsUpdate();
        }

        public static string FindColor(string Username)
        {
            foreach (Group grp in Group.GroupList)
            {
                if (grp.playerList.Contains(Username)) return grp.color;
            }
            return Group.standard.color;
        }
    }
}