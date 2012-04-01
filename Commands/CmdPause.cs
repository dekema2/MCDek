using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MCDek;

namespace MCLawl
{
    class CmdPause : Command
    {
        public override string name { get { return "pause"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdPause() { }

        public override void Use(Player p, string message)
        {
            if (message == "")
            {
                if (p != null)
                {
                    message = p.level.name + " 30";
                }
                else
                {
                    message = Server.mainLevel + " 30";
                }
            }
            int foundNum = 0; Level foundLevel;

            if (message.IndexOf(' ') == -1)
            {
                try
                {
                    foundNum = int.Parse(message);
                    if (p != null)
                    {
                        foundLevel = p.level;
                    }
                    else
                    {
                        foundLevel = Server.mainLevel;
                    }
                }
                catch
                {
                    foundNum = 30;
                    foundLevel = Level.Find(message);
                }
            }
            else
            {
                try
                {
                    foundNum = int.Parse(message.Split(' ')[1]);
                    foundLevel = Level.Find(message.Split(' ')[0]);
                }
                catch
                {
                    Player.SendMessage(p, "Invalid input");
                    return;
                }
            }

            if (foundLevel == null)
            {
                Player.SendMessage(p, "Could not find entered level.");
                return;
            }

            try
            {
                if (foundLevel.physPause)
                {
                    foundLevel.physThread.Resume();
                    foundLevel.physResume = DateTime.Now;
                    foundLevel.physPause = false;
                    Player.GlobalMessage("Physics on " + foundLevel.name + " were re-enabled.");
                }
                else
                {
                    foundLevel.physThread.Suspend();
                    foundLevel.physResume = DateTime.Now.AddSeconds(foundNum);
                    foundLevel.physPause = true;
                    Player.GlobalMessage("Physics on " + foundLevel.name + " were temporarily disabled.");

                    foundLevel.physTimer.Elapsed += delegate
                    {
                        if (DateTime.Now > foundLevel.physResume)
                        {
                            foundLevel.physPause = false;
                            try
                            {
                                foundLevel.physThread.Resume();
                            }
                            catch (Exception e) { Server.ErrorLog(e); }
                            Player.GlobalMessage("Physics on " + foundLevel.name + " were re-enabled.");
                            foundLevel.physTimer.Stop();
                            foundLevel.physTimer.Dispose();
                        }
                    };
                    foundLevel.physTimer.Start();
                }
            }
            catch (Exception e)
            {
                Server.ErrorLog(e);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/pause [map] [amount] - Pauses physics on [map] for 30 seconds");
        }
    }
}
