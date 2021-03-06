/*
	Copyright 2012 MCDek Team (Modified for use with MCZall/MCDek) 
*/
using System;
using System.Linq;
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
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

using MonoTorrent.Client;
using MCLawl;
using MCDek;

namespace MCDek
{
    public class Server
    {
        public static bool cancelcommand = false;
        public static bool canceladmin = false;
        public static bool cancellog = false;
        public static bool canceloplog = false;
        public static string apppath = Application.StartupPath;
        public delegate void OnConsoleCommand(string cmd, string message);
        public static event OnConsoleCommand ConsoleCommand;
        public delegate void OnServerError(Exception error);
        public static event OnServerError ServerError = null;
        public delegate void OnServerLog(string message);
        public static event OnServerLog ServerLog;
        public static event OnServerLog ServerAdminLog;
        public static event OnServerLog ServerOpLog;
        public delegate void HeartBeatHandler();
        public delegate void MessageEventHandler(string message);
        public delegate void PlayerListHandler(List<Player> playerList);
        public delegate void VoidHandler();
        public delegate void LogHandler(string message);
        public event LogHandler OnLog;
        public event LogHandler OnSystem;
        public event LogHandler OnCommand;
        public event LogHandler OnError;
        public event LogHandler OnOp;
        public event LogHandler OnAdmin;
        public event HeartBeatHandler HeartBeatFail;
        public event MessageEventHandler OnURLChange;
        public event PlayerListHandler OnPlayerListChange;
        public event VoidHandler OnSettingsUpdate;
        public static Thread locationChecker;
        public static bool UseTextures = false;
        public static Thread blockThread;
        public static List<MySql.Data.MySqlClient.MySqlCommand> mySQLCommands = new List<MySql.Data.MySqlClient.MySqlCommand>();

        public static int speedPhysics = 250;
        public static string Hash = String.Empty;
        public static string URL = String.Empty;
        public static string Version { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }

        public static Socket listen;
        public static System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();
        public static System.Timers.Timer updateTimer = new System.Timers.Timer(100);
        //static System.Timers.Timer heartbeatTimer = new System.Timers.Timer(60000); //Every 45 seconds
        static System.Timers.Timer messageTimer = new System.Timers.Timer(60000 * 5); //Every 5 mins
        public static System.Timers.Timer cloneTimer = new System.Timers.Timer(5000);

        public static List<string> Chatrooms = new List<string>();

        public static int count = 0;
        public static bool gungameon = false;

        public static bool higherranktp = true;
        public static bool agreetorulesonentry = false;
        public static bool UseCTF = false;
        public static bool ServerSetupFinished = false;
        public static PlayerList bannedIP;
        public static PlayerList whiteList;
        public static PlayerList ircControllers;
        public static PlayerList muted;
        public static PlayerList ignored;
        internal static readonly List<string> devs = new List<string>(new string[] { "dekema2, 303i, ballock1, MinedroidFTW" });
        public static List<string> Devs { get { return new List<string>(devs); } }
        public static bool gameon = false;

        public static List<TempBan> tempBans = new List<TempBan>();
        public struct TempBan { public string name; public DateTime allowedJoin; }
        
        public static bool verifyadmins = true;
        public static LevelPermission verifyadminsrank = LevelPermission.Operator;

        public static PerformanceCounter PCCounter = null;
        public static PerformanceCounter ProcessCounter = null;

        public static Level mainLevel;
        public static List<Level> levels;
        //reviewlist intitialize
        public static List<string> reviewlist = new List<string>();
        public static bool transenabled = false;
        public static string translang = "en";
        public static List<string> transignore = new List<string>();
        //public static List<levelID> allLevels = new List<levelID>();
        public static List<string> gcaccepted = new List<string>();
        public struct levelID { public int ID; public string name; }

        public static List<string> afkset = new List<string>();
        public static List<string> ircafkset = new List<string>();
        public static List<string> afkmessages = new List<string>();
        public static List<string> messages = new List<string>();

        public static int YesVotes = 0;
        public static int NoVotes = 0;
        public static bool voting = false;

        public static List<string> gcmods = new List<string>();
        public static List<string> gcmodprotection = new List<string>();
        public static List<string> gcnamebans = new List<string>();
        public static List<string> gcipbans = new List<string>();

