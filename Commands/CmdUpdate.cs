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
using System.Net;
using System.Threading;

namespace MCLawl
{
    public class CmdUpdate : Command
    {
        public override string name { get { return "update"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public CmdUpdate() { }

        public override void Use(Player p, string message)
        {
            if (p == null || p.group.Permission > LevelPermission.AdvBuilder) MCLawl_.Gui.Program.UpdateCheck(false, p);
            else Player.SendMessage(p, "Ask an Operator to do it!");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/update - Updates the server if it's out of date");
        }
    }
}