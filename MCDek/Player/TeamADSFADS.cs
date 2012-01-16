/*Explanation:

 * Players added get color temporarily
 * When players change maps (are sent MOTDs)? Or teams are removed, their colors and titles are reverted
 * Players added with /team <team color>
 
 * Points are scored whenever a flag is carried through the team's flag area
 * Flags are picked up by walking through a special block (Block.Mover check)
 * Flags are shown flying over the heads of the flag carrier? (would need to add a "hasFlag" char to player's)
 * 
 * Flag position is set by /ctf flag [color]
 * Flags are saved in the level properties (similar to Jail)
 * Spawn is set by /ctf spawn [color]
 * Spawn is saved same way as Flags
 
 * Gotta make sure:
 *      To remove players who have logged off (since it wouldn't send MOTD)
 *      Reset hasFlag should the player not be on the map
 *      
 * Started with /ctf, which toggles the CTF mode for that map
 * /ctf reset; resets the teams
 * /ctf balance; balances the teams
 */

using System;
using System.Collections.Generic;
using System.Threading;

namespace MCLawlasdfdas
{
    public class Teamasdfd
    {
        public char color;
        public int points;
        public int maxpoints;
        public ushort[] flagBase = { 0, 0, 0 };
        public ushort[] flagLocation = { 0, 0, 0 };
        public ushort[] spawn = { 0, 0, 0, 0, 0 };
        public List<Player> onTeam = new List<Player>();
        public Player hasFlag;
        public Level mapOn;
        public bool flagishome;
        public bool spawnset;
        public string teamname;
        System.Timers.Timer onTeamCheck = new System.Timers.Timer(500);


        public void killTeam()
        {
            foreach (Player p in onTeam)
            {
                p.onTeam = 'z';
            }
        }

        public void addPlayer(Player p)
        {
            Team foundTeam = p.level.teams.Find(team => team.onTeam.Contains(p));
            if (foundTeam != null)
                foundTeam.removePlayer(p);

            p.onTeam = color;
            p.color = "&" + color;
            onTeam.Add(p);
            p.level.ChatLevel(p.color + p.prefix + p.name + Server.DefaultColor + " has joined the " + teamname + " team");
        }

        public void removePlayer(Player p)
        {
            p.onTeam = 'z';
            if (p.holdingFlag) { DropFlag(p, (ushort)(p.pos[0] / 32), (ushort)(p.pos[1] / 32), (ushort)(p.pos[2] / 32)); }
            onTeam.Remove(p);
            p.inCtf = false;
            p.holdingFlag = false;
            p.level.ChatLevel(p.color + p.prefix + p.name + Server.DefaultColor + " has left the " + teamname + " team");
        }

        public void HaveFlag(Player p)
        {
            if (!p.inCtf) { return; }
            mapOn.ChatLevel(p.color + p.name + Server.DefaultColor + " has stolen the " + teamname + " flag!");
            p.holdingFlag = true;
            p.hasFlag = this.color;
            hasFlag = p;
            CatchPos prevPos;
            CatchPos newPos;
            prevPos.x = (ushort)(hasFlag.pos[0] / 32);
            prevPos.y = (ushort)(hasFlag.pos[1] / 32 + 1);
            prevPos.z = (ushort)(hasFlag.pos[2] / 32);
            ushort x1 = (ushort)((0.5 + hasFlag.pos[0]));
            ushort y1 = (ushort)((1 + hasFlag.pos[1]));
            ushort z1 = (ushort)((0.5 + hasFlag.pos[2]));
            unchecked
            {
                hasFlag.SendSpawn((byte)-1, hasFlag.name, x1, y1, z1, hasFlag.rot[0], hasFlag.rot[1]);
            }
            Thread carryThread = new Thread(new ThreadStart(delegate
            {

                while (hasFlag != null)
                {
                    ushort x = (ushort)(hasFlag.pos[0] / 32);
                    ushort y = (ushort)(hasFlag.pos[1] / 32 + 3);
                    ushort z = (ushort)(hasFlag.pos[2] / 32);

                    newPos.x = x;
                    newPos.y = y;
                    newPos.z = z;
                    mapOn.Blockchange(prevPos.x, prevPos.y, prevPos.z, Block.air);
                    mapOn.Blockchange(newPos.x, newPos.y, newPos.z, GetColorBlock(color));

                    prevPos.x = newPos.x;
                    prevPos.y = newPos.y;
                    prevPos.z = newPos.z;

                    Thread.Sleep(50);
                }
                mapOn.Blockchange(prevPos.x, prevPos.y, prevPos.z, Block.air);

            })); carryThread.Start();

        }

