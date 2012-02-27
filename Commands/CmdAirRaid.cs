using System;
// This still needs a ton of work
namespace MCDek
{
    class CmdAirRaid
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
                    Command.all.Find("detonate").Use(p, message + "0 0 0");
                    Command.all.Find("detonate").Use(p, message + "50 0 0"); 
                    Command.all.Find("detonate").Use(p, message + "0 50 0"); 
                    Command.all.Find("detonate").Use(p, message + "-50 0 0"); 
                    Command.all.Find("detonate").Use(p, message + "0 -50 0");
                    Command.all.Find("detonate").Use(p, message + "50 50 0");
                    Command.all.Find("detonate").Use(p, message + "-50 -50 0");
                    Command.all.Find("detonate").Use(p, message + "50 -50 0");
                    Command.all.Find("detonate").Use(p, message + "-50 50 0");
                    Command.all.Find("botai").Use(p, message + "add Steve");
                    Command.all.Find("botset").Use(p, message + "hunt");
                    Command.all.Find("botset").Use(p, message + "kill");
                    Command.all.Find("botadd").Use(p, message + "Steve");
                    Command.all.Find("botadd").Use(p, message + "Steve"); 
                    Command.all.Find("botadd").Use(p, message + "Steve"); 
                    Command.all.Find("botadd").Use(p, message + "Steve"); 
                    Command.all.Find("botadd").Use(p, message + "Steve"); 
                    Command.all.Find("botadd").Use(p, message + "Steve"); 
                    Command.all.Find("botadd").Use(p, message + "Steve"); 
                    Command.all.Find("botadd").Use(p, message + "Steve");
            }
        }
    }
}
