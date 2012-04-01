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
using MCDek;
namespace MCLawl
{
    public class CmdPromote : Command
    {
        public override string name { get { return "promote"; } }
        public override string shortcut { get { return "pr"; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdPromote() { }

        public override void Use(Player p, string message)
        {
            if (message == "" || message.IndexOf(' ') != -1) { Help(p); return; }
            Player who = Player.Find(message);
            string foundName;
            Group foundGroup;
            if (who == null)
            {
                foundName = message;
                foundGroup = Group.findPlayerGroup(message);
            }
            else
            {
                foundName = who.name;
                foundGroup = who.group;
            }

            Group nextGroup = null; bool nextOne = false;
            for (int i = 0; i < Group.GroupList.Count; i++)
            {
                Group grp = Group.GroupList[i];
                if (nextOne)
                {
                    if (grp.Permission >= LevelPermission.Nobody) break;
                    nextGroup = grp;
                    break;
                }
                if (grp == foundGroup)
                    nextOne = true;
            }

            if (nextGroup != null)
                Command.all.Find("setrank").Use(p, foundName + " " + nextGroup.name);
            else
                Player.SendMessage(p, "No higher ranks exist");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/promote <name> - Promotes <name> up a rank");
        }
    }
}