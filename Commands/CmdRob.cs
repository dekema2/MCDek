/*
   Auto-generated command skeleton class.

   Use this as a basis for custom commands implemented via the MCForge scripting framework.
   File and class should be named a specific way.  For example, /update is named 'CmdUpdate.cs' for the file, and 'CmdUpdate' for the class.
*/

// Add any other using statements you need up here, of course.
// As a note, MCForge is designed for .NET 3.5.
using System;
using MCLawl;

namespace MCDek
{
    public class CmdRob : Command
    {
        public override string name { get { return "rob"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdRob() { }
        public override void Use(Player p, string message)
        {

            if (message.IndexOf(' ') == -1) { Help(p); return; }
            if (message.Split(' ').Length != 2) { Help(p); return; }

            Player who = Player.Find(message.Split(' ')[0]);
            if (who == null) { Player.SendMessage(p, "Could not find player specified"); return; }
            if (who == p) { Player.SendMessage(p, "Sorry. You cant rob yourself"); return; }
            else
            {
                int rob2;
                try { rob2 = int.Parse(message.Split(' ')[1]);}
                catch { Player.SendMessage(p, "Invalid amount"); return; }
                Random RandomNumber = new Random();
                int rob1 = RandomNumber.Next(0, rob2);


                if (who.money < rob2) { Player.SendMessage(p, who.color + who.name + "doesnt have" + rob2 + Server.moneys); return; }

                if (rob1 <= 25)
                {
                    Player.SendMessage(p, "%3You stole %a" + rob2 + Server.moneys + "from" + who.color + who.name);
                    p.money = p.money + rob2;
                    who.money = who.money - rob2; 
                }
                if (rob1 > 25)
                {
                    Player.SendMessage(p, "%cYou have failed, you have been fined you paid bail" + " %4-" + rob2 + "and were kicked");
                    p.money = p.money - (rob2);
                    if (p.money < 1) { p.money = 0; }
                    Command.all.Find("kick").Use(p, p.name + "Your robbing failed");

                }
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/rob - Trying to rob someone of there hard earned money.");
        }
    }
}