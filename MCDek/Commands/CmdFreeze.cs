using System;
using System.IO;

namespace MCLawl
{
    public class CmdFreeze : Command
    {
        public override string name { get { return "freeze"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdFreeze() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            Player who = Player.Find(message);
            if (who == null) { Player.SendMessage(p, "Could not find player."); return; }
            else if (who == p) { Player.SendMessage(p, "Cannot freeze yourself."); return; }
            else if (who.group.Permission >= p.group.Permission) { Player.SendMessage(p, "Cannot freeze someone of equal or greater rank."); return; }

            if (!who.frozen)
            {
                who.frozen = true;
                Player.GlobalChat(null, who.color + who.name + Server.DefaultColor + " has been &bfrozen.", false);
            }
            else
            {
                who.frozen = false;
                Player.GlobalChat(null, who.color + who.name + Server.DefaultColor + " has been &adefrosted.", false);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/freeze <name> - Stops <name> from moving until unfrozen.");
        }
    }
}