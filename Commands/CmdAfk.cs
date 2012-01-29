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

namespace MCLawl
{
    class CmdAfk : Command
    {
        public override string name { get { return "afk"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdAfk() { }

        public override void Use(Player p, string message)
        {
            if (message != "list")
            {
                if (p.joker)
                {
                    message = "";
                }
                if (!Server.afkset.Contains(p.name))
                {
                    Server.afkset.Add(p.name);
                    if (p.muted)
                    {
                        message = "";
                    }
                    Player.GlobalMessage("-" + p.color + p.name + Server.DefaultColor + "- is AFK " + message);
                    IRCBot.Say(p.name + " is AFK " + message);
                    return;

                }
                else
                {
                    Server.afkset.Remove(p.name);
                    Player.GlobalMessage("-" + p.color + p.name + Server.DefaultColor + "- is no longer AFK");
                    IRCBot.Say(p.name + " is no longer AFK");
                    return;
                }
            }
            else
            {
                foreach (string s in Server.afkset) Player.SendMessage(p, s);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/afk <reason> - mark yourself as AFK. Use again to mark yourself as back");
        }
    }
}
