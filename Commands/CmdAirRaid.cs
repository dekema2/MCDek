using System;
using MCDek;
// This still needs a ton of work

namespace MCLawl
{
    class CmdAirRaid : Command
    {        
        public override string name { get { return "airraid"; } }
        public override string shortcut { get { return "ar"; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdAirRaid() { }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/airraid - Drops tnt on your city then brings in killer bots :)");

        }
        public override void Use(Player p, string message)
        {
                        if (p != null)
            {
                    Command.all.Find("detonate").Use(p, message + "32 32 32");
                    Command.all.Find("detonate").Use(p, message + "64 64 64"); 
                    Command.all.Find("detonate").Use(p, message + "32 32 64"); 
                    Command.all.Find("detonate").Use(p, message + "64 32 32"); 
                    Command.all.Find("detonate").Use(p, message + "32 32 64");
                    Command.all.Find("detonate").Use(p, message + "5 64 5");
                    Command.all.Find("detonate").Use(p, message + "64 32 64");
                    Command.all.Find("detonate").Use(p, message + "128 64 128");
                    Command.all.Find("detonate").Use(p, message + "5 64 5");
                    Command.all.Find("botai").Use(p, message + "add Steve");
                    Command.all.Find("botadd").Use(p, message + "Steve");
                    Command.all.Find("botadd").Use(p, message + "Steve");
                    Command.all.Find("botadd").Use(p, message + "Steve");
                    Command.all.Find("botadd").Use(p, message + "Steve");
                    Command.all.Find("botadd").Use(p, message + "Steve");
                    Command.all.Find("botadd").Use(p, message + "Steve");
                    Command.all.Find("botadd").Use(p, message + "Steve");
                    Command.all.Find("botadd").Use(p, message + "Steve"); 
                    Command.all.Find("botset").Use(p, message + "Steve hunt");
                    Command.all.Find("botset").Use(p, message + "Steve kill");

            }
        }
    }
}
