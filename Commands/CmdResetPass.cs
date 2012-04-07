using System;
using System.Collections.Generic;
using System.IO;
using MCLawl;

namespace MCDek
{
    public class CmdResetPass : Command
    {
        public override string name { get { return "resetpass"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdResetPass() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            Player who = Player.Find(message);
            if (Server.server_owner == "Jeb" || Server.server_owner == "")
            {
                Player.SendMessage(p, "Please tell the server owner to change the 'Server Owner' property.");
                return;
            }
            if (p != null && Server.server_owner != p.name)
            {
                Player.SendMessage(p, "You're not the server owner!");
                return;
            }
            if (p != null && p.adminpen == true)
            {
                Player.SendMessage(p, "You cannot reset a password while in the admin pen!");
                return;
            }
            if (who == null)
            {
                Player.SendMessage(p, "The specified player does not exist.");
                return;
            }
            if (!File.Exists("extra/passwords/" + who.name + ".xml"))
            {
                Player.SendMessage(p, "The player you specified does not have a password!");
                return;
            }
            try
            {
                File.Delete("extra/passwords/" + who.name + ".xml");
                Player.SendMessage(p, "The admin password has sucessfully been removed for " + who.color + who.name + "!");
            }
            catch (Exception e)
            {
                Player.SendMessage(p, "Password Deletion Failed. Please manually delete the file. It is in extra/passwords.");
                Server.ErrorLog(e);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/resetpass [Player] - Resets the password for the specified player.");
            Player.SendMessage(p, "Note: May only be used by the server owner!");
        }
    }
}

