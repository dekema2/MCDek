using System;
using MCDek;

namespace MCLawl
{
    public class CmdMimic : Command
    {
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public override void Help(Player p) { Player.SendMessage(p, "/mimic <player> <message> - Mimics a <player> making it sound like them"); }
        public override bool museumUsable { get { return true; } }
        public override string name { get { return "mimic"; } }
        public override string shortcut { get { return "mi"; } }
        public override string type { get { return "other"; } }
        public void SendIt(Player p, string message, Player player)
        {
            if (message.Split(' ').Length > 1)
            {
                if (player != null)
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalChat(player, message);
                }
                else
                {
                    string playerName = message.Split(' ')[0];
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage(playerName + ": &f" + message);
                }
            }
            else { Player.SendMessage(p, "Enter a message for the player to say."); }
        }
        public override void Use(Player p, string message)
        {
            if ((message == "")) { this.Help(p); }
            else
            {
                Player player = Player.Find(message.Split(' ')[0]);
                if (player != null)
                {
                    if (p == null) { this.SendIt(p, message, player); }
                    else
                    {
                        if (player == p) { this.SendIt(p, message, player); }
                        else
                        {
                            if (p.group.Permission > player.group.Permission) { this.SendIt(p, message, player); }
                            else { Player.SendMessage(p, "You cannot mimic a superior."); }
                        }
                    }
                }
                else
                {
                    if (p != null)
                    {
                        if (p.group.Permission >= LevelPermission.Admin)
                        {
                            if (Group.findPlayerGroup(message.Split(' ')[0]).Permission < p.group.Permission) { this.SendIt(p, message, null); }
                            else { Player.SendMessage(p, "You cannot mimic a superior."); }
                        }
                        else { Player.SendMessage(p, "You are not allowed to mimic players that are offline"); }
                    }
                    else { this.SendIt(p, message, null); }
                }
            }
        }
    }
}
