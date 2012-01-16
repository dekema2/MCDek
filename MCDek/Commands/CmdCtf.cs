using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCLawl
{
    public class CmdCTF : Command
    {
        public override string name { get { return "ctf"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public CmdCTF() { }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public override void Use(Player p, string message)
        {
            int num = message.Split(' ').Length;
            if (num == 3)
            {
                string[] strings = message.Split(' ');

                for (int i = 0; i < num; i++)
                {
                    strings[i] = strings[i].ToLower();
                }

                if (strings[0] == "team")
                {
                    if (strings[1] == "add")
                    {
                        string color = c.Parse(strings[2]);
                        if (color == ""){Player.SendMessage(p, "Invalid team color chosen."); return;}
                        char teamCol = (char)color[1];
                        switch (teamCol)
                        {
                            case '2':
                            case '5':
                            case '8':
                            case '9':
                            case 'c':
                            case 'e':
                            case 'f':
                                AddTeam(p, color);
                                break;
                            default:
                                Player.SendMessage(p, "Invalid team color chosen.");
                                return;
                        }
                    }
                    else if (strings[1] == "remove")
                    {
                        string color = c.Parse(strings[2]);
                        if (color == "") { Player.SendMessage(p, "Invalid team color chosen."); return; }
                        char teamCol = (char)color[1];
                        switch (teamCol)
                        {
                            case '2':
                            case '5':
                            case '8':
                            case '9':
                            case 'c':
                            case 'e':
                            case 'f':
                                RemoveTeam(p, color);
                                break;
                            default:
                                Player.SendMessage(p, "Invalid team color chosen.");
                                return;
                        }
                    }
                }
            }
            else if (num == 2)
            {
                string[] strings = message.Split(' ');

                for (int i = 0; i < num; i++)
                {
                    strings[i] = strings[i].ToLower();
                }

                if (strings[0] == "debug")
                {
                    Debug(p, strings[1]);
                }
                else if (strings[0] == "flag")
                {
                    string color = c.Parse(strings[1]);
                    if (color == "") { Player.SendMessage(p, "Invalid team color chosen."); return; }
                    char teamCol = (char)color[1];
                    if (p.level.ctfgame.teams.Find(team => team.color == teamCol) == null) { Player.SendMessage(p, "Invalid team color chosen."); return; }
                    CatchPos cpos;
                    cpos.x = 0; cpos.y = 0; cpos.z = 0; cpos.color = color; p.blockchangeObject = cpos;
                    Player.SendMessage(p, "Place a block to determine where to place the flag.");
                    p.ClearBlockchange();
                    p.Blockchange += new Player.BlockchangeEventHandler(FlagBlockChange);
                }
                else if (strings[0] == "spawn")
                {
                    string color = c.Parse(strings[1]);
                    if (color == "") { Player.SendMessage(p, "Invalid team color chosen."); return; }
                    char teamCol = (char)color[1];
                    if (p.level.ctfgame.teams.Find(team => team.color == teamCol) == null) { Player.SendMessage(p, "Invalid team color chosen."); return; }
                    AddSpawn(p, color);
                    
                }
                else if (strings[0] == "points")
                {
                    int i = 0;
                    Int32.TryParse(strings[1], out i);
                    if (i == 0) { Player.SendMessage(p, "You must choose a points value greater than 0!"); return; }
                    p.level.ctfgame.maxPoints = i;
                    Player.SendMessage(p, "Max round points has been set to " + i);
                }
            }
            else if (num == 1)
            {
                if (message.ToLower() == "start")
                {
                    if (!p.level.ctfmode)
                    {
                        p.level.ctfmode = true;
                    }
                    p.level.ctfgame.gameOn = true;
                    p.level.ctfgame.GameStart();
                }
                else if (message.ToLower() == "stop")
                {
                    if (p.level.ctfmode)
                    {
                        p.level.ctfmode = false;
                    }
                    p.level.ctfmode = false;
                    p.level.ctfgame.gameOn = false;
                    p.level.ChatLevel(p.color + p.name + Server.DefaultColor + " has ended the game");
                }
                else if (message.ToLower() == "ff")
                {
                    if (p.level.ctfgame.friendlyfire)
                    {
                        p.level.ChatLevel("Friendly fire has been disabled.");
                        p.level.ctfgame.friendlyfire = false;
                    }
                    else
                    {
                        p.level.ChatLevel("Friendly fire has been enabled.");
                        p.level.ctfgame.friendlyfire = true;
                    }
                }
                else if (message.ToLower() == "clear")
                {
                    List<Team> storedT = new List<Team>();
                    for (int i = 0; i < p.level.ctfgame.teams.Count; i++)
                    {
                        storedT.Add(p.level.ctfgame.teams[i]);
                    }
                    foreach (Team t in storedT)
                    {
                        p.level.ctfgame.RemoveTeam("&" + t.color);
                    }
                    p.level.ctfgame.onTeamCheck.Stop();
                    p.level.ctfgame.onTeamCheck.Dispose();
                    p.level.ctfgame.gameOn = false;
                    p.level.ctfmode = false;
                    p.level.ctfgame = new CTFGame();
                    p.level.ctfgame.mapOn = p.level;
                    Player.SendMessage(p, "CTF data has been cleared.");
                }

                else if (message.ToLower() == "")
                {
                    if (p.level.ctfmode)
                    {
                        p.level.ctfmode = false;
                        p.level.ChatLevel("CTF Mode has been disabled.");

                    }
                    else if (!p.level.ctfmode)
                    {
                        p.level.ctfmode = true;
                        p.level.ChatLevel("CTF Mode has been enabled.");
                    }
                }
            }
        }
        public void AddSpawn(Player p, string color)
        {
            char teamCol = (char)color[1];
            ushort x, y, z, rotx;
            x = (ushort)(p.pos[0] / 32);
            y = (ushort)(p.pos[1] / 32);
            z = (ushort)(p.pos[2] / 32);
            rotx = (ushort)(p.rot[0]);
            p.level.ctfgame.teams.Find(team => team.color == teamCol).AddSpawn(x, y, z, rotx, 0);
            Player.SendMessage(p, "Added spawn for " + p.level.ctfgame.teams.Find(team => team.color == teamCol).teamstring);
        }

        public void AddTeam(Player p, string color)
        {
            char teamCol = (char)color[1];
            if (p.level.ctfgame.teams.Find(team => team.color == teamCol)!= null){Player.SendMessage(p, "That team already exists."); return;}
            p.level.ctfgame.AddTeam(color);
        }

        public void RemoveTeam(Player p, string color)
        {
            char teamCol = (char)color[1];
            if (p.level.ctfgame.teams.Find(team => team.color == teamCol) == null) { Player.SendMessage(p, "That team does not exist."); return; }
            p.level.ctfgame.RemoveTeam(color);
        }

        public void AddFlag(Player p, string col, ushort x, ushort y, ushort z)
        {
            char teamCol = (char)col[1];
            Team workTeam = p.level.ctfgame.teams.Find(team => team.color == teamCol);

            workTeam.flagBase[0] = x;
            workTeam.flagBase[1] = y;
            workTeam.flagBase[2] = z;

            workTeam.flagLocation[0] = x;
            workTeam.flagLocation[1] = y;
            workTeam.flagLocation[2] = z;
            workTeam.Drawflag();
        }

        public void Debug(Player p, string col)
        {
            if (col.ToLower() == "flags")
            {
                foreach (Team team in p.level.ctfgame.teams)
                {
                    Player.SendMessage(p, "Drawing flag for " + team.teamstring);
                    team.Drawflag();
                }
                return;
            }
            else if (col.ToLower() == "spawn")
            {
                foreach (Team team in p.level.ctfgame.teams)
                {
                    foreach (Player player in team.players)
                    {
                        team.SpawnPlayer(player);
                    }
                }
                return;
            }
            string color = c.Parse(col);
            char teamCol = (char)color[1];
            Team workTeam = p.level.ctfgame.teams.Find(team => team.color == teamCol);
            string debugteams = "";
            for (int i = 0; i < p.level.ctfgame.teams.Count; i++)
            {
                debugteams += p.level.ctfgame.teams[i].teamstring + ", ";
            }
            Player.SendMessage(p, "Player Debug: Team: " + p.team.teamstring/* + ", hasFlag: " + p.hasflag.teamstring + ", carryingFlag: " + p.carryingFlag*/);
            Player.SendMessage(p, "CTFGame teams: " + debugteams);
            string playerlist = "";
            foreach (Player player in workTeam.players)
            {
                playerlist += player.name + ", ";
            }
            Player.SendMessage(p, "Player list: " + playerlist);
            Player.SendMessage(p, "Points: " + workTeam.points + ", MapOn: " + workTeam.mapOn.name + ", flagishome: " + workTeam.flagishome + ", spawnset: " + workTeam.spawnset);
            Player.SendMessage(p, "FlagBase[0]: " + workTeam.flagBase[0] + ", [1]: " + workTeam.flagBase[1] + ", [2]: " + workTeam.flagBase[2]);
            Player.SendMessage(p, "FlagLocation[0]: " + workTeam.flagLocation[0] + ", [1]: " + workTeam.flagLocation[1] + ", [2]: " + workTeam.flagLocation[2]);
         //   Player.SendMessage(p, "Spawn[0]: " + workTeam.spawn[0] + ", [1]: " + workTeam.spawn[1] + ", [2]: " + workTeam.spawn[2] + ", [3]: " + workTeam.spawn[3] + ", [4]: " + workTeam.spawn[4]);
        }


        void FlagBlockChange(Player p, ushort x, ushort y, ushort z, byte type)
        {
            CatchPos bp = (CatchPos)p.blockchangeObject;
            byte b = p.level.GetTile(x, y, z);
            p.SendBlockchange(x, y, z, b);
            p.ClearBlockchange();
            AddFlag(p, bp.color, x, y, z);
        }


        public override void Help(Player p)
        {
            Player.SendMessage(p, "/ctf - Turns CTF mode on for the map.  Must be enabled to play!");
            Player.SendMessage(p, "/ctf start - Starts the game!");
            Player.SendMessage(p, "/ctf stop - Stops the game.");
            Player.SendMessage(p, "/ctf ff - Enables or disables friendly fire.  Default is off.");
            Player.SendMessage(p, "/ctf flag [color] - Sets the flag base for specified team.");
            Player.SendMessage(p, "/ctf spawn [color] - Adds a spawn for the team specified from where you are standing.");
            Player.SendMessage(p, "/ctf points [num] - Sets max round points.  Default is 3.");
            Player.SendMessage(p, "/ctf team add [color] - Initializes team of specified color.");
            Player.SendMessage(p, "/ctf team remove [color] - Removes team of specified color.");
            Player.SendMessage(p, "/ctf clear - Removes all CTF data from map.  Use sparingly.");
        }

        public struct CatchPos { public ushort x, y, z; public string color;}
    }
}
