using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCLawl;
using System.Threading;

namespace MCDek
{
    public class CmdRPS : Command
    {
        public override string name { get { return "rps"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public override void Use(Player p, string message)
        {
            if (message.ToLower() == "r")
            {
                Thread.Sleep(2000);
                Player.GlobalChat(p, p.color + p.name + Server.DefaultColor + "choose rock!");
            }
            if (message.ToLower() == "p")
            {
                Thread.Sleep(2000);
                Player.GlobalChat(p, p.color + p.name + Server.DefaultColor + "choose paper!");
            }
            if (message.ToLower() == "s")
            {
                Thread.Sleep(2000);
                Player.GlobalChat(p, p.color + p.name + Server.DefaultColor + "choose scissors!");
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/rps r-p-s - Rock, Paper, Scissors game!");
        }
    }
}
