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
    class CmdResetBot : Command
    {
        public override string name { get { return "resetbot"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdResetBot() { }

        public override void Use(Player p, string message)
        {
            IRCBot.Reset();
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/resetbot - reloads the IRCBot. FOR EMERGENCIES ONLY!");
        }
    }
}
