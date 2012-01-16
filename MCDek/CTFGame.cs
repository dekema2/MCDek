using System;
using System.Collections.Generic;
using System.Threading;


/* CTF TO-DO LIST
 * Team-chat
 * Delayed respawns.  Dunno, put player somewhere in the mid-term?  Put them out of the map?  I dunno.
 * Fix the java client crash on RemoveMember that rarely but consistantly occurs.
 */
 


namespace MCLawl
{
    public class CTFGame
    {
        public List<Team> teams = new List<Team>();

        public Level mapOn;

        public int maxPoints = 3;

        public bool gameOn = false;

        public bool friendlyfire = false;

        public System.Timers.Timer onTeamCheck = new System.Timers.Timer(500);
        public System.Timers.Timer flagReturn = new System.Timers.Timer(1000);

        public int returnCount = 0;

        public void GameStart()
        {
            mapOn.ChatLevel("Capture the flag game has started!");
            foreach (Team team in teams)
            {
                ReturnFlag(null, team, false);
                foreach (Player p in team.players)
                {
                    team.SpawnPlayer(p);
                }
            }

            onTeamCheck.Start();
            onTeamCheck.Elapsed += delegate
            {
                foreach (Team team in teams)
                {
                    foreach (Player p in team.players)
                    {
                        if (!p.loggedIn || p.level != mapOn)
                        {
                            team.RemoveMember(p);
                        }
                    }
                }
            };

            flagReturn.Start();
            flagReturn.Elapsed += delegate
            {
                foreach (Team team in teams)
                {
                    if (!team.flagishome && team.holdingFlag == null)
                    {
                        team.ftcount++;
                        if (team.ftcount > 30)
                        {
                            mapOn.ChatLevel("The " + team.teamstring + " flag has returned to their base.");
                            team.ftcount = 0;
                            ReturnFlag(null, team, false);
                        }
                    }
                }
            };

            Thread flagThread = new Thread(new ThreadStart(delegate
                {
                    while (gameOn)
                    {
                        foreach (Team team in teams)
                        {
                            team.Drawflag();
                        }
                        Thread.Sleep(200);
                    }

                })); flagThread.Start();
        }

        public void GameEnd(Team winTeam)
        {
            mapOn.ChatLevel("The game has ended! " + winTeam.teamstring + " has won with " + winTeam.points + " point(s)!");
            foreach (Team team in teams)
            {
                ReturnFlag(null, team, false);
                foreach (Player p in team.players)
                {
                    p.hasflag = null;
                    p.carryingFlag = false;

                }
                team.points = 0;
                
            }

            gameOn = false;
            
        }

        public void GrabFlag(Player p, Team team)
        {
            if (p.carryingFlag) { return; }
            ushort x = (ushort)(p.pos[0] / 32);
            ushort y = (ushort)((p.pos[1] / 32) + 3);
            ushort z = (ushort)(p.pos[2] / 32);

            team.tempFlagblock.x = x; team.tempFlagblock.y = y; team.tempFlagblock.z = z; team.tempFlagblock.type = mapOn.GetTile(x, y, z);

            mapOn.Blockchange(x, y, z, Team.GetColorBlock(team.color));

            mapOn.ChatLevel(p.color + p.prefix + p.name + Server.DefaultColor + " has stolen the " + team.teamstring + " flag!");
            p.hasflag = team;
            p.carryingFlag = true;
            team.holdingFlag = p;
            team.flagishome = false;

            if (p.aiming)
            {
                p.ClearBlockchange();
                p.aiming = false;
            }
        }

        public void CaptureFlag(Player p, Team playerTeam, Team capturedTeam)
        {
            playerTeam.points++;
            mapOn.Blockchange(capturedTeam.tempFlagblock.x, capturedTeam.tempFlagblock.y, capturedTeam.tempFlagblock.z, capturedTeam.tempFlagblock.type);
            mapOn.ChatLevel(p.color + p.prefix + p.name + Server.DefaultColor + " has captured the " + capturedTeam.teamstring + " flag!");

            if (playerTeam.points >= maxPoints)
            {
                GameEnd(playerTeam);
                return;
            }

            mapOn.ChatLevel(playerTeam.teamstring + " now has " + playerTeam.points + " point(s).");
            p.hasflag = null;
            p.carryingFlag = false;
            ReturnFlag(null, capturedTeam, false);
        }

        public void DropFlag(Player p, Team team)
        {
            mapOn.ChatLevel(p.color + p.prefix + p.name + Server.DefaultColor + " has dropped the " + team.teamstring + " flag!");
            ushort x = (ushort)(p.pos[0] / 32);
            ushort y = (ushort)((p.pos[1] / 32) - 1);
            ushort z = (ushort)(p.pos[2] / 32);

            mapOn.Blockchange(team.tempFlagblock.x, team.tempFlagblock.y, team.tempFlagblock.z, team.tempFlagblock.type);

            team.flagLocation[0] = x;
            team.flagLocation[1] = y;
            team.flagLocation[2] = z;

            p.hasflag = null;
            p.carryingFlag = false;

            team.holdingFlag = null;
            team.flagishome = false;
        }
        public void ReturnFlag(Player p, Team team, bool verbose)
        {
            if (p != null && p.spawning) { return; }
            if (verbose)
            {
                if (p != null)
                {
                    mapOn.ChatLevel(p.color + p.prefix + p.name + Server.DefaultColor + " has returned the " + team.teamstring + " flag!");
                }
                else
                {
                    mapOn.ChatLevel("The " + team.teamstring + " flag has been returned.");
                }
            }
            team.holdingFlag = null;
            team.flagLocation[0] = team.flagBase[0];
            team.flagLocation[1] = team.flagBase[1];
            team.flagLocation[2] = team.flagBase[2];
            team.flagishome = true;
        }

        public void AddTeam(string color)
        {
            char teamCol = (char)color[1];

            Team workteam = new Team();

            workteam.color = teamCol;
            workteam.points = 0;
            workteam.mapOn = mapOn;
            char[] temp = c.Name("&" + teamCol).ToCharArray();
            temp[0] = char.ToUpper(temp[0]);
            string tempstring = new string(temp);
            workteam.teamstring = "&" + teamCol + tempstring + " team" + Server.DefaultColor;

            teams.Add(workteam);
            
            mapOn.ChatLevel(workteam.teamstring + " has been initialized!");
        }

        public void RemoveTeam(string color)
        {
            char teamCol = (char)color[1];

            Team workteam = teams.Find(team => team.color == teamCol);
            List<Player> storedP = new List<Player>();

            for (int i = 0; i < workteam.players.Count; i++)
            {
                storedP.Add(workteam.players[i]);
            }
            foreach (Player p in storedP)
            {
                workteam.RemoveMember(p);
            }
            
           
        }
    }
}