        public void DropFlag(Player p, ushort x, ushort y, ushort z)
        {
            mapOn.ChatLevel(p.color + p.name + Server.DefaultColor + " has dropped the " + teamname + " flag!");
            hasFlag = null;
            p.holdingFlag = false;
            flagLocation[0] = x;
            flagLocation[1] = (ushort)(y - 1);
            flagLocation[2] = z;

            int i = mapOn.flags.FindIndex(flag => flag.team.color == this.color);
            mapOn.flags[i].x = x;
            mapOn.flags[i].y = (ushort)(y - 1);
            mapOn.flags[i].z = z;

            mapOn.Blockchange(x, (ushort)(y + 3), z, Block.air);
            mapOn.Blockchange(x, (ushort)(y - 1), z, Block.flagbase);
            mapOn.Blockchange(x, y, z, Block.mushroom);
            mapOn.Blockchange(x, (ushort)(y + 1), z, GetColorBlock(color));

        }
        public void CaptureFlag(Player p, Team winteam, Team loseteam)
        {

            mapOn.ChatLevel(p.color + p.name + Server.DefaultColor + " has captured the " + teamname + " flag!");
            hasFlag = null;
            p.holdingFlag = false;
            loseteam.flagishome = true;
            flagLocation[0] = flagBase[0];
            flagLocation[1] = flagBase[1];
            flagLocation[2] = flagBase[2];

            int i = mapOn.flags.FindIndex(flag => flag.team.color == this.color);
            mapOn.flags[i].x = flagBase[0];
            mapOn.flags[i].y = flagBase[1];
            mapOn.flags[i].z = flagBase[2];

            ushort x, y, z;
            x = flagBase[0];
            y = flagBase[1];
            z = flagBase[2];

            mapOn.Blockchange(((ushort)(p.pos[0] / 32)), ((ushort)((p.pos[1] / 32) + 2)), (ushort)(p.pos[2] / 32), Block.air);
            mapOn.Blockchange(x, y, z, Block.flagbase);
            mapOn.Blockchange(x, (ushort)(y + 1), z, Block.mushroom);
            mapOn.Blockchange(x, (ushort)(y + 2), z, GetColorBlock(color));

            winteam.points++;
            mapOn.ChatLevel("The " + winteam.teamname + " team" + Server.DefaultColor + " has scored! They now have " + winteam.points + " points!");
            if (winteam.points >= winteam.mapOn.maxroundpoints)
            {
                GameWin(winteam);
            }
        }

        public void ReturnFlag(Player p, Team teamFlag)
        {
            mapOn.ChatLevel(p.color + p.name + Server.DefaultColor + " has returned the " + teamname + Server.DefaultColor + " flag!");
            teamFlag.hasFlag = null;
            teamFlag.flagishome = true;
            teamFlag.flagLocation[0] = teamFlag.flagBase[0];
            teamFlag.flagLocation[1] = teamFlag.flagBase[1];
            teamFlag.flagLocation[2] = teamFlag.flagBase[2];

            int i = mapOn.flags.FindIndex(flag => flag.team.color == this.color);
            mapOn.flags[i].x = teamFlag.flagBase[0];
            mapOn.flags[i].y = teamFlag.flagBase[1];
            mapOn.flags[i].z = teamFlag.flagBase[2];

            ushort x, y, z;
            x = teamFlag.flagBase[0];
            y = teamFlag.flagBase[1];
            z = teamFlag.flagBase[2];

            mapOn.Blockchange(((ushort)(p.pos[0] / 32)), ((ushort)((p.pos[1] / 32))), (ushort)(p.pos[2] / 32), Block.air);
            mapOn.Blockchange(((ushort)(p.pos[0] / 32)), ((ushort)((p.pos[1] / 32) + 1)), (ushort)(p.pos[2] / 32), Block.air);
            mapOn.Blockchange(((ushort)(p.pos[0] / 32)), ((ushort)((p.pos[1] / 32) - 1)), (ushort)(p.pos[2] / 32), Block.air);

            mapOn.Blockchange(x, y, z, Block.flagbase);
            mapOn.Blockchange(x, (ushort)(y + 1), z, Block.mushroom);
            mapOn.Blockchange(x, (ushort)(y + 2), z, GetColorBlock(color));
        }