        public static DateTime timeOnline;
        public static string IP;
        //auto updater stuff
        public static bool autoupdate;
        public static bool autonotify;
        public static bool notifyPlayers;
        public static string restartcountdown = "";
        public static string selectedrevision = "";
        public static bool autorestart;
        public static DateTime restarttime;
        public static MapGenerator MapGen;
        public static bool chatmod = false;


        public static Dictionary<string, string> customdollars = new Dictionary<string, string>();


        //Settings
        #region Server Settings
        public const byte version = 7;
        public static string salt = "";

        public static string name = "[MCDek] Default";
        public static string motd = "Welcome!";
        public static byte players = 12;
        public static byte maxGuests = 10;

        public static byte maps = 5;
        public static int port = 25565;
        public static bool pub = true;
        public static bool verify = true;
        public static bool worldChat = true;
        public static bool guestGoto = false;

        public static bool checkspam = false;
        public static int spamcounter = 8;
        public static int mutespamtime = 60;
        public static int spamcountreset = 5;

        public static string ZallState = "Alive";

        public static string level = "main";
        public static string errlog = "error.log";

        public static bool console = false;
        public static bool reportBack = true;

        public static bool irc = false;
        public static bool ircColorsEnable = false;
        public static int ircPort = 6667;
        public static string ircNick = "MCDek";
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
        public static bool AutoLoad = true;
        public static int physUndo = 20000;
        public static int totalUndo = 200;
        public static bool rankSuper = true;
        public static bool oldHelp = false;
        public static bool parseSmiley = true;
        public static bool useWhitelist = false;
        public static bool PremiumPlayersOnly = false;
        public static bool forceCuboid = false;
        public static bool profanityFilter = false;
        public static bool notifyOnJoinLeave = false;
        public static bool repeatMessage = false;
        public static bool globalignoreops = false;

        public static bool checkUpdates = true;

        public static bool useMySQL = false;
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
        public static LevelPermission afkkickperm = LevelPermission.AdvBuilder;
        //public static int RemotePort = 1337;

        public static string defaultRank = "guest";

        public static bool dollardollardollar = true;
        public static bool unsafe_plugin = true;
        public static bool cheapMessage = true;
        public static string cheapMessageGiven = " is now being cheap and being immortal";
        public static bool customBan = false;
        public static string customBanMessage = "You're banned!";
        public static bool customShutdown = false;
        public static string customShutdownMessage = "Server shutdown. Rejoin in 10 seconds.";
        public static bool customGrieferStone = false;
        public static string customGrieferStoneMessage = "Oh noes! You were caught griefing!";
        public static string customPromoteMessage = "&6Congratulations for working hard and getting &2PROMOTED!";
        public static string customDemoteMessage = "&4DEMOTED! &6We're sorry for your loss. Good luck on your future endeavors! &1:'(";
        public static string moneys = "moneys";
        public static LevelPermission opchatperm = LevelPermission.Operator;
        public static LevelPermission adminchatperm = LevelPermission.Admin;
        public static bool logbeat = false;
        public static bool adminsjoinsilent = false;
        public static bool mono { get { return (Type.GetType("Mono.Runtime") != null); } }
        public static string server_owner = "Jeb";
        public static bool WomDirect = true;
        public static bool UseSeasons = false;
        public static bool guestLimitNotify = false;
        public static bool guestJoinNotify = true;
        public static bool guestLeaveNotify = true;

        public static bool flipHead = false;

        public static bool shuttingDown = false;
        public static bool restarting = false;

        public static bool hackrank_kick = true;
        public static int hackrank_kick_time = 5; 

        //reviewoptions intitialize
        public static int reviewcooldown = 600;
        public static LevelPermission reviewenter = LevelPermission.Guest;
        public static LevelPermission reviewleave = LevelPermission.Guest;
        public static LevelPermission reviewview = LevelPermission.Operator;
        public static LevelPermission reviewnext = LevelPermission.Operator;
        public static LevelPermission reviewclear = LevelPermission.Operator;

        #endregion

        public static MainLoop ml;
        public static Server s;
        public Server()
        {
            ml = new MainLoop("server");
            Server.s = this;
        }
        //True = cancel event
        //Fale = dont cacnel event
        public static bool Check(string cmd, string message)
        {
            if (ConsoleCommand != null)
                ConsoleCommand(cmd, message);
            return cancelcommand;
        }

