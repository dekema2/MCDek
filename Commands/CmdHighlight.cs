using System;
using System.Collections.Generic;
using System.IO;
using MCDek;
namespace MCLawl
{
    public class CmdHighlight : Command
    {
        public override string name { get { return "highlight"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "moderation"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public CmdHighlight() { }

        public override void Use(Player p, string message)
        {
            byte b; Int64 seconds;
            Player who;
            Player.UndoPos Pos;
            int CurrentPos = 0;
            bool FoundUser = false;

            if (message == "") message = p.name + " 300";

            if (message.Split(' ').Length == 2)
            {
                try
                {
                    seconds = Int64.Parse(message.Split(' ')[1]);
                }
                catch
                {
                    Player.SendMessage(p, "Invalid seconds.");
                    return;
                }
            }
            else
            {
                try
                {
                    seconds = int.Parse(message);
                    if (p != null) message = p.name + " " + message;
                }
                catch
                {
                    seconds = 300;
                    message = message + " 300";
                }
            }

            if (seconds == 0) seconds = 5400;

            who = Player.Find(message.Split(' ')[0]);
            if (who != null)
            {
                message = who.name + " " + seconds;
                FoundUser = true;
                for (CurrentPos = who.UndoBuffer.Count - 1; CurrentPos >= 0; --CurrentPos)
                {
                    try
                    {
                        Pos = who.UndoBuffer[CurrentPos];
                        Level foundLevel = Level.Find(Pos.mapName);
                        if (foundLevel == p.level)
                        {
                            b = foundLevel.GetTile(Pos.x, Pos.y, Pos.z);
                            if (Pos.timePlaced.AddSeconds(seconds) >= DateTime.Now)
                            {
                                if (b == Pos.newtype || Block.Convert(b) == Block.water || Block.Convert(b) == Block.lava)
                                {
                                    if (b == Block.air || Block.Convert(b) == Block.water || Block.Convert(b) == Block.lava) p.SendBlockchange(Pos.x, Pos.y, Pos.z, Block.red);
                                    else p.SendBlockchange(Pos.x, Pos.y, Pos.z, Block.green);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    catch { }
                }
            }

            try
            {
                DirectoryInfo di;
                string[] fileContent;

                if (Directory.Exists("extra/undo/" + message.Split(' ')[0]))
                {
                    di = new DirectoryInfo("extra/undo/" + message.Split(' ')[0]);

                    for (int i = 0; i < di.GetFiles("*.undo").Length; i++)
                    {
                        fileContent = File.ReadAllText("extra/undo/" + message.Split(' ')[0] + "/" + i + ".undo").Split(' ');
                        highlightStuff(fileContent, seconds, p);
                    }
                    FoundUser = true;
                }

                if (Directory.Exists("extra/undoPrevious/" + message.Split(' ')[0]))
                {
                    di = new DirectoryInfo("extra/undoPrevious/" + message.Split(' ')[0]);

                    for (int i = 0; i < di.GetFiles("*.undo").Length; i++)
                    {
                        fileContent = File.ReadAllText("extra/undoPrevious/" + message.Split(' ')[0] + "/" + i + ".undo").Split(' ');
                        highlightStuff(fileContent, seconds, p);
                    }
                    FoundUser = true;
                }

                if (FoundUser)
                {
                    Player.SendMessage(p, "Now highlighting &b" + seconds + Server.DefaultColor + " seconds for " + Server.FindColor(message.Split(' ')[0]) + message.Split(' ')[0]);
                    Player.SendMessage(p, "&cUse /reveal to un-highlight");
                }
                else
                {
                    Player.SendMessage(p, "Could not find player specified.");
                }
            }
            catch (Exception e)
            {
                Server.ErrorLog(e);
            }
        }

        public void highlightStuff(string[] fileContent, Int64 seconds, Player p)
        {
            Player.UndoPos Pos;

            for (int i = fileContent.Length / 7; i >= 0; i--)
            {
                try
                {
                    if (Convert.ToDateTime(fileContent[(i * 7) + 4].Replace('&', ' ')).AddSeconds(seconds) >= DateTime.Now)
                    {
                        Level foundLevel = Level.Find(fileContent[i * 7]);
                        if (foundLevel != null && foundLevel == p.level)
                        {
                            Pos.mapName = foundLevel.name;
                            Pos.x = Convert.ToUInt16(fileContent[(i * 7) + 1]);
                            Pos.y = Convert.ToUInt16(fileContent[(i * 7) + 2]);
                            Pos.z = Convert.ToUInt16(fileContent[(i * 7) + 3]);

                            Pos.type = foundLevel.GetTile(Pos.x, Pos.y, Pos.z);

                            if (Pos.type == Convert.ToByte(fileContent[(i * 7) + 6]) || Block.Convert(Pos.type) == Block.water || Block.Convert(Pos.type) == Block.lava)
                            {
                                if (Pos.type == Block.air || Block.Convert(Pos.type) == Block.water || Block.Convert(Pos.type) == Block.lava)
                                    p.SendBlockchange(Pos.x, Pos.y, Pos.z, Block.red);
                                else p.SendBlockchange(Pos.x, Pos.y, Pos.z, Block.green);
                            }
                        }
                    }
                    else break;
                }
                catch { }
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/highlight [player] [seconds] - Highlights blocks modified by [player] in the last [seconds]");
            Player.SendMessage(p, "/highlight [player] 0 - Will highlight 30 minutes");
            Player.SendMessage(p, "&c/highlight cannot be disabled, you must use /reveal to un-highlight");
        }
    }
}