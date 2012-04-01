using System;
using MCDek;

namespace MCLawl
{
    public class CmdTake : Command
    {
        public override string name { get { return "take"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdTake() { }

        public override void Use(Player p, string message)
        {
            if (message.IndexOf(' ') == -1) { Help(p); return; }
            if (message.Split(' ').Length != 2) { Help(p); return; }

            Player who = Player.Find(message.Split(' ')[0]);
            if (who == null) { Player.SendMessage(p, "Could not find player entered"); return; }
            if (who == p) { Player.SendMessage(p, "Sorry. Can't allow you to take money from yourself"); return; }

            int amountTaken;
            try { amountTaken = int.Parse(message.Split(' ')[1]); }
            catch { Player.SendMessage(p, "Invalid amount"); return; }

            if (who.money - amountTaken < 0) { Player.SendMessage(p, "Players cannot have under 0 " + Server.moneys); return; }
            if (amountTaken < 0) { Player.SendMessage(p, "Cannot take negative " + Server.moneys); return; }

            who.money -= amountTaken;
            Player.GlobalMessage(who.color + who.prefix + who.name + Server.DefaultColor + " was rattled down for " + amountTaken + " " + Server.moneys);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/take [player] <amount> - Takes <amount> of " + Server.moneys + " from [player]");
        }
    }
}