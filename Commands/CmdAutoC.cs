using System;


namespace MCDek
{
    public class CmdAutoC : Command
    {
        public override string name { get { return "ac"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdAutoC() { }
        {
            if ((p.group.CanExecute(Command.all.Find("cuboid"))) && (p.group.CanExecute(Command.all.Find("static"))))
            {
                if ((!p.staticCommands == true) && (!p.megaBoid == true))
                {
                    Command.all.Find("static").Use(p, "");
                    Command.all.Find("cuboid").Use(p, message);
                    Player.SendMessage(p, p.color + p.name + Server.DefaultColor + " to quit using AutoCubiod type /ac again.");
                }
                else
                {
                    p.ClearBlockchange();
                    p.staticCommands = false;
                    Player.SendMessage(p, "/ac has ended.");
                }
            }
            else { Player.SendMessage(p, "Your rank cannot use this command!"); }

        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/ac - AutoCubiod a static cubiod.");
        }
    }
}