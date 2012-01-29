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
    public class CmdPaint : Command
    {
        public override string name { get { return "paint"; } }
        public override string shortcut { get { return "p"; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdPaint() { }

        public override void Use(Player p, string message)
        {
            if (message != "") { Help(p); return; }
            p.painting = !p.painting; if (p.painting) { Player.SendMessage(p, "Painting mode: &aON" + Server.DefaultColor + "."); }
            else { Player.SendMessage(p, "Painting mode: &cOFF" + Server.DefaultColor + "."); }
            p.BlockAction = 0;
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/paint - Turns painting mode on/off.");
        }
    }
}