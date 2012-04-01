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
    public class CmdViewRanks : Command
    {
        public override string name { get { return "viewranks"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdViewRanks() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }

            Group foundGroup = Group.Find(message);
            if (foundGroup == null)
            {
                Player.SendMessage(p, "Could not find group");
                return;
            }


            string totalList = "";
            foreach (string s in foundGroup.playerList.All())
            {
                totalList += ", " + s;
            }

            if (totalList == "")
            {
                Player.SendMessage(p, "No one has the rank of " + foundGroup.color + foundGroup.name);
                return;
            }
            
            Player.SendMessage(p, "People with the rank of " + foundGroup.color + foundGroup.name + ":");
            Player.SendMessage(p, totalList.Remove(0, 2));
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/viewranks [rank] - Shows all users who have [rank]");
            Player.SendMessage(p, "Available ranks: " + Group.concatList());
        }
    }
}
