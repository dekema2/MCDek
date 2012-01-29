using System;
using System.IO;

namespace MCLawl
{
    public class CmdTree : Command
    {
        public override string name { get { return "tree"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdTree() { }

        public override void Use(Player p, string message)
        {
            p.ClearBlockchange();
            switch (message.ToLower())
            {
                case "2":
                case "cactus": p.Blockchange += new Player.BlockchangeEventHandler(AddCactus); break;
                default: p.Blockchange += new Player.BlockchangeEventHandler(AddTree); break;
            }
            Player.SendMessage(p, "Select where you wish your tree to grow");
            p.painting = false;
        }

        void AddTree(Player p, ushort x, ushort y, ushort z, byte type)
        {
            Random Rand = new Random();

            byte height = (byte)Rand.Next(5, 8);
            for (ushort yy = 0; yy < height; yy++) p.level.Blockchange(p, x, (ushort)(y + yy), z, Block.trunk);

            short top = (short)(height - Rand.Next(2, 4));

            for (short xx = (short)-top; xx <= top; ++xx)
            {
                for (short yy = (short)-top; yy <= top; ++yy)
                {
                    for (short zz = (short)-top; zz <= top; ++zz)
                    {
                        short Dist = (short)(Math.Sqrt(xx * xx + yy * yy + zz * zz));
                        if (Dist < top + 1)
                        {
                            if (Rand.Next((int)(Dist)) < 2)
                            {
                                try
                                {
                                    p.level.Blockchange(p, (ushort)(x + xx), (ushort)(y + yy + height), (ushort)(z + zz), Block.leaf);
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            if (!p.staticCommands) p.ClearBlockchange();
        }
        void AddCactus(Player p, ushort x, ushort y, ushort z, byte type)
        {
            Random Rand = new Random();

            byte height = (byte)Rand.Next(3, 6);
            ushort yy;

            for (yy = 0; yy <= height; yy++) p.level.Blockchange(p, x, (ushort)(y + yy), z, Block.green);

            int inX = 0, inZ = 0;

            switch (Rand.Next(1, 3))
            {
                case 1: inX = -1; break;
                case 2:
                default: inZ = -1; break;
            }

            for (yy = height; yy <= Rand.Next(height + 2, height + 5); yy++) p.level.Blockchange(p, (ushort)(x + inX), (ushort)(y + yy), (ushort)(z + inZ), Block.green);
            for (yy = height; yy <= Rand.Next(height + 2, height + 5); yy++) p.level.Blockchange(p, (ushort)(x - inX), (ushort)(y + yy), (ushort)(z - inZ), Block.green);

            if (!p.staticCommands) p.ClearBlockchange();
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/tree [type] - Turns tree mode on or off.");
            Player.SendMessage(p, "Types - (Fern | 1), (Cactus | 2)");
        }
    }
}