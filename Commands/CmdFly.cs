/*
	Copyright 2010 MCSharp team (Modified for use with MCZall/MCLawl) Licensed under the
	Educational Community License, Version 2.0 (the "License"); you may
	not use this file except in compliance with the License. You may
	obtain a copy of the License at
	
	http://www.osedu.org/licenses/ECL-2.0
	
	Unless required by applicable law or agreed to in writing,
	software distributed under the License is distributed on an "AS IS"
	BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
	or implied. See the License for the specific language governing
	permissions and limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Threading;
using MCDek;
namespace MCLawl
{
    public class CmdFly : Command
    {
        public override string name { get { return "fly"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdFly() { }

        public override void Use(Player p, string message)
        {
            p.isFlying = !p.isFlying;
            if (!p.isFlying) return;

            Player.SendMessage(p, "You are now flying. &cJump!");

            Thread flyThread = new Thread(new ThreadStart(delegate
            {
                Pos pos;
                List<Pos> buffer = new List<Pos>();
                while (p.isFlying)
                {
                    Thread.Sleep(20);
                    try
                    {
                        List<Pos> tempBuffer = new List<Pos>();

                        ushort x = (ushort)((p.pos[0]) / 32);
                        ushort y = (ushort)((p.pos[1] - 60) / 32);
                        ushort z = (ushort)((p.pos[2]) / 32);

                        try
                        {
                            for (ushort xx = (ushort)(x - 2); xx <= x + 2; xx++)
                            {
                                for (ushort yy = (ushort)(y - 1); yy <= y; yy++)
                                {
                                    for (ushort zz = (ushort)(z - 2); zz <= z + 2; zz++)
                                    {
                                        if (p.level.GetTile(xx, yy, zz) == Block.air)
                                        {
                                            pos.x = xx; pos.y = yy; pos.z = zz;
                                            tempBuffer.Add(pos);
                                        }
                                    }
                                }
                            }

                            List<Pos> toRemove = new List<Pos>();
                            foreach (Pos cP in buffer)
                            {
                                if (!tempBuffer.Contains(cP))
                                {
                                    p.SendBlockchange(cP.x, cP.y, cP.z, Block.air);
                                    toRemove.Add(cP);
                                }
                            }

                            foreach (Pos cP in toRemove)
                            {
                                buffer.Remove(cP);
                            }

                            foreach (Pos cP in tempBuffer)
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
                    }
                    catch { }
                }

                foreach (Pos cP in buffer)
                {
                    p.SendBlockchange(cP.x, cP.y, cP.z, Block.air);
                }

                Player.SendMessage(p, "Stopped flying");
            }));
            flyThread.Start();
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/fly - Allows you to fly");
        }

        struct Pos { public ushort x, y, z; }
    }
}