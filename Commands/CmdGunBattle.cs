using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCLawl;
using System.IO;
using System.Threading;
using MonoTorrent.Common;

namespace MCDek
{
public class CmdGunBattle : Command
    {
        public override string name { get { return "gunbattle"; } }
        public override string shortcut { get { return "gb"; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public List<string> gbPlayers = new List<string>();
        private Command move = Command.all.Find("move");
        private Command title = Command.all.Find("title");
        public override void Use(Player p, string message)
        {
            string[] split = message.Trim().ToLower().Split(' ');
            string dir = "gunbattle/";
            string gameFile = dir + "gunbattle.gb";
            
            if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            bool gameExists = (File.Exists(gameFile)); 

            try
            {
                switch (split[0])
                {
                    case "start":
                        if (gameExists) { Player.SendMessage(p, "A Gun Battle is already in progress! You cant start a new one!"); return; } 
                        if (Player.players.Count < 2) { Player.SendMessage(p, "You need more than 2 players to start a game"); return; }

                        Player.GlobalMessage("The Gun Battle has begun! Let the massacre begin!");

                        Thread gameThread = new Thread(new ThreadStart(delegate 
                            {
                                File.Create(gameFile).Close();

                                int a = 0;

                                while (File.Exists(gameFile))
                                {
                                    a++;

                                    decimal minutes = Math.Round((decimal)(((a * 1000) / 60000)));

                                    string[] fileLines = File.ReadAllLines(gameFile);
                                    List<string> gameList = new List<string>();

                                    CheckDeath(null, true);
                                    foreach (string line in fileLines)
                                    {
                                        string[] lineSplit = line.Split('|');
                                        string gamePlayerName = split[0];
                                        bool isDead = (split[1] == "dead");
                                        Player gamePlayer = Player.Find(gamePlayerName);

                                        if (gamePlayer == null) { Player.SendMessage(p, "Player " + gamePlayerName + " has left the game."); continue; }

                                        
                                        string nLine = "";

                                        gameList.Add(nLine);
                                    }

                                    File.WriteAllLines(gameFile, gameList.ToArray());

                                    Thread.Sleep(1000);
                                }
                            }));

                        gameThread.Start();

                        return;
                    case "stop":
                        if (!gameExists) { Player.SendMessage(p, "There are no games in progress!"); return; }

                        File.Delete(gameFile);
                        Player.GlobalMessage("This Gun Battle has been canceled!");
                        return;
                    case "setjail":
                        if (p == null) { Player.SendMessage(p, "Only players can use this command!"); return; }
                       
                        string levelFile = dir + p.level.name + ".gb";

                        if (File.Exists(levelFile)) { File.Delete(levelFile); Thread.Sleep(1000); }

                        StreamWriter SW = new StreamWriter(levelFile);
                        string jail = (p.pos[0] / 32) + " " + (p.pos[1] / 32) + " " + (p.pos[2] / 32);

                        SW.WriteLine(jail);
                        SW.Flush();
                        SW.Close();
                        SW.Dispose();
                        Player.SendMessage(p, "The co-ordinates for the jail were set to " + jail);




                        return;
                    default: Help(p); return;
                }
            }
            catch (Exception ex)
            {
                Server.ErrorLog(ex);
                Player.GlobalMessage("An error occurred! Stopping the game!");

                if (File.Exists(gameFile)) { File.Delete(gameFile); }
            }
        }
        public void CheckDeath(Level randLevel, bool sendMsg)
        {
            for (int i = 0; i < gbPlayers.Count; i++)
            {
                string gbPlayer = gbPlayers[i];
                Player player = Player.Find(gbPlayer.Split(':')[0]);
                if (player != null)
                {
                    string state = gbPlayer.Split(':')[1];
                    int prevDeaths = int.Parse(gbPlayer.Split(':')[2]);
                    int newDeaths = player.overallDeath - prevDeaths;
                    int lives = 1 - newDeaths;
                    bool die = lives <= 0;
                    if ((randLevel != null) && (player.level != randLevel)) { move.Use(null, player.name + " " + randLevel.name); }
                    if (state != "dead")
                    {
                        if (die)
                        {
                            gbPlayers.Add(player.name + ":dead:0:" + player.prefix + ":" + player.color);
                            Kill(player);
                            gbPlayers.Remove(gbPlayer);
                        }

                    }
                    else { if (sendMsg) { Player.SendMessage(player, "You're dead. Waiting for next round..."); } }
                }
                else { gbPlayers.Remove(gbPlayer); }
            }
        }
        public void Kill(Player player) 
        { 
           title.Use(player, "&5[DEAD]"); 
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/gunbattle <start/stop> - Starts or stops the brawl!");
            Player.SendMessage(p, "/gunbattle <setjail> - Sets coordinates for the jail");


        }
    }
}

