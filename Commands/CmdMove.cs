using System;

namespace MCLawl
{
    public class CmdMove : Command
    {
        public override string name { get { return "move"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdMove() { }

        public override void Use(Player p, string message)
        {
            // /move name map
            // /move x y z
            // /move name x y z

            if (message.Split(' ').Length < 2 || message.Split(' ').Length > 4) { Help(p); return; }

            if (message.Split(' ').Length == 2)     // /move name map
            {
                Player who = Player.Find(message.Split(' ')[0]);
                Level where = Level.Find(message.Split(' ')[1]);
                if (who == null) { Player.SendMessage(p, "Could not find player specified"); return; }
                if (where == null) { Player.SendMessage(p, "Could not find level specified"); return; }
                if (p != null && who.group.Permission > p.group.Permission) { Player.SendMessage(p, "Cannot move someone of greater rank"); return; }

                Command.all.Find("goto").Use(who, where.name);
                if (who.level == where)
                    Player.SendMessage(p, "Sent " + who.color + who.name + Server.DefaultColor + " to " + where.name);
                else
                    Player.SendMessage(p, where.name + " is not loaded");
            }
            else
            {
                // /move name x y z
                // /move x y z

                Player who;

                if (message.Split(' ').Length == 4)
                {
                    who = Player.Find(message.Split(' ')[0]);
                    if (who == null) { Player.SendMessage(p, "Could not find player specified"); return; }
                    if (p != null && who.group.Permission > p.group.Permission) { Player.SendMessage(p, "Cannot move someone of greater rank"); return; }
                    message = message.Substring(message.IndexOf(' ') + 1);
                }
                else
                {
                    who = p;
                }

                try
                {
                    ushort x = System.Convert.ToUInt16(message.Split(' ')[0]);
                    ushort y = System.Convert.ToUInt16(message.Split(' ')[1]);
                    ushort z = System.Convert.ToUInt16(message.Split(' ')[2]);
                    x *= 32; x += 16;
                    y *= 32; y += 32;
                    z *= 32; z += 16;
                    unchecked { who.SendPos((byte)-1, x, y, z, p.rot[0], p.rot[1]); }
                    if (p != who) Player.SendMessage(p, "Moved " + who.color + who.name);
                }
                catch { Player.SendMessage(p, "Invalid co-ordinates"); }
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/move <player> <map> <x> <y> <z> - Move <player>");
            Player.SendMessage(p, "<map> must be blank if x, y or z is used and vice versa");
        }
    }
}