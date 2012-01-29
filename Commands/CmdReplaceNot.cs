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

namespace MCLawl
{
    public class CmdReplaceNot : Command
    {
        public override string name { get { return "replacenot"; } }
        public override string shortcut { get { return "rn"; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public CmdReplaceNot() { }

        public override void Use(Player p, string message)
        {
            int number = message.Split(' ').Length;
            CatchPos cpos = new CatchPos(); byte btype;
            if (number < 2) { Help(p); return; }

            btype = Block.Byte(message.Split(' ')[0]);
            if (btype == 255) { Player.SendMessage(p, message.Split(' ')[0] + " does not exist, please spell it correctly."); return; }

            cpos.type = btype;

            if (Block.Byte(message.Split(' ')[1]) == 255) { Player.SendMessage(p, message.Split(' ')[1] + " does not exist, please spell it correctly."); return; }

            cpos.type2 = Block.Byte(message.Split(' ')[1]);
            if (!Block.canPlace(p, cpos.type2)) { Player.SendMessage(p, "Cannot place this block type!"); return; }

            cpos.x = 0; cpos.y = 0; cpos.z = 0; p.blockchangeObject = cpos;
            Player.SendMessage(p, "Place two blocks to determine the edges.");
            p.ClearBlockchange();
            p.Blockchange += new Player.BlockchangeEventHandler(Blockchange1);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/rn [type] [type2] - replace everything but the type with type2 inside a selected cuboid");
        }
        public void Blockchange1(Player p, ushort x, ushort y, ushort z, byte type)
        {
            p.ClearBlockchange();
            byte b = p.level.GetTile(x, y, z);
            p.SendBlockchange(x, y, z, b);
            CatchPos bp = (CatchPos)p.blockchangeObject;
            bp.x = x; bp.y = y; bp.z = z; p.blockchangeObject = bp;
            p.Blockchange += new Player.BlockchangeEventHandler(Blockchange2);
        }
        public void Blockchange2(Player p, ushort x, ushort y, ushort z, byte type)
        {
            p.ClearBlockchange();
            byte b = p.level.GetTile(x, y, z);
            p.SendBlockchange(x, y, z, b);
            CatchPos cpos = (CatchPos)p.blockchangeObject;
            List<Pos> buffer = new List<Pos>();

            for (ushort xx = Math.Min(cpos.x, x); xx <= Math.Max(cpos.x, x); ++xx)
            {
                for (ushort yy = Math.Min(cpos.y, y); yy <= Math.Max(cpos.y, y); ++yy)
                {
                    for (ushort zz = Math.Min(cpos.z, z); zz <= Math.Max(cpos.z, z); ++zz)
                    {
                        if (p.level.GetTile(xx, yy, zz) != cpos.type) { BufferAdd(buffer, xx, yy, zz); }
                    }
                }
            }

            if (buffer.Count > p.group.maxBlocks)
            {
                Player.SendMessage(p, "You tried to replace " + buffer.Count + " blocks.");
                Player.SendMessage(p, "You cannot replace more than " + p.group.maxBlocks + ".");
                return;
            }

            Player.SendMessage(p, buffer.Count.ToString() + " blocks.");

            buffer.ForEach(delegate(Pos pos)
            {
                p.level.Blockchange(p, pos.x, pos.y, pos.z, cpos.type2);                  //update block for everyone
            });

            if (p.staticCommands) p.Blockchange += new Player.BlockchangeEventHandler(Blockchange1);
        }
        void BufferAdd(List<Pos> list, ushort x, ushort y, ushort z)
        {
            Pos pos; pos.x = x; pos.y = y; pos.z = z; list.Add(pos);
        }

        struct Pos { public ushort x, y, z; }
        struct CatchPos
        {
            public byte type;
            public byte type2;
            public ushort x, y, z;
        }

    }
}
