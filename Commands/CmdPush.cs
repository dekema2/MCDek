using System;
using MCDek;
namespace MCLawl
{
    public class CmdPush : Command
    {
        public override string name { get { return "push"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdPush() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }

            Player who = Player.Find(message);

            if (who == null)
            {
                Player.SendMessage(p, "Could not find player specified");
                return;
            }

            ushort currentX = (ushort)(who.pos[0] / 32);
            ushort currentY = (ushort)(who.pos[1] / 32);
            ushort currentZ = (ushort)(who.pos[2] / 32);
            ushort foundX = 0;

            for (ushort xx = currentX; xx <= 1000; xx++)
            {
                if (!Block.Walkthrough(p.level.GetTile(currentY, xx, currentZ)) && p.level.GetTile(currentY, xx, currentZ) != Block.Zero)
                {
                    foundX = (ushort)(xx - 1);
                    who.level.ChatLevel(who.color + who.name + Server.DefaultColor + " was slapped into the wall by " + p.color + p.name);
                    break;
                }
            }

            if (foundX == 0)
            {
                who.level.ChatLevel(who.color + who.name + Server.DefaultColor + " was slapped across the map by " + p.color + p.name);
                foundX = 128;
            }

            unchecked { who.SendPos((byte)-1, (ushort)(foundX * 32), who.pos[1], who.pos[2], who.rot[0], who.rot[1]); }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/push <name> - Pushs <name>, using the force!");
        }
    }
}