        public void Start()
        {

            shuttingDown = false;
            Log("Starting Server");
            {
                try
                {
                    if (File.Exists("Restarter.exe"))
                    {
                        File.Delete("Restarter.exe");
                    }
                }
                catch { }
                try
                {
                    if (File.Exists("Restarter.pdb"))
                    {
                        File.Delete("Restarter.pdb");
                    }
                }
                catch { }

            }
            if (!Directory.Exists("properties")) Directory.CreateDirectory("properties");
            if (!Directory.Exists("levels")) Directory.CreateDirectory("levels");
            if (!Directory.Exists("bots")) Directory.CreateDirectory("bots");
            if (!Directory.Exists("text")) Directory.CreateDirectory("text");
            if (!File.Exists("text/tempranks.txt")) File.CreateText("text/tempranks.txt").Dispose();
            if (!File.Exists("text/rankinfo.txt")) File.CreateText("text/rankinfo.txt").Dispose();
            if (!File.Exists("text/transexceptions.txt")) File.CreateText("text/transexceptions.txt").Dispose();
            if (!File.Exists("text/gcaccepted.txt")) File.CreateText("text/gcaccepted.txt").Dispose();
            if (!File.Exists("text/bans.txt")) File.CreateText("text/bans.txt").Dispose();
            else
            {
                string bantext = File.ReadAllText("text/bans.txt");
                if (!bantext.Contains("%20") && bantext != "")
                {
                    bantext = bantext.Replace("~", "%20");
                    bantext = bantext.Replace("-", "%20");
                    File.WriteAllText("text/bans.txt", bantext);
                }
            }



            if (!Directory.Exists("extra")) Directory.CreateDirectory("extra");
            if (!Directory.Exists("extra/undo")) Directory.CreateDirectory("extra/undo");
            if (!Directory.Exists("extra/undoPrevious")) Directory.CreateDirectory("extra/undoPrevious");
            if (!Directory.Exists("extra/copy/")) { Directory.CreateDirectory("extra/copy/"); }
            if (!Directory.Exists("extra/copyBackup/")) { Directory.CreateDirectory("extra/copyBackup/"); }
            if (!Directory.Exists("extra/Waypoints")) { Directory.CreateDirectory("extra/Waypoints"); }

            try
            {
                if (File.Exists("server.properties")) File.Move("server.properties", "properties/server.properties");
                if (File.Exists("rules.txt")) File.Move("rules.txt", "text/rules.txt");
                if (File.Exists("welcome.txt")) File.Move("welcome.txt", "text/welcome.txt");
                if (File.Exists("messages.txt")) File.Move("messages.txt", "text/messages.txt");
                if (File.Exists("externalurl.txt")) File.Move("externalurl.txt", "text/externalurl.txt");
                if (File.Exists("autoload.txt")) File.Move("autoload.txt", "text/autoload.txt");
                if (File.Exists("IRC_Controllers.txt")) File.Move("IRC_Controllers.txt", "ranks/IRC_Controllers.txt");
                if (useWhitelist) if (File.Exists("whitelist.txt")) File.Move("whitelist.txt", "ranks/whitelist.txt");
            }
            catch { }

            if (File.Exists("text/custom$s.txt"))
            {
                using (StreamReader r = new StreamReader("text/custom$s.txt"))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        if (line.StartsWith("//")) continue;
                        var split = line.Split(new[] { ':' }, 2);
                        if (split.Length == 2 && !String.IsNullOrEmpty(split[0]))
                        {
                            customdollars.Add(split[0], split[1]);
                        }
                    }
                }
            }
            else
            {
                s.Log("custom$s.txt does not exist, creating");
                using (StreamWriter SW = File.CreateText("text/custom$s.txt"))
                {
                    SW.WriteLine("// This is used to create custom $s");
                    SW.WriteLine("// If you start the line with a // it wont be used");
                    SW.WriteLine("// It should be formatted like this:");
                    SW.WriteLine("// $website:dekemaserv.com");
                    SW.WriteLine("// That would replace '$website' in any message to 'dekemaserv.com'");
                    SW.WriteLine("// It must not start with a // and it must not have a space between the 2 sides and the colon (:)");
                    SW.Close();
                }
            }

            LoadAllSettings();

            if (File.Exists("text/emotelist.txt"))
            {
                foreach (string s in File.ReadAllLines("text/emotelist.txt"))
                {
                    Player.emoteList.Add(s);
                }
            }
            else
            {
                File.Create("text/emotelist.txt").Dispose();
            }



