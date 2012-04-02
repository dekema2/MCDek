using System;
using MCLawl;


namespace MCDek
{
    /// <summary>
    /// This is the command /vote
    /// </summary>
    public class CmdVote : Command
    {
        public override string name { get { return "vote"; } }
        public override string shortcut { get { return "vo"; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdVote() { }

        public override void Use(Player p, string message)
        {
            if (message != "")
            {
                if (!Server.voting)
                {
                    string temp = message.Substring(0, 1) == "%" ? "" : Server.DefaultColor;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.GlobalMessage(" " + c.green + "VOTE: " + temp + message + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                    System.Threading.Thread.Sleep(15000);
                    Server.voting = false;
                    Player.GlobalMessage("The vote is in! " + c.green + "Y: " + Server.YesVotes + c.red + " N: " + Server.NoVotes);
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    });
                }
                else
                {
                    p.SendMessage("A vote is in progress!");
                }
            }
            else
            {
                Help(p);
            }
        }
        public override void Help(Player p)
        {
            p.SendMessage("/vote [message] - Obviously starts a vote!");
        }
    }
}