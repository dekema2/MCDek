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

namespace MCLawl
{
    public class CmdTrust : Command
    {
        public override string name { get { return "trust"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "moderation"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdTrust() { }

        public override void Use(Player p, string message)
        {
            if (message == "" || message.IndexOf(' ') != -1) { Help(p); return; }

            Player who = Player.Find(message);
            if (who == null)
            {
                Player.SendMessage(p, "Could not find player specified");
                return;
            }
            else
            {
                who.ignoreGrief = !who.ignoreGrief;
                Player.SendMessage(p, who.color + who.name + Server.DefaultColor + "'s trust status: " + who.ignoreGrief);
                who.SendMessage("Your trust status was changed to: " + who.ignoreGrief);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/trust <name> - Turns off the anti-grief for <name>");
        }
    }
}