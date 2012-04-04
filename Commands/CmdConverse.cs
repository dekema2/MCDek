using System;
using System.Threading;
using MCLawl;

namespace MCDek
{
    public class CmdConverse : Command
    {
        public override string name { get { return "converse"; } }
        public override string shortcut { get { return "co"; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public override void Use(Player p, string message)
        {
            if (message.ToLower() == "1")
            {
                Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " is feeling happy! :)");
            }
            
            else if (message.ToLower() == "2")
            {
                Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " is feeling sad :(");
            }
            
            else if (message.ToLower() == "3")
            {
                Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " is angry >:(");
            }
            
            else if (message.ToLower() == "4")
            {
                Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " is excited :D");
            }
            
            else if (message.ToLower() == "5")
            {
                Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " is bored |-O");
            }
            
            else if (message.ToLower() == "6")
            {
                Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " is feeling mischevious }:-)");
            }
            
            else if (message.ToLower() == "7")
            {
                Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " is suprised o.O");
            }
            
            else if (message.ToLower() == "8")
            {
                Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " is not amused -_-");
            }            
            
            else if (message.ToLower() == "9")
            {
                Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " is confused :S");
            }            
            
            else if (message.ToLower() == "10")
            {
                Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " is tired Z.Z");
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/converse <1-10> - Quick chat about how you feel");
        }
    }
}