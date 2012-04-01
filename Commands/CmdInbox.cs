using System;
using System.Collections.Generic;
using System.Data;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;
using MCDek;
namespace MCLawl
{
    public class CmdInbox : Command
    {
        public override string name { get { return "inbox"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdInbox() { }

        public override void Use(Player p, string message)
        {
            try
            {
                MySQL.executeQuery("CREATE TABLE if not exists `Inbox" + p.name + "` (PlayerFrom CHAR(20), TimeSent DATETIME, Contents VARCHAR(255));");
                if (message == "")
                {
                    DataTable Inbox = MySQL.fillData("SELECT * FROM `Inbox" + p.name + "` ORDER BY TimeSent");

                    if (Inbox.Rows.Count == 0) { Player.SendMessage(p, "No messages found."); Inbox.Dispose(); return; }

                    for (int i = 0; i < Inbox.Rows.Count; ++i)
                    {
                        Player.SendMessage(p, i + ": From &5" + Inbox.Rows[i]["PlayerFrom"].ToString() + Server.DefaultColor + " at &a" + Inbox.Rows[i]["TimeSent"].ToString());
                    }
                    Inbox.Dispose();
                }
                else if (message.Split(' ')[0].ToLower() == "del" || message.Split(' ')[0].ToLower() == "delete")
                {
                    int FoundRecord = -1;

                    if (message.Split(' ')[1].ToLower() != "all")
                    {
                        try
                        {
                            FoundRecord = int.Parse(message.Split(' ')[1]);
                        }
                        catch { Player.SendMessage(p, "Incorrect number given."); return; }

                        if (FoundRecord < 0) { Player.SendMessage(p, "Cannot delete records below 0"); return; }
                    }

                    DataTable Inbox = MySQL.fillData("SELECT * FROM `Inbox" + p.name + "` ORDER BY TimeSent");

                    if (Inbox.Rows.Count - 1 < FoundRecord || Inbox.Rows.Count == 0)
                    {
                        Player.SendMessage(p, "\"" + FoundRecord + "\" does not exist."); Inbox.Dispose(); return;
                    }

                    string queryString;
                    if (FoundRecord == -1)
                        queryString = "TRUNCATE TABLE `Inbox" + p.name + "`";
                    else
                        queryString = "DELETE FROM `Inbox" + p.name + "` WHERE PlayerFrom='" + Inbox.Rows[FoundRecord]["PlayerFrom"] + "' AND TimeSent='" + Convert.ToDateTime(Inbox.Rows[FoundRecord]["TimeSent"]).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                
                    MySQL.executeQuery(queryString);

                    if (FoundRecord == -1)
                        Player.SendMessage(p, "Deleted all messages.");
                    else
                        Player.SendMessage(p, "Deleted message.");

                    Inbox.Dispose();
                }
                else
                {
                    int FoundRecord;

                    try
                    {
                        FoundRecord = int.Parse(message);
                    }
                    catch { Player.SendMessage(p, "Incorrect number given."); return; }

                    if (FoundRecord < 0) { Player.SendMessage(p, "Cannot read records below 0"); return; }

                    DataTable Inbox = MySQL.fillData("SELECT * FROM `Inbox" + p.name + "` ORDER BY TimeSent");

                    if (Inbox.Rows.Count - 1 < FoundRecord || Inbox.Rows.Count == 0)
                    {
                        Player.SendMessage(p, "\"" + FoundRecord + "\" does not exist."); Inbox.Dispose(); return;
                    }

                    Player.SendMessage(p, "Message from &5" + Inbox.Rows[FoundRecord]["PlayerFrom"] + Server.DefaultColor + " sent at &a" + Inbox.Rows[FoundRecord]["TimeSent"] + ":");
                    Player.SendMessage(p, Inbox.Rows[FoundRecord]["Contents"].ToString());
                    Inbox.Dispose();
                }
            }
            catch
            {
                Player.SendMessage(p, "Error accessing inbox. You may have no mail, try again.");
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/inbox - Displays all your messages.");
            Player.SendMessage(p, "/inbox [num] - Displays the message at [num]");
            Player.SendMessage(p, "/inbox <del> [\"all\"/num] - Deletes the message at Num or All if \"all\" is given.");
        }
    }
}