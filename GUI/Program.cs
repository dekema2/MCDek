using System;
using System.Windows.Forms;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net;
using MCDek;
using MCLawl;
using System.Reflection;

namespace MCDek_.Gui
{
    public static class Program
    {
        public static bool usingConsole = false;

        [DllImport("kernel32")]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private static string CurrentVersionFile = "http://www.dekemaserv.com";
        public static void GlobalExHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MCDek.Server.ErrorLog(ex);
            Thread.Sleep(500);

            if (!MCDek.Server.restartOnError)
                Program.restartMe();
            else
                Program.restartMe(false);
        }

        public static void ThreadExHandler(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MCDek.Server.ErrorLog(ex);
            Thread.Sleep(500);

            if (!MCDek.Server.restartOnError)
                Program.restartMe();
            else
                Program.restartMe(false);
        }

        public static void Main(string[] args)
        {
            if (Process.GetProcessesByName("MCDek").Length != 1)
            {
                foreach (Process pr in Process.GetProcessesByName("MCDek"))
                {
                    if (pr.MainModule.BaseAddress == Process.GetCurrentProcess().MainModule.BaseAddress)
                        if (pr.Id != Process.GetCurrentProcess().Id)
                            pr.Kill();
                }
            }

            PidgeonLogger.Init();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.GlobalExHandler);
            Application.ThreadException += new ThreadExceptionEventHandler(Program.ThreadExHandler);
            bool skip = false;
        remake:
            try
            {
                if (!File.Exists("Viewmode.cfg") || skip)
                {
                    StreamWriter SW = new StreamWriter(File.Create("Viewmode.cfg"));
                    SW.WriteLine("#This file controls how the console window is shown to the MCDekServer host");
                    SW.WriteLine("#cli:             True or False (Determines whether a CLI interface is used) (Set True if on Mono)");
                    SW.WriteLine("#high-quality:    True or false (Determines whether the GUI interface uses higher quality objects)");
                    SW.WriteLine();
                    SW.WriteLine("cli = false");
                    SW.WriteLine("high-quality = true");
                    SW.Flush();
                    SW.Close();
                    SW.Dispose();
                }

                if (File.ReadAllText("Viewmode.cfg") == "") { skip = true; goto remake; }

                string[] foundView = File.ReadAllLines("Viewmode.cfg");
                if (foundView[0][0] != '#') { skip = true; goto remake; }

                if (foundView[4].Split(' ')[2].ToLower() == "true")
                {
                    MCDek.Server s = new MCDek.Server();
                    s.OnLog += Console.WriteLine;
                    s.OnCommand += Console.WriteLine;
                    s.OnSystem += Console.WriteLine;
                    s.Start();

                    Console.Title = MCDek.Server.name + " MCDek Version: " + MCDek.Server.Version;
                    usingConsole = true;
                    handleComm(Console.ReadLine());

                    //Application.Run();
                }
                else
                {

                    IntPtr hConsole = GetConsoleWindow();
                    if (IntPtr.Zero != hConsole)
                    {
                        ShowWindow(hConsole, 0);
                    }
                    UpdateCheck(true);
                    if (foundView[5].Split(' ')[2].ToLower() == "true")
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                    }

                    updateTimer.Elapsed += delegate { UpdateCheck(); }; updateTimer.Start();

                    Application.Run(new MCDek.Gui.Window());
                }
            }
            catch (Exception e) { MCDek.Server.ErrorLog(e); return; }
        }

        public static void handleComm(string s)
        {
            string sentCmd = "", sentMsg = "";

            if (s.IndexOf(' ') != -1)
            {
                sentCmd = s.Split(' ')[0];
                sentMsg = s.Substring(s.IndexOf(' ') + 1);
            }
            else if (s != "")
            {
                sentCmd = s;
            }
            else
            {
                goto talk;
            }

            try
            {
                Command cmd = Command.all.Find(sentCmd);
                if (cmd != null)
                {
                    cmd.Use(null, sentMsg);
                    Console.WriteLine("CONSOLE: USED /" + sentCmd + " " + sentMsg);
                    handleComm(Console.ReadLine());
                    return;
                }
            }
            catch (Exception e)
            {
                MCDek.Server.ErrorLog(e);
                Console.WriteLine("CONSOLE: Failed command.");
                handleComm(Console.ReadLine());
                return;
            }

        talk: handleComm("say " + MCLawl.Group.findPerm(LevelPermission.Admin).color + "Console: &f" + s);
            handleComm(Console.ReadLine());
        }

        public static bool CurrentUpdate = false;
        static bool msgOpen = false;
        public static System.Timers.Timer updateTimer = new System.Timers.Timer(120 * 60 * 1000);

        public static void UpdateCheck(bool wait = false, Player p = null)
        {

            CurrentUpdate = true;
            Thread updateThread = new Thread(new ThreadStart(delegate
            {
                WebClient Client = new WebClient();

                if (wait) { if (!MCDek.Server.checkUpdates) return; Thread.Sleep(10000); }
                try
                {
                    if (Client.DownloadString("http://www.dekemaserv.com") != Server.Version) /*303i this is where the MCDekServer version goes. Once they release JDownloads I think we can host files from the site.*/
                    {
                        if (MCDek.Server.autoupdate == true || p != null)
                        {
                            if (MCDek.Server.autonotify == true || p != null)
                            {
                                if (p != null) MCDek.Server.restartcountdown = "20";
                                Player.GlobalMessage("Update found. Prepare for restart in &f" + MCDek.Server.restartcountdown + MCDek.Server.DefaultColor + " seconds.");
                                MCDek.Server.s.Log("Update found. Prepare for restart in " + MCDek.Server.restartcountdown + " seconds.");
                                double nxtTime = Convert.ToDouble(MCDek.Server.restartcountdown);
                                DateTime nextupdate = DateTime.Now.AddMinutes(nxtTime);
                                int timeLeft = Convert.ToInt32(MCDek.Server.restartcountdown);
                                System.Timers.Timer countDown = new System.Timers.Timer();
                                countDown.Interval = 1000;
                                countDown.Start();
                                countDown.Elapsed += delegate
                                {
                                    if (MCDek.Server.autoupdate == true || p != null)
                                    {
                                        Player.GlobalMessage("Updating in &f" + timeLeft + MCDek.Server.DefaultColor + " seconds.");
                                        MCDek.Server.s.Log("Updating in " + timeLeft + " seconds.");
                                        timeLeft = timeLeft - 1;
                                        if (timeLeft < 0)
                                        {
                                            Player.GlobalMessage("---UPDATING MCDekServer---");
                                            MCDek.Server.s.Log("---UPDATING MCDekServer---");
                                            countDown.Stop();
                                            countDown.Dispose();
                                            PerformUpdate(false);
                                        }
                                    }
                                    else
                                    {
                                        Player.GlobalMessage("Stopping auto restart.");
                                        MCDek.Server.s.Log("Stopping auto restart.");
                                        countDown.Stop();
                                        countDown.Dispose();
                                    }
                                };
                            }
                            else
                            {
                                PerformUpdate(false);
                            }

                        }
                        else
                        {
                            if (!msgOpen && !usingConsole)
                            {
                                msgOpen = true;
                                if (MessageBox.Show("New version found. Would you like to update?", "Update?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    PerformUpdate(false);
                                }
                                msgOpen = false;
                            }
                            else
                            {
                                ConsoleColor prevColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("An update was found!");
                                Console.WriteLine("Update using the file at www.dekemaserv.com and placing it over the top of your current MCDek_.dll!");
                                Console.ForegroundColor = prevColor;
                            }
                        }
                    }
                    else
                    {
                        Player.SendMessage(p, "No update found!");
                    }
                }
                catch { MCDek.Server.s.Log("No web MCDekServer found to update on."); }
                Client.Dispose();
                CurrentUpdate = false;
            })); updateThread.Start();
        }

        public static void PerformUpdate(bool oldrevision)
        {
            try
            {
                StreamWriter SW;
                if (!MCDek.Server.mono)
                {
                    if (!File.Exists("Update.bat"))
                        SW = new StreamWriter(File.Create("Update.bat"));
                    else
                    {
                        if (File.ReadAllLines("Update.bat")[0] != "::Version 3")
                        {
                            SW = new StreamWriter(File.Create("Update.bat"));
                        }
                        else
                        {
                            SW = new StreamWriter(File.Create("Update_generated.bat"));
                        }
                    }
                    SW.WriteLine("::Version 3");
                    SW.WriteLine("TASKKILL /pid %2 /F");
                    SW.WriteLine("if exist MCDek_.dll.backup (erase MCDek_.dll.backup)");
                    SW.WriteLine("if exist MCDek_.dll (rename MCDek_.dll MCDek_.dll.backup)");
                    SW.WriteLine("if exist MCDek.new (rename MCDek.new MCDek_.dll)");
                    SW.WriteLine("start MCDek.exe");
                }
                else
                {
                    if (!File.Exists("Update.sh"))
                        SW = new StreamWriter(File.Create("Update.sh"));
                    else
                    {
                        if (File.ReadAllLines("Update.sh")[0] != "#Version 2")
                        {
                            SW = new StreamWriter(File.Create("Update.sh"));
                        }
                        else
                        {
                            SW = new StreamWriter(File.Create("Update_generated.sh"));
                        }
                    }
                    SW.WriteLine("#Version 2");
                    SW.WriteLine("#!/bin/bash");
                    SW.WriteLine("kill $2");
                    SW.WriteLine("rm MCDek_.dll.backup");
                    SW.WriteLine("mv MCDek_.dll MCDek.dll_.backup");
                    SW.WriteLine("wget http://www.dekemaserv.com");
                    SW.WriteLine("mono MCDek.exe");
                }

                SW.Flush(); SW.Close(); SW.Dispose();
                string filelocation = "";
                string verscheck = "";
                Process proc = Process.GetCurrentProcess();
                string assemblyname = proc.ProcessName + ".exe";
                if (!oldrevision)
                {
                    WebClient client = new WebClient();
                    MCDek.Server.selectedrevision = client.DownloadString("http://www.dekemaserv.com/ChangeLog.txt");
                    client.Dispose();
                }
                verscheck = MCDek.Server.selectedrevision.TrimStart('r');
                int vers = int.Parse(verscheck.Split('.')[0]);
                if (oldrevision) { filelocation = ("http://www.mclawl.tk/archives/exe/" + MCDek.Server.selectedrevision + ".exe"); }
                if (!oldrevision) { filelocation = ("http://www.mclawl.tk/MCLawl_.dll"); }
                WebClient Client = new WebClient();
                Client.DownloadFile(filelocation, "MCDek.new");
                Client.DownloadFile("", "Changelog.txt");
                foreach (Level l in MCDek.Server.levels) l.Save();
                foreach (Player pl in Player.players) pl.save();

                string fileName;
                if (!MCDek.Server.mono) fileName = "Update.bat";
                else fileName = "Update.sh";

                /*try
                {
                    if (MCDek.Gui.Window.thisWindow.notifyIcon1 != null)
                    {
                        MCDek.Gui.Window.thisWindow.notifyIcon1.Icon = null;
                        MCDek.Gui.Window.thisWindow.notifyIcon1.Visible = false;
                    }
                }
                catch { }*/

                Process p = Process.Start(fileName, "main " + System.Diagnostics.Process.GetCurrentProcess().Id.ToString());
                p.WaitForExit();
            }
            catch (Exception e) { MCDek.Server.ErrorLog(e); }
        }

        static public void ExitProgram(Boolean AutoRestart)
        {
            Thread exitThread;

            exitThread = new Thread(new ThreadStart(delegate
            {
                /*try
                {
                    if (MCDek.Gui.Window.thisWindow.notifyIcon1 != null)
                    {
                        MCDek.Gui.Window.thisWindow.notifyIcon1.Icon = null;
                        MCDek.Gui.Window.thisWindow.notifyIcon1.Visible = false;
                    }
                }
                catch { }
*/
                try
                {
                    saveAll();

                    if (AutoRestart == true) restartMe();
                    else MCDek.Server.process.Kill();
                }
                catch
                {
                    MCDek.Server.process.Kill();
                }
            })); exitThread.Start();
        }

        static public void restartMe(bool fullRestart = true)
        {
            Thread restartThread = new Thread(new ThreadStart(delegate
            {
                saveAll();

                MCDek.Server.shuttingDown = true;
                /*try
                {
                    if (MCDek.Gui.Window.thisWindow.notifyIcon1 != null)
                    {
                        MCDek.Gui.Window.thisWindow.notifyIcon1.Icon = null;
                        MCDek.Gui.Window.thisWindow.notifyIcon1.Visible = false;
                    }
                }
                catch { }*/

                if (MCDek.Server.listen != null) MCDek.Server.listen.Close();
                if (!MCDek.Server.mono || fullRestart)
                {
                    Application.Restart();
                    MCDek.Server.process.Kill();
                }
                else
                {
                    MCDek.Server.s.Start();
                }
            }));
            restartThread.Start();
        }
        static public void saveAll()
        {
            try
            {
                List<Player> kickList = new List<Player>();
                kickList.AddRange(Player.players);
                foreach (Player p in kickList) { p.Kick("MCDekServer restarted! Rejoin!"); }
            }
            catch (Exception exc) { MCDek.Server.ErrorLog(exc); }

            try
            {
                string level = null;
                foreach (Level l in MCDek.Server.levels)
                {
                    level = level + l.name + "=" + l.physics + System.Environment.NewLine;
                    l.Save();
                    l.saveChanges();
                }

                File.WriteAllText("text/autoload.txt", level);
            }
            catch (Exception exc) { MCDek.Server.ErrorLog(exc); }
        }
    }
}
