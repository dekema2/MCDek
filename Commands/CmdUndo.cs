using System;
using System.Collections.Generic;
using System.IO;

namespace MCLawl
{
    public class CmdUndo : Command
    {
        public override string name { get { return "undo"; } }
        public override string shortcut { get { return "u"; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdUndo() { }

        public override void Use(Player p, string message)
        {
            byte b; Int64 seconds; Player who; Player.UndoPos Pos; int CurrentPos = 0;
            if (p != null) p.RedoBuffer.Clear();

            if (message == "") message = p.name + " 30";

            if (message.Split(' ').Length == 2)
            {
                if (message.Split(' ')[1].ToLower() == "all" && p.group.Permission > LevelPermission.Operator)
                {
                    seconds = 500000;
                }
                else
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
                    seconds = 30;
                    message = message + " 30";
                }
            }

            //if (message.Split(' ').Length == 1) if (char.IsDigit(message, 0)) { message = p.name + " " + message; } else { message = message + " 30"; }

            //try { seconds = Convert.ToInt16(message.Split(' ')[1]); } catch { seconds = 2; }
            if (seconds == 0) seconds = 5400;

            who = Player.Find(message.Split(' ')[0]);
            if (who != null)
            {
                if (p != null)
                {
                    if (who.group.Permission > p.group.Permission && who != p) { Player.SendMessage(p, "Cannot undo a user of higher or equal rank"); return; }
                    if (who != p && p.group.Permission < LevelPermission.Operator) { Player.SendMessage(p, "Only an OP+ may undo other people's actions"); return; }

                    if (p.group.Permission < LevelPermission.Builder && seconds > 120) { Player.SendMessage(p, "Guests may only undo 2 minutes."); return; }
                    else if (p.group.Permission < LevelPermission.AdvBuilder && seconds > 300) { Player.SendMessage(p, "Builders may only undo 300 seconds."); return; }
                    else if (p.group.Permission < LevelPermission.Operator && seconds > 1200) { Player.SendMessage(p, "AdvBuilders may only undo 600 seconds."); return; }
                    else if (p.group.Permission == LevelPermission.Operator && seconds > 5400) { Player.SendMessage(p, "Operators may only undo 5400 seconds."); return; }
                }

                for (CurrentPos = who.UndoBuffer.Count - 1; CurrentPos >= 0; --CurrentPos)
                {
                    try
                    {
                        Pos = who.UndoBuffer[CurrentPos];
                        Level foundLevel = Level.FindExact(Pos.mapName);
                        b = foundLevel.GetTile(Pos.x, Pos.y, Pos.z);
                        if (Pos.timePlaced.AddSeconds(seconds) >= DateTime.Now)
                        {
                            if (b == Pos.newtype || Block.Convert(b) == Block.water || Block.Convert(b) == Block.lava)
                            {
                                foundLevel.Blockchange(Pos.x, Pos.y, Pos.z, Pos.type, true);

                                Pos.newtype = Pos.type; Pos.type = b;
                                if (p != null) p.RedoBuffer.Add(Pos);
                                who.UndoBuffer.RemoveAt(CurrentPos);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch { }
                }

                if (p != who) Player.GlobalChat(p, who.color + who.name + Server.DefaultColor + "'s actions for the past &b" + seconds + " seconds were undone.", false);
                else Player.SendMessage(p, "Undid your actions for the past &b" + seconds + Server.DefaultColor + " seconds.");
                return;
            }
            else if (message.Split(' ')[0].ToLower() == "physics")
            {
                if (p.group.Permission < LevelPermission.AdvBuilder) { Player.SendMessage(p, "Reserved for Adv+"); return; }
                else if (p.group.Permission < LevelPermission.Operator && seconds > 1200) { Player.SendMessage(p, "AdvBuilders may only undo 1200 seconds."); return; }
                else if (p.group.Permission == LevelPermission.Operator && seconds > 5400) { Player.SendMessage(p, "Operators may only undo 5400 seconds."); return; }

                Command.all.Find("pause").Use(p, "120");
                Level.UndoPos uP;
                ushort x, y, z;

                if (p.level.UndoBuffer.Count != Server.physUndo)
                {
                    for (CurrentPos = p.level.currentUndo; CurrentPos >= 0; CurrentPos--)
                    {
                        try
                        {
                            uP = p.level.UndoBuffer[CurrentPos];
                            b = p.level.GetTile(uP.location);
                            if (uP.timePerformed.AddSeconds(seconds) >= DateTime.Now)
                            {
                                if (b == uP.newType || Block.Convert(b) == Block.water || Block.Convert(b) == Block.lava)
                                {
                                    p.level.IntToPos(uP.location, out x, out y, out z);
                                    p.level.Blockchange(p, x, y, z, uP.oldType, true);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch { }
                    }
                }
                else
                {
                    for (CurrentPos = p.level.currentUndo; CurrentPos != p.level.currentUndo + 1; CurrentPos--)
                    {
                        try
                        {
                            if (CurrentPos < 0) CurrentPos = p.level.UndoBuffer.Count - 1;
                            uP = p.level.UndoBuffer[CurrentPos];
                            b = p.level.GetTile(uP.location);
                            if (uP.timePerformed.AddSeconds(seconds) >= DateTime.Now)
                            {
                                if (b == uP.newType || Block.Convert(b) == Block.water || Block.Convert(b) == Block.lava)
                                {
                                    p.level.IntToPos(uP.location, out x, out y, out z);
                                    p.level.Blockchange(p, x, y, z, uP.oldType, true);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch { }
                    }
                }

                Command.all.Find("pause").Use(p, "");
                Player.GlobalMessage("Physics were undone &b" + seconds + Server.DefaultColor + " seconds");
            }
            else
            {
                if (p != null)
                {
                    if (p.group.Permission < LevelPermission.Operator) { Player.SendMessage(p, "Reserved for OP+"); return; }
                    if (seconds > 5400 && p.group.Permission == LevelPermission.Operator) { Player.SendMessage(p, "Only SuperOPs may undo more than 90 minutes."); return; }
                }

                bool FoundUser = false;

                try
                {
                    DirectoryInfo di;
                    string[] fileContent;

                    p.RedoBuffer.Clear();

                    if (Directory.Exists("extra/undo/" + message.Split(' ')[0]))
                    {
                        di = new DirectoryInfo("extra/undo/" + message.Split(' ')[0]);

                        for (int i = di.GetFiles("*.undo").Length - 1; i >= 0; i--)
                        {
                            fileContent = File.ReadAllText("extra/undo/" + message.Split(' ')[0] + "/" + i + ".undo").Split(' ');
                            if (!undoBlah(fileContent, seconds, p)) break;
                        }
                        FoundUser = true;
                    }

                    if (Directory.Exists("extra/undoPrevious/" + message.Split(' ')[0]))
                    {
                        di = new DirectoryInfo("extra/undoPrevious/" + message.Split(' ')[0]);

                        for (int i = di.GetFiles("*.undo").Length - 1; i >= 0; i--)
                        {
                            fileContent = File.ReadAllText("extra/undoPrevious/" + message.Split(' ')[0] + "/" + i + ".undo").Split(' ');
                            if (!undoBlah(fileContent, seconds, p)) break;
                        }
                        FoundUser = true;
                    }
                    
                    if (FoundUser) Player.GlobalChat(p, Server.FindColor(message.Split(' ')[0]) + message.Split(' ')[0] + Server.DefaultColor + "'s actions for the past &b" + seconds + Server.DefaultColor + " seconds were undone.", false);
                    else Player.SendMessage(p, "Could not find player specified.");
                }
                catch (Exception e)
                {
                    Server.ErrorLog(e);
                }
            }
        }

        public bool undoBlah(string[] fileContent, Int64 seconds, Player p)
        {

            //fileContents += uP.map.name + " " + uP.x + " " + uP.y + " " + uP.z + " ";
            //fileContents += uP.timePlaced + " " + uP.type + " " + uP.newtype + " ";

            //Maps = 0, 7, 14, 21, 28, 35...
            //X = 1, 8, 15...
            //newtype = 6, 13, 20, 27...

            Player.UndoPos Pos;

            for (int i = fileContent.Length / 7; i >= 0; i--)
            {
                try
                {
                    if (Convert.ToDateTime(fileContent[(i * 7) + 4].Replace('&', ' ')).AddSeconds(seconds) >= DateTime.Now)
                    {
                        Level foundLevel = Level.FindExact(fileContent[i * 7]);
                        if (foundLevel != null)
                        {
                            Pos.mapName = foundLevel.name;
                            Pos.x = Convert.ToUInt16(fileContent[(i * 7) + 1]);
                            Pos.y = Convert.ToUInt16(fileContent[(i * 7) + 2]);
                            Pos.z = Convert.ToUInt16(fileContent[(i * 7) + 3]);

                            Pos.type = foundLevel.GetTile(Pos.x, Pos.y, Pos.z);

                            if (Pos.type == Convert.ToByte(fileContent[(i * 7) + 6]) || Block.Convert(Pos.type) == Block.water || Block.Convert(Pos.type) == Block.lava || Pos.type == Block.grass)
                            {
                                Pos.newtype = Convert.ToByte(fileContent[(i * 7) + 5]);
                                Pos.timePlaced = DateTime.Now;

                                foundLevel.Blockchange(Pos.x, Pos.y, Pos.z, Pos.newtype, true);
                                if (p != null) p.RedoBuffer.Add(Pos);
                            }
                        }
                    }
                    else return false;
                }
                catch { }
            }

            return true;
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/undo [player] [seconds] - Undoes the blockchanges made by [player] in the previous [seconds].");
            Player.SendMessage(p, "/undo [player] all - &cWill undo 138 hours for [player] <SuperOP+>");
            Player.SendMessage(p, "/undo [player] 0 - &cWill undo 30 minutes <Operator+>");
            Player.SendMessage(p, "/undo physics [seconds] - Undoes the physics for the current map");
        }
    }
}