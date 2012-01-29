using System;
using System.IO;
using System.Collections.Generic;

namespace MCLawl
{
    public class CmdLastCmd : Command
    {
        public override string name { get { return "lastcmd"; } }
        public override string shortcut { get { return "last"; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdLastCmd() { }

        public override void Use(Player p, string message)
        {
            if (message == "")
            {
                foreach (Player pl in Player.players)
                {
                    Player.SendMessage(p, pl.color + pl.name + Server.DefaultColor + " last used \"" + pl.lastCMD + "\"");
                }
            }
            else
            {
                Player who = Player.Find(message);
                if (who == null) { Player.SendMessage(p, "Could not find player entered"); return; }
                Player.SendMessage(p, who.color + who.name + Server.DefaultColor + " last used \"" + who.lastCMD + "\"");
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/last [user] - Shows last command used by [user]");
            Player.SendMessage(p, "/last by itself will show all last commands (SPAMMY)");
        }
    }
}