        public static byte GetColorBlock(char color)
        {
            if (color == '2')
                return Block.red;
            if (color == '5')
                return Block.purple;
            if (color == '8')
                return Block.darkgrey;
            if (color == '9')
                return Block.blue;
            if (color == 'c')
                return Block.red;
            if (color == 'e')
                return Block.yellow;
            if (color == 'f')
                return Block.white;
            else
                return Block.air;
        }

        public void EndRound()
        {
            points = 0;
            maxpoints = 0;
            flagLocation[0] = flagBase[0];
            flagLocation[1] = flagBase[1];
            flagLocation[2] = flagBase[2];
            flagishome = true;
            hasFlag = null;
        }

        public void GameWin(Team team)
        {
            team.mapOn.ChatLevel("The " + team.teamname + " team" + Server.DefaultColor + " has won the game!");
            team.mapOn.ctfmode = false;
            foreach (Team derp in mapOn.teams)
            {
                derp.EndRound();
            }
        }

        public void ResetRound()
        {

            onTeamCheck.Start();
            onTeamCheck.Elapsed += delegate
            {
                foreach (Player player in onTeam)
                {
                    if (!player.loggedIn || player.level != mapOn)
                    {
                        removePlayer(player);
                    }
                }
            };
            if (!spawnset)
            {
                spawn[0] = mapOn.spawnx;
                spawn[1] = mapOn.spawny;
                spawn[2] = mapOn.spawnz;
                spawn[3] = mapOn.rotx;
                spawn[4] = mapOn.roty;
            }
            foreach (Player player in onTeam)
            {
                ushort x1 = (ushort)((0.5 + spawn[0]) * 32);
                ushort y1 = (ushort)((1 + spawn[1]) * 32);
                ushort z1 = (ushort)((0.5 + spawn[2]) * 32);
                unchecked
                {
                    player.SendSpawn((byte)-1, player.name, x1, y1, z1, (byte)spawn[3], (byte)spawn[4]);
                    player.SendPos((byte)-1, x1, y1, z1, (byte)spawn[3], (byte)spawn[4]);
                    player.inCtf = true;
                }
            }
            points = 0;

            Thread flagThread = new Thread(new ThreadStart(delegate
            {
                while (!flagishome)
                {
                    if (!mapOn.ctfmode) goto exit;

                    if (hasFlag == null)
                    {
                        ushort x = flagLocation[0];
                        ushort y = flagLocation[1];
                        ushort z = flagLocation[2];
                        mapOn.Blockchange(x, y, z, Block.flagbase);
                        mapOn.Blockchange(x, (ushort)(y + 1), z, Block.mushroom);
                        mapOn.Blockchange(x, (ushort)(y + 2), z, GetColorBlock(color));

                        Thread.Sleep(200);
                    }
                }
                while (flagishome)
                {
                    if (!mapOn.ctfmode) goto exit;

                    ushort x = flagBase[0];
                    ushort y = flagBase[1];
                    ushort z = flagBase[2];
                    mapOn.Blockchange(x, y, z, Block.flagbase);
                    mapOn.Blockchange(x, (ushort)(y + 1), z, Block.mushroom);
                    mapOn.Blockchange(x, (ushort)(y + 2), z, GetColorBlock(color));

                    Thread.Sleep(200);
                }
            exit: ;
            })); flagThread.Start();
        }

        public struct CatchPos { public ushort x, y, z; public byte type;}
    }
}