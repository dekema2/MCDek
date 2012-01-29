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
using System.IO;

namespace MCLawl
{
    public class CmdBotAdd : Command
    {
        public override string name { get { return "botadd"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdBotAdd() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            if (!PlayerBot.ValidName(message)) { Player.SendMessage(p, "bot name " + message + " not valid!"); return; }
            PlayerBot.playerbots.Add(new PlayerBot(message, p.level, p.pos[0], p.pos[1], p.pos[2], p.rot[0], 0));
            //who.SendMessage("You were summoned by " + p.color + p.name + "&e.");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/botadd <name> - Add a  new bot at your position.");
        }
    }
}