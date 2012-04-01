using System;
using MCDek;

namespace MCLawl
{
    class CmdDetonate : Command
    {
        public override string name { get { return "detonate"; } }
        public override string shortcut { get { return "dt"; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdDetonate() { }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/detonate - Blows up what ever you want :)");
            Player.SendMessage(p, "/detonate me - Blows up yourself at your location");
            Player.SendMessage(p, "/detonate [Player] - Takes out your worst enemies :D ");
            Player.SendMessage(p, "/detonate [X] [Y] [Z] - Detonation at the co-ordinates of your choice!");

        }
        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            int number = message.Split(' ').Length;
            if (number > 3) { Player.SendMessage(p, "What?"); return; }
            if (message == "me")
            {
                if (p.level.physics < 3)
                {
                    Player.SendMessage(p, "This level does not have high enough physics!");
                    return;
                }
                Command.all.Find("detonate").Use(p, p.name);
                return;
            }
            if (number == 1)
            {
                if (p != null)
                {
                    if (p.level.physics < 3)
                    {
                        Player.SendMessage(p, "This level does not have high enough physics!");
                        return;
                    }
                    Player who = Player.Find(message);
                    ushort x = (ushort)(who.pos[0] / 32);
                    ushort y = (ushort)(who.pos[1] / 32);
                    ushort z = (ushort)(who.pos[2] / 32);
                    p.level.MakeExplosion(x, y, z, 1);
                    Player.SendMessage(p, who.color + who.name + Server.DefaultColor + " has been incinerated!");
                    return;
                }
                Player.SendMessage(p, "That player is not online");
                return;
            }
            if (number == 3)
            {
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
                            default: Player.SendMessage(p, "Invalid co-ordinates"); return;
                        }
                    }
                    catch { Player.SendMessage(p, "Invalid co-ordinates"); return; }

                    Level level = p.level;

                    if (y >= p.level.depth) y = (ushort)(p.level.depth - 1);

                    if (p.level.physics < 3)
                    {
                        Player.SendMessage(p, "This level does not have high enough physics!");
                        return;
                    }
                    p.level.MakeExplosion(x, y, z, 1);
                    Player.SendMessage(p, "(" + x + ", " + y + ", " + z + ") was just eradicated.");
                }
            }
        }
    }
}