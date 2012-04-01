using System;
using System.Collections.Generic;
using MCDek;
namespace MCLawl
{
    public class CmdHollow : Command
    {
        public override string name { get { return "hollow"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdHollow() { }

        public override void Use(Player p, string message)
        {
            CatchPos cpos;
            if (message != "")
                if (Block.Byte(message.ToLower()) == Block.Zero) { Player.SendMessage(p, "Cannot find block entered."); return; }

            if (message != "")
            {
                cpos.countOther = Block.Byte(message.ToLower());
            }
            else
            {
                cpos.countOther = Block.Zero;
            }

            cpos.x = 0; cpos.y = 0; cpos.z = 0; p.blockchangeObject = cpos;
            Player.SendMessage(p, "Place two blocks to determine the edges.");
            p.ClearBlockchange();
            p.Blockchange += new Player.BlockchangeEventHandler(Blockchange1);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/hollow - Hollows out an area without flooding it");
            Player.SendMessage(p, "/hollow [block] - Hollows around [block]");
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
            Pos pos;

            bool AddMe = false;

            for (ushort xx = Math.Min(cpos.x, x); xx <= Math.Max(cpos.x, x); ++xx)
                for (ushort yy = Math.Min(cpos.y, y); yy <= Math.Max(cpos.y, y); ++yy)
                    for (ushort zz = Math.Min(cpos.z, z); zz <= Math.Max(cpos.z, z); ++zz)
                    {
                        AddMe = true;

                        if (!Block.RightClick(Block.Convert(p.level.GetTile(xx, yy, zz)), true) && p.level.GetTile(xx, yy, zz) != cpos.countOther)
                        {
                            if (Block.RightClick(Block.Convert(p.level.GetTile((ushort)(xx - 1), yy, zz))) || p.level.GetTile((ushort)(xx - 1), yy, zz) == cpos.countOther) AddMe = false;
                            else if (Block.RightClick(Block.Convert(p.level.GetTile((ushort)(xx + 1), yy, zz))) || p.level.GetTile((ushort)(xx + 1), yy, zz) == cpos.countOther) AddMe = false;
                            else if (Block.RightClick(Block.Convert(p.level.GetTile(xx, (ushort)(yy - 1), zz))) || p.level.GetTile(xx, (ushort)(yy - 1), zz) == cpos.countOther) AddMe = false;
                            else if (Block.RightClick(Block.Convert(p.level.GetTile(xx, (ushort)(yy + 1), zz))) || p.level.GetTile(xx, (ushort)(yy + 1), zz) == cpos.countOther) AddMe = false;
                            else if (Block.RightClick(Block.Convert(p.level.GetTile(xx, yy, (ushort)(zz - 1)))) || p.level.GetTile(xx, yy, (ushort)(zz - 1)) == cpos.countOther) AddMe = false;
                            else if (Block.RightClick(Block.Convert(p.level.GetTile(xx, yy, (ushort)(zz + 1)))) || p.level.GetTile(xx, yy, (ushort)(zz + 1)) == cpos.countOther) AddMe = false;
                        }
                        else AddMe = false;

                        if (AddMe) { pos.x = xx; pos.y = yy; pos.z = zz; buffer.Add(pos); }
                    }

            if (buffer.Count > p.group.maxBlocks)
            {
                Player.SendMessage(p, "You tried to hollow more than " + buffer.Count + " blocks.");
                Player.SendMessage(p, "You cannot hollow more than " + p.group.maxBlocks + ".");
                return;
            }

            buffer.ForEach(delegate(Pos pos1)
            {
                p.level.Blockchange(p, pos1.x, pos1.y, pos1.z, Block.air);
            });

            Player.SendMessage(p, "You hollowed " + buffer.Count + " blocks.");

            if (p.staticCommands) p.Blockchange += new Player.BlockchangeEventHandler(Blockchange1);
        }
        void BufferAdd(List<Pos> list, ushort x, ushort y, ushort z)
        {
            Pos pos; pos.x = x; pos.y = y; pos.z = z; list.Add(pos);
        }

        struct Pos
        {
            public ushort x, y, z;
        }
        struct CatchPos
        {
            public ushort x, y, z; public byte countOther;
        }

    }
}
