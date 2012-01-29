using System;

namespace MCLawl.Commands
{
    class CmdPlace : Command
    {
        public override string name { get { return "place"; } }
        public override string shortcut { get { return "pl"; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdPlace() { }

        public override void Use(Player p, string message)
        {
            byte b = Block.Zero;
            ushort x = 0; ushort y = 0; ushort z = 0;

            x = (ushort)(p.pos[0] / 32);
            y = (ushort)((p.pos[1] / 32) - 1);
            z = (ushort)(p.pos[2] / 32);

            try
            {
                switch (message.Split(' ').Length)
                {
                    case 0: b = Block.rock; break;
                    case 1: b = Block.Byte(message); break;
                    case 3:
                        x = Convert.ToUInt16(message.Split(' ')[0]);
                        y = Convert.ToUInt16(message.Split(' ')[1]);
                        z = Convert.ToUInt16(message.Split(' ')[2]);
                        break;
                    case 4:
                        b = Block.Byte(message.Split(' ')[0]);
                        x = Convert.ToUInt16(message.Split(' ')[1]);
                        y = Convert.ToUInt16(message.Split(' ')[2]);
                        z = Convert.ToUInt16(message.Split(' ')[3]);
                        break;
                    default: Player.SendMessage(p, "Invalid parameters"); return;
                }
            }
            catch { Player.SendMessage(p, "Invalid parameters"); return; }

            if (b == Block.Zero) b = (byte)1;
            if (!Block.canPlace(p, b)) { Player.SendMessage(p, "Cannot place that block type."); return; }

            Level level = p.level;

            if (y >= p.level.depth) y = (ushort)(p.level.depth - 1);

            p.level.Blockchange(p, x, y, z, b);
            Player.SendMessage(p, "A block was placed at (" + x + ", " + y + ", " + z + ").");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/place [block] <x y z> - Places block at your feet or <x y z>");
        }
    }
}
