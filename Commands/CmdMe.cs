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
    public class CmdMe : Command
    {
        public override string name { get { return "me"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdMe() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Player.SendMessage(p, "You"); return; }

            if (p.muted) { Player.SendMessage(p, "You are currently muted and cannot use this command."); return; }
            if (Server.chatmod && !p.voice) { Player.SendMessage(p, "Chat moderation is on, you cannot emote."); return; }

            if (Server.worldChat)
            {
                Player.GlobalChat(p, p.color + "*" + p.name + " " + message, false);
            }
            else
            {
                Player.GlobalChatLevel(p, p.color + "*" + p.name + " " + message, false);
            }
            IRCBot.Say("*" + p.name + " " + message);


        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "What do you need help with, m'boy?! Are you stuck down a well?!");
        }
    }
}