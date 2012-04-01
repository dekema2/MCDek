﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MCDek;
namespace MCLawl
{
    public class CmdGun : Command
    {
        public override string name { get { return "gun"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public CmdGun() { }
        public override void Use(Player p, string message)
        {
            if (p.hasflag != null) { Player.SendMessage(p, "You can't use a gun while you have the flag!"); return;}
            Pos cpos;

            if (p.aiming)
            {
                if (message == "")
                {
                    p.aiming = false;
                    p.ClearBlockchange();
                    Player.SendMessage(p, "Disabled gun");
                    return;
                }
            }

            cpos.ending = 0;
            if (message.ToLower() == "destroy") cpos.ending = 1;
            else if (message.ToLower() == "explode") cpos.ending = 2;
            else if (message.ToLower() == "laser") cpos.ending = 3;
            else if (message.ToLower() == "teleport" || message.ToLower() == "tp") cpos.ending = -1;
            else if (message != "") { Help(p); return; }

            cpos.x = 0; cpos.y = 0; cpos.z = 0; p.blockchangeObject = cpos;
            p.ClearBlockchange();
            p.Blockchange += new Player.BlockchangeEventHandler(Blockchange1);

            p.SendMessage("Gun mode engaged, fire at will");

            if (p.aiming)
            {
                return;
            }

            p.aiming = true;
            Thread aimThread = new Thread(new ThreadStart(delegate
            {
                CatchPos pos;
                List<CatchPos> buffer = new List<CatchPos>();
                while (p.aiming)
                {
                    List<CatchPos> tempBuffer = new List<CatchPos>();

                    double a = Math.Sin(((double)(128 - p.rot[0]) / 256) * 2 * Math.PI);
                    double b = Math.Cos(((double)(128 - p.rot[0]) / 256) * 2 * Math.PI);
                    double c = Math.Cos(((double)(p.rot[1] + 64) / 256) * 2 * Math.PI);

                    try
                    {
                        ushort x = (ushort)(p.pos[0] / 32);
                        x = (ushort)Math.Round(x + (double)(a * 3));

                        ushort y = (ushort)(p.pos[1] / 32 + 1);
                        y = (ushort)Math.Round(y + (double)(c * 3));

                        ushort z = (ushort)(p.pos[2] / 32);
                        z = (ushort)Math.Round(z + (double)(b * 3));

                        if (x > p.level.width || y > p.level.depth || z > p.level.height) throw new Exception();
                        if (x < 0 || y < 0 || z < 0) throw new Exception();

                        for (ushort xx = x; xx <= x + 1; xx++)
                        {
                            for (ushort yy = (ushort)(y - 1); yy <= y; yy++)
                            {
                                for (ushort zz = z; zz <= z + 1; zz++)
                                {
                                    if (p.level.GetTile(xx, yy, zz) == Block.air)
                                    {
                                        pos.x = xx; pos.y = yy; pos.z = zz;
                                        tempBuffer.Add(pos);
                                    }
                                }
                            }
                        }

                        List<CatchPos> toRemove = new List<CatchPos>();
                        foreach (CatchPos cP in buffer)
                        {
                            if (!tempBuffer.Contains(cP))
                            {
                                p.SendBlockchange(cP.x, cP.y, cP.z, Block.air);
                                toRemove.Add(cP);
                            }
                        }

                        foreach (CatchPos cP in toRemove)
                        {
                            buffer.Remove(cP);
                        }

                        foreach (CatchPos cP in tempBuffer)
                        {
                            if (!buffer.Contains(cP))
                            {
                                buffer.Add(cP);
                                p.SendBlockchange(cP.x, cP.y, cP.z, Block.glass);
                            }
                        }

                        tempBuffer.Clear();
                        toRemove.Clear();
                    }
                    catch { }
                    Thread.Sleep(20);
                }

                foreach (CatchPos cP in buffer)
                {
                    p.SendBlockchange(cP.x, cP.y, cP.z, Block.air);
                }
            }));
            aimThread.Start();
        }
        public void Blockchange1(Player p, ushort x, ushort y, ushort z, byte type)
        {
            byte by = p.level.GetTile(x, y, z);
            p.SendBlockchange(x, y, z, by);
            Pos bp = (Pos)p.blockchangeObject;

            double a = Math.Sin(((double)(128 - p.rot[0]) / 256) * 2 * Math.PI);
            double b = Math.Cos(((double)(128 - p.rot[0]) / 256) * 2 * Math.PI);
            double c = Math.Cos(((double)(p.rot[1] + 64) / 256) * 2 * Math.PI);

            double bigDiag = Math.Sqrt(Math.Sqrt(p.level.width * p.level.width + p.level.height * p.level.height) + p.level.depth * p.level.depth + p.level.width * p.level.width);

            List<CatchPos> previous = new List<CatchPos>();
            List<CatchPos> allBlocks = new List<CatchPos>();
            CatchPos pos;

            if (p.modeType != Block.air)
                type = p.modeType;

            Thread gunThread = new Thread(new ThreadStart(delegate
            {
                ushort startX = (ushort)(p.pos[0] / 32);
                ushort startY = (ushort)(p.pos[1] / 32);
                ushort startZ = (ushort)(p.pos[2] / 32);

                pos.x = (ushort)Math.Round(startX + (double)(a * 3));
                pos.y = (ushort)Math.Round(startY + (double)(c * 3));
                pos.z = (ushort)Math.Round(startZ + (double)(b * 3));

                for (double t = 4; bigDiag > t; t++)
                {
                    pos.x = (ushort)Math.Round(startX + (double)(a * t));
                    pos.y = (ushort)Math.Round(startY + (double)(c * t));
                    pos.z = (ushort)Math.Round(startZ + (double)(b * t));

                    by = p.level.GetTile(pos.x, pos.y, pos.z);

                    if (by != Block.air && !allBlocks.Contains(pos))
                    {
                        if (p.level.physics < 2 || bp.ending <= 0)
                        {
                            break;
                        }
                        else
                        {
                            if (bp.ending == 1)
                            {
                                if ((!Block.LavaKill(by) && !Block.NeedRestart(by)) && by != Block.glass)
                                {
                                    break;
                                }
                            }
                            else if (p.level.physics >= 3)
                            {
                                if (by != Block.glass)
                                {
                                    p.level.MakeExplosion(pos.x, pos.y, pos.z, 1);
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    p.level.Blockchange(pos.x, pos.y, pos.z, type);
                    previous.Add(pos);
                    allBlocks.Add(pos);

                    bool comeOut = false;
                    foreach (Player pl in Player.players)
                    {
                        if (pl.level == p.level)
                        {
                            if ((ushort)(pl.pos[0] / 32) == pos.x || (ushort)(pl.pos[0] / 32  + 1) == pos.x || (ushort)(pl.pos[0] / 32 - 1) == pos.x)
                            {
                                if ((ushort)(pl.pos[1] / 32) == pos.y || (ushort)(pl.pos[1] / 32 + 1) == pos.y || (ushort)(pl.pos[1] / 32 - 1) == pos.y)
                                {
                                    if ((ushort)(pl.pos[2] / 32) == pos.z || (ushort)(pl.pos[2] / 32 + 1) == pos.z || (ushort)(pl.pos[2] / 32 - 1) == pos.z)
                                    {
                                        if (p.level.ctfmode && !p.level.ctfgame.friendlyfire && p.team == pl.team)
                                        {
                                            comeOut = true;
                                            break;
                                        }
                                        if (p.level.ctfmode)
                                        {
                                            pl.health = pl.health - 25;
                                            if (pl.health > 0)
                                            {
                                                pl.SendMessage("You have been shot!  You have &c" + pl.health + Server.DefaultColor + " health remaining.");
                                                comeOut = true;
                                                break;
                                            }
                                        }


                                        if (p.level.physics >= 3 && bp.ending >= 2)
                                            pl.HandleDeath(Block.stone, " was blown up by " + p.color + p.name, true);
                                        else
                                            pl.HandleDeath(Block.stone, " was shot by " + p.color + p.name);
                                        comeOut = true;
                                        
                                        

                                    }
                                }
                            }
                        }
                    }
                    if (comeOut) break;

                    if (t > 12 && bp.ending != 3)
                    {
                        pos = previous[0];
                        p.level.Blockchange(pos.x, pos.y, pos.z, Block.air);
                        previous.Remove(pos);
                    }
                    
                    if (bp.ending != 3) Thread.Sleep(20);
                }

                if (bp.ending == -1)
                    try
                    {
                        unchecked { p.SendPos((byte)-1, (ushort)(previous[previous.Count - 3].x * 32), (ushort)(previous[previous.Count - 3].y * 32 + 32), (ushort)(previous[previous.Count - 3].z * 32), p.rot[0], p.rot[1]); }
                    } catch { }
                if (bp.ending == 3) Thread.Sleep(400);

                foreach (CatchPos pos1 in previous)
                {
                    p.level.Blockchange(pos1.x, pos1.y, pos1.z, Block.air);
                    if (bp.ending != 3) Thread.Sleep(20);
                }
            }));
            gunThread.Start();
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/gun [at end] - Allows you to fire bullets at people");
            Player.SendMessage(p, "Available [at end] values: &cexplode, destroy, laser, tp");
        }

        public struct CatchPos { public ushort x, y, z; }
        public struct Pos { public ushort x, y, z; public int ending; }
    }
}
