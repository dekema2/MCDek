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
using System.Collections.Generic;
using System.Text;
using MCDek;
namespace MCLawl
{
    class CmdNewLvl : Command
    {
        public override string name { get { return "newlvl"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdNewLvl() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }

            string[] parameters = message.Split(' '); // Grab the parameters from the player's message
            if (parameters.Length == 5) // make sure there are 5 params
            {
                switch (parameters[4])
                {
                    case "flat":
                    case "pixel":
                    case "island":
                    case "mountains":
                    case "ocean":
                    case "forest":
                    case "desert":
                        break;

                    default:
                        Player.SendMessage(p, "Valid types: island, mountains, forest, ocean, flat, pixel, desert"); return;
                }

                string name = parameters[0].ToLower();
                ushort x = 1, y = 1, z = 1;
                try
                {
                    x = Convert.ToUInt16(parameters[1]);
                    y = Convert.ToUInt16(parameters[2]);
                    z = Convert.ToUInt16(parameters[3]);
                }
                catch { Player.SendMessage(p, "Invalid dimensions."); return; }
                if (!isGood(x)) { Player.SendMessage(p, x + " is not a good dimension! Use a power of 2 next time."); }
                if (!isGood(y)) { Player.SendMessage(p, y + " is not a good dimension! Use a power of 2 next time."); }
                if (!isGood(z)) { Player.SendMessage(p, z + " is not a good dimension! Use a power of 2 next time."); }

                if (!Player.ValidName(name)) { Player.SendMessage(p, "Invalid name!"); return; }

                try
                {
                    if (p != null)
                    if (p.group.Permission < LevelPermission.Admin)
                    {
                        if (x * y * z > 30000000) { Player.SendMessage(p, "Cannot create a map with over 30million blocks"); return; }
                    }
                    else
                    {
                        if (x * y * z > 225000000) { Player.SendMessage(p, "You cannot make a map with over 225million blocks"); return; }
                    }
                }
                catch 
                { 
                    Player.SendMessage(p, "An error occured"); 
                }

                // create a new level...
                try
                {
                    Level lvl = new Level(name, x, y, z, parameters[4]);
                    lvl.Save(true); //... and save it.
                }
                finally
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                Player.GlobalMessage("Level " + name + " created"); // The player needs some form of confirmation.
            }
            else
                Help(p);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/newlvl - creates a new level.");
            Player.SendMessage(p, "/newlvl mapname 128 64 128 type");
            Player.SendMessage(p, "Valid types: island, mountains, forest, ocean, flat, pixel, desert");
        }

        public bool isGood(ushort value)
        {
            switch (value)
            {
                case 2:
                case 4:
                case 8:
                case 16:
                case 32:
                case 64:
                case 128:
                case 256:
                case 512:
                case 1024:
                case 2048:
                case 4096:
                case 8192:
                    return true;
            }

            return false;
        }
    }
}
