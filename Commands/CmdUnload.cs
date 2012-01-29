/*
	Copyright 2010 MCSharp team (Modified for use with MCZall/MCLawl) under the
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
using System.Collections.Generic;

namespace MCLawl
{
    public class CmdUnload : Command
    {
        public override string name { get { return "unload"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdUnload() { }

        public override void Use(Player p, string message)
        {
            if (message.ToLower() == "empty")
            {
                Boolean Empty = true;

                foreach (Level l in Server.levels)
                {
                    Empty = true;
                    Player.players.ForEach(delegate(Player pl)
                    {
                        if (pl.level == l) Empty = false;
                    });

                    if (Empty == true && l.unload)
                    {
                        l.Unload();
                        return;
                    }
                }
                Player.SendMessage(p, "No levels were empty.");
                return;
            }

            Level level = Level.Find(message);

            if (level != null)
            {
                if (!level.Unload()) Player.SendMessage(p, "You cannot unload the main level.");
                return;
            }

            Player.SendMessage(p, "There is no level \"" + message + "\" loaded.");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/unload [level] - Unloads a level.");
            Player.SendMessage(p, "/unload empty - Unloads an empty level.");
        }
    }
}