            timeOnline = DateTime.Now;
            {
                try
                {
                    MySQL.executeQuery("CREATE DATABASE if not exists `" + MySQLDatabaseName + "`", true); // works in both now, SQLite simply ignores this.
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                Server.s.Log("MySQL settings have not been set! Many features will not be available if MySQL is not enabled");
                Server.ErrorLog(e);
                }
                catch (Exception e)
                {
                    ErrorLog(e);
                    s.Log("MySQL settings have not been set! Please Setup using the properties window.");
                    process.Kill();
                    return;
                }
                MySQL.executeQuery(string.Format("CREATE TABLE if not exists Players (ID INTEGER {0}AUTO{1}INCREMENT NOT NULL, Name VARCHAR(20), IP CHAR(15), FirstLogin DATETIME, LastLogin DATETIME, totalLogin MEDIUMINT, Title CHAR(20), TotalDeaths SMALLINT, Money MEDIUMINT UNSIGNED, totalBlocks BIGINT, totalCuboided BIGINT, totalKicked MEDIUMINT, TimeSpent VARCHAR(20), color VARCHAR(6), title_color VARCHAR(6){2});", (useMySQL ? "" : "PRIMARY KEY "), (useMySQL ? "_" : ""), (Server.useMySQL ? ", PRIMARY KEY (ID)" : "")));
                MySQL.executeQuery(string.Format("CREATE TABLE if not exists Playercmds (ID INTEGER {0}AUTO{1}INCREMENT NOT NULL, Time DATETIME, Name VARCHAR(20), Rank VARCHAR(20), Mapname VARCHAR(40), Cmd VARCHAR(40), Cmdmsg VARCHAR(40){2});", (useMySQL ? "" : "PRIMARY KEY "), (useMySQL ? "_" : ""), (Server.useMySQL ? ", PRIMARY KEY (ID)" : "")));

                if (useMySQL)
                {
                    DataTable colorExists = MySQL.fillData("SHOW COLUMNS FROM Players WHERE `Field`='color'");

                    if (colorExists.Rows.Count == 0)
                    {
                        MySQL.executeQuery("ALTER TABLE Players ADD COLUMN color VARCHAR(6) AFTER totalKicked");
                    }
                    colorExists.Dispose();

                    DataTable tcolorExists = MySQL.fillData("SHOW COLUMNS FROM Players WHERE `Field`='title_color'");

                    if (tcolorExists.Rows.Count == 0)
                    {
                        MySQL.executeQuery("ALTER TABLE Players ADD COLUMN title_color VARCHAR(6) AFTER color");
                    }
                    tcolorExists.Dispose();

                    DataTable timespent = MySQL.fillData("SHOW COLUMNS FROM Players WHERE `Field`='TimeSpent'");

                    if (timespent.Rows.Count == 0)
                        MySQL.executeQuery("ALTER TABLE Players ADD COLUMN TimeSpent VARCHAR(20) AFTER totalKicked"); //else SQLite.executeQuery("ALTER TABLE Players ADD COLUMN TimeSpent VARCHAR(20) AFTER totalKicked");
                    timespent.Dispose();

                    DataTable totalCuboided = MySQL.fillData("SHOW COLUMNS FROM Players WHERE `Field`='totalCuboided'");

                    if (totalCuboided.Rows.Count == 0)
                        MySQL.executeQuery("ALTER TABLE Players ADD COLUMN totalCuboided BIGINT AFTER totalBlocks"); //else SQLite.executeQuery("ALTER TABLE Players ADD COLUMN totalCuboided BIGINT AFTER totalBlocks");
                    totalCuboided.Dispose();
                }
            }

            if (levels != null)
                foreach (Level l in levels) { l.Unload(); }
            ml.Queue(delegate
            {
                try
                {
                    levels = new List<Level>(Server.maps);
                    MapGen = new MapGenerator();

                    if (File.Exists("levels/" + level + ".lvl"))
                    {
                        mainLevel = Level.Load(level);
                        mainLevel.unload = false;
                        if (mainLevel == null)
                        {
                            if (File.Exists("levels/" + level + ".lvl.backup"))
                            {
                                Log("Attempting to load backup of " + level + ".");
                                File.Copy("levels/" + level + ".lvl.backup", "levels/" + level + ".lvl", true);
                                mainLevel = Level.Load(level);
                                if (mainLevel == null)
                                {
                                    Log("BACKUP FAILED!");
                                    Console.ReadLine(); return;
                                }
                            }
                            else
                            {
                                Log("mainlevel not found");
                                mainLevel = new Level(level, 128, 64, 128, "flat") { permissionvisit = LevelPermission.Guest, permissionbuild = LevelPermission.Guest };
                                mainLevel.Save();
                            }
                        }
                    }
                    else
                    {
                        Log("mainlevel not found");
                        mainLevel = new Level(level, 128, 64, 128, "flat") { permissionvisit = LevelPermission.Guest, permissionbuild = LevelPermission.Guest };
                        mainLevel.Save();

                    }

                    addLevel(mainLevel);

                }
                catch (Exception e) { ErrorLog(e); }
            });
            ml.Queue(delegate
            {
                bannedIP = PlayerList.Load("banned-ip.txt", null);
                ircControllers = PlayerList.Load("IRC_Controllers.txt", null);
                muted = PlayerList.Load("muted.txt", null);

                foreach (MCLawl.Group grp in MCLawl.Group.GroupList)
                    grp.playerList = PlayerList.Load(grp.fileName, grp);
                if (useWhitelist)
                    whiteList = PlayerList.Load("whitelist.txt", null);
            });

