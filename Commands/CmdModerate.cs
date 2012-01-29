using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCLawl
{
    public class CmdModerate : Command
    {
        public override string name { get { return "moderate"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdModerate() { }

        public override void Use(Player p, string message)
        {
            if (message != "") { Help(p); return; }

            if (Server.chatmod)
            {
                Server.chatmod = false;
                Player.GlobalChat(null, Server.DefaultColor + "Chat moderation has been disabled.  Everyone can now speak.", false);
            }
            else
            {
                Server.chatmod = true;
                Player.GlobalChat(null, Server.DefaultColor + "Chat moderation engaged!  Silence the plebians!", false);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/moderate - Toggles chat moderation status.  When enabled, only voiced");
            Player.SendMessage(p, "players may speak.");
        }
    }
}