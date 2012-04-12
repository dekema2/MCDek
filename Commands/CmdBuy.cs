using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCLawl;

namespace MCDek
{
        public class CmdBuy : Command
    {
        public override string name { get { return "buy"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdBuy() { }

        public override void Use(Player p, string message)
        {
           
            string cmd = message.Split(' ')[0];
            string value = message.Split(' ')[1];
                   if ( cmd == "color")
                        if (p.money >= 600)
                        {
                            Command.all.Find("color").Use(null, p.name + " " + value);
                            Player.SendMessage(p, "You bought the color " + value + ".");
                        }
                        else
                        {
                            Player.SendMessage(p, "You don't have enough money to buy this color.");
                        }
                   
                   if ( cmd == "tcolor")

                        if (p.money >= 400)
                        {
                            Command.all.Find("tcolor").Use(null, p.name + " " + value);
                            Player.SendMessage(p, "You bought the title color " + value + ".");
                        }
                        else
                        {
                            Player.SendMessage(p, "You don't have enough money to buy this title color.");
                        }

                    if ( cmd == "title")
                        if (p.money >= 300)
                        {
                            Command.all.Find("title").Use(null, p.name + " " + value);
                            Player.SendMessage(p, "You bought the title " + p.prefix + ".");
                        }
                        else
                        {
                            Player.SendMessage(p, "You don't have enough money to buy this title.");
                        }
                   if ( cmd == "ezone")
                        if (p.money >= 1000)
                        {
                            Command.all.Find("ezone").Use(null, " " + value);
                            Player.SendMessage(p, "You bought the ezone " + p.prefix + ". Build away!");
                        }
                        else
                        {
                            Player.SendMessage(p, "You don't have enough money to buy this ezone.");
                        }
                }
            
        
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/buy <item> <color/value> - Buy items that you want!");
        }
    }
}