            ml.Queue(delegate
            {
                transignore.AddRange(File.ReadAllLines("text/transexceptions.txt"));
                if (File.Exists("text/autoload.txt"))
                {
                    try
                    {
                        string[] lines = File.ReadAllLines("text/autoload.txt");
                        foreach (string _line in lines.Select(line => line.Trim()))
                        {
                            try
                            {
                                if (_line == "") { continue; }
                                if (_line[0] == '#') { continue; }

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
                                        s.Log("Physics variable invalid");
                                    }
                                }


                            }
                            catch
                            {
                                s.Log(_line + " failed.");
                            }
                        }
                    }
                    catch
                    {
                        s.Log("autoload.txt error");
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
                foreach (string line in File.ReadAllLines("text/transexceptions.txt"))
                {
                    transignore.Add(line); //loading all playernames of people who turned off translation
                }
                foreach (string line in File.ReadAllLines("text/gcaccepted.txt"))
                {
                    gcaccepted.Add(line); //loading all playernames of people who turned off translation
                }
                Log("Creating listening socket on port " + port + "... ");
                Setup();
                //s.Log(Setup() ? "Done." : "Could not create socket connection. Shutting down.");
            });



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
                    using (StreamReader r = File.OpenText("text/messages.txt"))
                    {
                        while (!r.EndOfStream)
                            messages.Add(r.ReadLine());
                    }
                }
                else File.Create("text/messages.txt").Close();


                new AutoSaver(Server.backupInterval);

                blockThread = new Thread(new ThreadStart(delegate
                {
                    while (true)
                    {
                        Thread.Sleep(blockInterval * 1000);
                        levels.ForEach(delegate(Level l)
                        {
                            try
                            {
                                l.saveChanges();
                            }
                            catch (Exception e)
                            {
                                Server.ErrorLog(e);
                            }
                        });
                    }
                }));
                blockThread.Start();

                locationChecker = new Thread(new ThreadStart(delegate
                {
                    Player p, who;
                    ushort x, y, z;
                    int i;
                    while (true)
                    {
                        Thread.Sleep(3);
                        for (i = 0; i < Player.players.Count; i++)
                        {
                            try
                            {
                                p = Player.players[i];

                                if (p.frozen)
                                {
                                    unchecked { p.SendPos((byte)-1, p.pos[0], p.pos[1], p.pos[2], p.rot[0], p.rot[1]); } continue;
                                }
                                else if (p.following != "")
                                {
                                    who = Player.Find(p.following);
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
                                }
                                else if (p.possess != "")
                                {
                                    who = Player.Find(p.possess);
                                    if (who == null || who.level != p.level)
                                        p.possess = "";
                                }

                                x = (ushort)(p.pos[0] / 32);
                                y = (ushort)(p.pos[1] / 32);
                                z = (ushort)(p.pos[2] / 32);

                                if (p.level.Death)
                                    p.RealDeath(x, y, z);
                                p.CheckBlock(x, y, z);

                                p.oldBlock = (ushort)(x + y + z);
                            }
                            catch (Exception e) { Server.ErrorLog(e); }
                        }
                    }
                }));

                locationChecker.Start();
                try
                {
                    using (WebClient web = new WebClient())
                        IP = web.DownloadString("http://dynupdate.no-ip.com/ip.php");
                }
                catch { }
#if DEBUG
                UseTextures = true;
