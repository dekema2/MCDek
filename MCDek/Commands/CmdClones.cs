using System;
using System.Collections.Generic;
using System.Text;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;
using System.Data;

namespace MCLawl
{
    class CmdClones : Command
    {

        public override string name { get { return "clones"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public CmdClones() { }

        public override void Use(Player p, string message)
        {
            if (message == "") message = p.name;

            string originalName = message.ToLower();

            Player who = Player.Find(message);
            if (who == null)
            {
                Player.SendMessage(p, "Could not find player. Searching Player DB.");

                DataTable FindIP = MySQL.fillData("SELECT IP FROM Players WHERE Name='" + message + "'");

                if (FindIP.Rows.Count == 0) { Player.SendMessage(p, "Could not find any player by the name entered."); FindIP.Dispose(); return; }

                message = FindIP.Rows[0]["IP"].ToString();
                FindIP.Dispose();
            }
            else
            {
                message = who.ip;
            }

            DataTable Clones = MySQL.fillData("SELECT Name FROM Players WHERE IP='" + message + "'");

            if (Clones.Rows.Count == 0) { Player.SendMessage(p, "Could not find any record of the player entered."); return; }

            List<string> foundPeople = new List<string>();
            for (int i = 0; i < Clones.Rows.Count; ++i)
            {
                if (!foundPeople.Contains(Clones.Rows[i]["Name"].ToString().ToLower()))
                    foundPeople.Add(Clones.Rows[i]["Name"].ToString().ToLower());
            }

            Clones.Dispose();
            if (foundPeople.Count <= 1) { Player.SendMessage(p, originalName + " has no clones."); return; }

            Player.SendMessage(p, "These people have the same IP address:");
            Player.SendMessage(p, string.Join(", ", foundPeople.ToArray()));
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/clones <name> - Finds everyone with the same IP has <name>");
        }
    }
}
