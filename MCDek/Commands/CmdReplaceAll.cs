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
    class CmdReplaceAll : Command
    {
        public override string name { get { return "replaceall"; } }
        public override string shortcut { get { return "ra"; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdReplaceAll() { }

        public override void Use(Player p, string message)
        {
            if (message.IndexOf(' ') == -1 || message.Split(' ').Length > 2) { Help(p); return; }

            byte b1, b2;

            b1 = Block.Byte(message.Split(' ')[0]);
            b2 = Block.Byte(message.Split(' ')[1]);

            if (b1 == Block.Zero || b2 == Block.Zero) { Player.SendMessage(p, "Could not find specified blocks."); return; }
            ushort x, y, z; int currentBlock = 0;
            List<Pos> stored = new List<Pos>(); Pos pos;

            foreach (byte b in p.level.blocks)
            {
                if (b == b1)
                {
                    p.level.IntToPos(currentBlock, out x, out y, out z);
                    pos.x = x; pos.y = y; pos.z = z;
                    stored.Add(pos);
                }
                currentBlock++;
            }

            if (stored.Count > (p.group.maxBlocks * 2)) { Player.SendMessage(p, "Cannot replace more than " + (p.group.maxBlocks * 2) + " blocks."); return; }

            Player.SendMessage(p, stored.Count + " blocks out of " + currentBlock + " are " + Block.Name(b1));

            foreach (Pos Pos in stored)
            {
                p.level.Blockchange(p, Pos.x, Pos.y, Pos.z, b2);
            }

            Player.SendMessage(p, "&4/replaceall finished!");
        }
        public struct Pos { public ushort x, y, z; }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/replaceall [block1] [block2] - Replaces all of [block1] with [block2] in a map");
        }
    }
}