#endif
                Log("Finished setting up server");
                ServerSetupFinished = true;

            });
        }

        public static void LoadAllSettings()
        {
            Properties.Load("properties/server.properties");
            Updater.Load("properties/update.properties");
            MCLawl.Group.InitAll();
            Command.InitAll();
            GrpCommands.fillRanks();
            Block.SetBlocks();
            Awards.Load();
        }

        public static void Setup()
        {
            try
            {
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, port);
                listen = new Socket(endpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listen.Bind(endpoint);
                listen.Listen((int)SocketOptionName.MaxConnections);
                listen.BeginAccept(Accept, null);
            }
            catch (SocketException e) { ErrorLog(e); s.Log("Error Creating listener, socket shutting down"); }
            catch (Exception e) { ErrorLog(e); s.Log("Error Creating listener, socket shutting down"); }
        }

        static void Accept(IAsyncResult result)
        {
            if (shuttingDown) return;

            Player p = null;
            bool begin = false;
            try
            {
                p = new Player(listen.EndAccept(result));
                //new Thread(p.Start).Start();
                listen.BeginAccept(Accept, null);
                begin = true;
            }
            catch (SocketException)
            {
                if (p != null)
                    p.Disconnect();
                if (!begin)
                    listen.BeginAccept(Accept, null);
            }
            catch (Exception e)
            {
                ErrorLog(e);
                if (p != null)
                    p.Disconnect();
                if (!begin)
                    listen.BeginAccept(Accept, null);
            }

        }

        public static void Exit(bool AutoRestart)
        {
            List<string> players = new List<string>();
            foreach (Player p in Player.players) { p.save(); players.Add(p.name); }
            foreach (string p in players)
            {
                if (!AutoRestart)
                    Player.Find(p).Kick(Server.customShutdown ? Server.customShutdownMessage : "Server shutdown. Rejoin in 10 seconds.");
                else
                    Player.Find(p).Kick("Server restarted! Rejoin!");
            }

            //Player.players.ForEach(delegate(Player p) { p.Kick("Server shutdown. Rejoin in 10 seconds."); });
            Player.connections.ForEach(
            delegate(Player p)
            {
                if (!AutoRestart)
                    p.Kick(Server.customShutdown ? Server.customShutdownMessage : "Server shutdown. Rejoin in 10 seconds.");
                else
                    p.Kick("Server restarted! Rejoin!");
            }
            );
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
        //
        //
        //here too
        //

        public void UpdateUrl(string url)
        {
            if (OnURLChange != null) OnURLChange(url);
        }
        //
        //
        //
        //


        public void Log(string message, bool systemMsg = false)
        {
            if (ServerLog != null)
            {
                ServerLog(message);
                if (cancellog)
                {
                    cancellog = false;
                    return;
                }
            }
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
        public void OpLog(string message, bool systemMsg = false)
        {
            if (ServerOpLog != null)
            {
                OpLog(message);
                if (canceloplog)
                {
                    canceloplog = false;
                    return;
                }
            }
            if (OnOp != null)
            {
                if (!systemMsg)
                {
                    OnOp(DateTime.Now.ToString("(HH:mm:ss) ") + message);
                }
                else
                {
                    OnSystem(DateTime.Now.ToString("(HH:mm:ss) ") + message);
                }
            }

            Logger.Write(DateTime.Now.ToString("(HH:mm:ss) ") + message + Environment.NewLine);
        }

        public void AdminLog(string message, bool systemMsg = false)
        {
            if (ServerAdminLog != null)
            {
                ServerAdminLog(message);
                if (canceladmin)
                {
                    canceladmin = false;
                    return;
                }
            }
            if (OnAdmin != null)
            {
                if (!systemMsg)
                {
                    OnAdmin(DateTime.Now.ToString("(HH:mm:ss) ") + message);
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
            if (ServerError != null)
                ServerError(ex);
            Logger.WriteError(ex);
            try
            {
                s.Log("!!!Error! See " + Logger.ErrorLogPath + " for more information.");
            }
            catch { }
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
            foreach (MCLawl.Group grp in MCLawl.Group.GroupList.Where(grp => grp.playerList.Contains(Username)))
            {
                return grp.color;
            }
            return MCLawl.Group.standard.color;
        }
        public static bool gcmodhasprotection(string name)
        {
            return gcmods.Contains(name) && gcmodprotection.Where(line => line.Contains(name)).Any(line => line.Split('*')[1] == "1");
        }
        public static bool LevelExists(string givenName)
        {
            if (File.Exists("levels/" + givenName + ".lvl"))
            {
                return true;
            }
            else return false;
        }
    }
}