using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCDek;
namespace MCLawl
{
    public class CmdVoice : Command
    {
        public override string name { get { return "voice"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdVoice() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            Player who = Player.Find(message);
            if (who != null)
            {
                if (who.voice)
                {
                    who.voice = false;
                    Player.SendMessage(p, "Removing voice status from " + who.name);
                    who.SendMessage("Your voice status has been revoked.");
                    who.voicestring = "";
                }
                else
                {
                    who.voice = true;
                    Player.SendMessage(p, "Giving voice status to " + who.name);
                    who.SendMessage("You have received voice status.");
                    who.voicestring = "&f+";
                }
            }
            else
            {
                Player.SendMessage(p, "There is no player online named \"" + message + "\"");
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/voice <name> - Toggles voice status on or off for specified player.");
        }
    }
}