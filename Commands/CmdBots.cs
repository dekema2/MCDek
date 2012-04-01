using System;
using System.IO;
using MCDek;

namespace MCLawl
{
    public class CmdBots : Command
    {
        public override string name { get { return "bots"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdBots() { }

        public override void Use(Player p, string message)
        {
            message = "";
            foreach (PlayerBot Pb in PlayerBot.playerbots)
            {
                if (Pb.AIName != "") message += ", " + Pb.name + "(" + Pb.level.name + ")[" + Pb.AIName + "]";
                else if (Pb.hunt) message += ", " + Pb.name + "(" + Pb.level.name + ")[Hunt]";
                else message += ", " + Pb.name + "(" + Pb.level.name + ")";

                if (Pb.kill) message += "-kill";
            }

            if (message != "") Player.SendMessage(p, "&1Bots: " + Server.DefaultColor + message.Remove(0, 2));
            else Player.SendMessage(p, "No bots are alive.");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/bots - Shows a list of bots, their AIs and levels");
        }
    }
}