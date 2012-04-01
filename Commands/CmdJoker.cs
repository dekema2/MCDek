using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCDek;

namespace MCLawl
{
    public class CmdJoker : Command
    {
        public override string name { get { return "joker"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdJoker() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            bool stealth = false;
            if (message[0] == '#')
            {
                message = message.Remove(0, 1).Trim();
                stealth = true;
                Server.s.Log("Stealth joker attempted");
            }

            Player who = Player.Find(message);
            if (who == null)
            {
                Player.SendMessage(p, "Could not find player.");
                return;
            }
            //     else if (who.group.Permission >= p.group.Permission) { Player.SendMessage(p, "Cannot joker someone of equal or greater rank."); return; }

            if (!who.joker)
            {
                who.joker = true;
                if (stealth) { Player.GlobalMessageOps(who.color + who.name + Server.DefaultColor + " is now STEALTH joker'd. "); return; }
                Player.GlobalChat(null, who.color + who.name + Server.DefaultColor + " is now a &aJ&bo&ck&5e&9r" + Server.DefaultColor + ".", false);
            }
            else
            {
                who.joker = false;
                if (stealth) { Player.GlobalMessageOps(who.color + who.name + Server.DefaultColor + " is now STEALTH Unjoker'd. "); return; }
                Player.GlobalChat(null, who.color + who.name + Server.DefaultColor + " is no longer a &aJ&bo&ck&5e&9r" + Server.DefaultColor + ".", false);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/joker <name> - Causes a player to become a joker!");
            Player.SendMessage(p, "/joker # <name> - Makes the player a joker silently");
            return;
        }
    }
}
