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
using System.Data;
using System.Collections.Generic;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;

namespace MCLawl
{
    public class CmdAbout : Command
    {
        public override string name { get { return "about"; } }
        public override string shortcut { get { return "b"; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdAbout() { }

        public override void Use(Player p, string message)
        {
            Player.SendMessage(p, "Break/build a block to display information.");
            p.ClearBlockchange();
            p.Blockchange += new Player.BlockchangeEventHandler(AboutBlockchange);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/about - Displays information about a block.");
        }

        public void AboutBlockchange(Player p, ushort x, ushort y, ushort z, byte type)
        {
            if (!p.staticCommands) p.ClearBlockchange();
            byte b = p.level.GetTile(x, y, z);
            if (b == Block.Zero) { Player.SendMessage(p, "Invalid Block(" + x + "," + y + "," + z + ")!"); return; }
            p.SendBlockchange(x, y, z, b);

            string message = "Block (" + x + "," + y + "," + z + "): ";
            message += "&f" + b + " = " + Block.Name(b);
            Player.SendMessage(p, message + Server.DefaultColor + ".");
            message = p.level.foundInfo(x, y, z);
            if (message != "") Player.SendMessage(p, "Physics information: &a" + message);

            DataTable Blocks = MySQL.fillData("SELECT * FROM `Block" + p.level.name + "` WHERE X=" + (int)x + " AND Y=" + (int)y + " AND Z=" + (int)z);

            string Username, TimePerformed, BlockUsed;
            bool Deleted, foundOne = false;

            for (int i = 0; i < Blocks.Rows.Count; i++)
            {
                foundOne = true;
                Username = Blocks.Rows[i]["Username"].ToString();
                TimePerformed = DateTime.Parse(Blocks.Rows[i]["TimePerformed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                BlockUsed = Block.Name((byte)Blocks.Rows[i]["Type"]).ToString();
                Deleted = (bool)Blocks.Rows[i]["Deleted"];

                if (!Deleted)
                    Player.SendMessage(p, "&3Created by " + Server.FindColor(Username.Trim()) + Username.Trim() + Server.DefaultColor + ", using &3" + BlockUsed);
                else
                    Player.SendMessage(p, "&4Destroyed by " + Server.FindColor(Username.Trim()) + Username.Trim() + Server.DefaultColor + ", using &3" + BlockUsed);
                Player.SendMessage(p, "Date and time modified: &2" + TimePerformed);
            }

            List<Level.BlockPos> inCache = p.level.blockCache.FindAll(bP => bP.x == x && bP.y == y && bP.z == z);

            for (int i = 0; i < inCache.Count; i++)
            {
                foundOne = true;
                Deleted = inCache[i].deleted;
                Username = inCache[i].name;
                TimePerformed = inCache[i].TimePerformed.ToString("yyyy-MM-dd HH:mm:ss");
                BlockUsed = Block.Name(inCache[i].type);

                if (!Deleted)
                    Player.SendMessage(p, "&3Created by " + Server.FindColor(Username.Trim()) + Username.Trim() + Server.DefaultColor + ", using &3" + BlockUsed);
                else
                    Player.SendMessage(p, "&4Destroyed by " + Server.FindColor(Username.Trim()) + Username.Trim() + Server.DefaultColor + ", using &3" + BlockUsed);
                Player.SendMessage(p, "Date and time modified: &2" + TimePerformed);
            }

            if (!foundOne)
                Player.SendMessage(p, "This block has not been modified since the map was cleared.");
 
            Blocks.Dispose();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}