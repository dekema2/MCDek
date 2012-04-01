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
using MCDek;
namespace MCLawl
{
    public class CmdTColor : Command
    {
        public override string name { get { return "tcolor"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdTColor() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            string[] args = message.Split(' ');
            Player who = Player.Find(args[0]);
            if (who == null)
            {
                Player.SendMessage(p, "Could not find player.");
                return;
            }
            if (args.Length == 1)
            {
                who.titlecolor = "";
                Player.GlobalChat(who, who.color + who.name + Server.DefaultColor + " had their title color removed.", false);
                MySQL.executeQuery("UPDATE Players SET title_color = '' WHERE Name = '" + who.name + "'");
                who.SetPrefix();
                return;
            }
            else
            {
                string color = c.Parse(args[1]);
                if (color == "") { Player.SendMessage(p, "There is no color \"" + args[1] + "\"."); return; }
                else if (color == who.titlecolor) { Player.SendMessage(p, who.name + " already has that title color."); return; }
                else
                {
                    MySQL.executeQuery("UPDATE Players SET title_color = '" + c.Name(color) + "' WHERE Name = '" + who.name + "'");
                    Player.GlobalChat(who, who.color + who.name + Server.DefaultColor + " had their title color changed to " + color + c.Name(color) + Server.DefaultColor + ".", false);
                    who.titlecolor = color;
                    who.SetPrefix();
                }
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/tcolor <player> [color] - Gives <player> the title color of [color].");
            Player.SendMessage(p, "If no [color] is specified, title color is removed.");
            Player.SendMessage(p, "&0black &1navy &2green &3teal &4maroon &5purple &6gold &7silver");
            Player.SendMessage(p, "&8gray &9blue &alime &baqua &cred &dpink &eyellow &fwhite");
        }
    }
}
