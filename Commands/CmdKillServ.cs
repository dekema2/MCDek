using System;
using System.IO;


namespace MCDek
{
    public class CmdKillServ : Command
    {
        public override string name { get { return "killserv"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdKillServ() { }

       public override void Use(Player p, string message)
        {
            try
            {
                if (message == "") { Help(p); return; }
                if (p != null && foundGroup.Permission >= p.group.Permission)
                   {
                   who = Player.players;
                   if (p != null)
                      {
                         killMsg = " was killed by " + p.color + p.name;
                      }
                   else
                      {
                         killMsg = " was killed by " + "the Console.";
                      }
                    }
             
            who.HandleDeath(Block.rock, killMsg);
           }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "Kills everyone in the server other than the owner");
        }
    }
}