/*
Copyright dekema2
*/
using System;
using System.Collections.Generic;
using MCLawl.Commands;
using MCDek;

namespace MCLawl
{
    public abstract class CmdMCDSL
    {
        public override string name { get { return { "mcdsl"; } }
        public override string shortcut { get { return { ""; } }
        public override string type { get; }
        public override bool museumUsable { get; }
        public override LevelPermission defaultRank { get { return { "nobody"; } }
        public override void Use(Player p, string message);
		{
						
		}
				

	public override void Help(Player p)
    {
            Player.SendMessage(p, "/mcdsl - Shows the help for MCDSL");
            Player.SendMessage(p, "/mcdsl start - Starts the game, displays countdown. Also displays game clock when in session. Auto-finishes.");
            Player.SendMessage(p, "/mcdsl stop - Stops the game. No score will be calculated.");
            Player.SendMessage(p, "/mcdsl setuo - Sets up map for spleefing and saves floor.");
            Player.SendMessage(p, "/mcdsl player add [team] - Adds a player to a team.");
            Player.SendMessage(p, "/mcdsl team add [conference]- Adds a team. Be careful with this, must have owner consent.");
            Player.SendMessage(p, "/mcdsl ot - Turns overtime mode on.");
        }
	}
}

