/*
	Copyright 2010 MCLawl Team - Written by Valek
 
    Licensed under the
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
using System.Data;
using System.IO;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;
using MCDek;
namespace MCLawl
{
    class CmdPCount : Command
    {
        public override string name { get { return "pcount"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdPCount() { }

        public override void Use(Player p, string message)
        {
            int bancount = Group.findPerm(LevelPermission.Banned).playerList.All().Count;

            DataTable count = MySQL.fillData("SELECT COUNT(id) FROM players");
            Player.SendMessage(p, "A total of " + count.Rows[0]["COUNT(id)"] + " unique players have visited this server.");
            Player.SendMessage(p, "Of these players, " + bancount + " have been banned.");
            count.Dispose();

            int playerCount = 0;
            int hiddenCount = 0;
           
            foreach (Player pl in Player.players)
            {
                if (!pl.hidden || p.group.Permission > LevelPermission.AdvBuilder || Server.Devs.Contains(p.name.ToLower()))
                {
                    playerCount++;
                    if (pl.hidden && (p.group.Permission > LevelPermission.AdvBuilder || Server.Devs.Contains(p.name.ToLower())))
                    {
                        hiddenCount++;
                    }
                }
            }
            if (playerCount == 1)
            {
                if (hiddenCount == 0)
                {
                    Player.SendMessage(p, "There is 1 player currently online.");
                }
                else
                {
                    Player.SendMessage(p, "There is 1 player currently online (" + hiddenCount + " hidden).");
                }
            }
            else
            {
                if (hiddenCount == 0)
                {
                    Player.SendMessage(p, "There are " + playerCount + " players online.");
                }
                else
                {
                    Player.SendMessage(p, "There are " + playerCount + " players online (" + hiddenCount + " hidden).");
                }
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/pcount - Displays the number of players online and total.");
        }
    }
}
