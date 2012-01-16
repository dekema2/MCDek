/*
	Copyright 2010 MCLawl Team - Written by Valek
 
    Licensed under the
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

namespace MCLawl
{
    public class CmdFixGrass : Command
    {
        public override string name { get { return "fixgrass"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "moderation"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdFixGrass() { }

        public override void Use(Player p, string message)
        {
            int totalFixed = 0;

            switch (message.ToLower())
            {
                case "":
                    for (int i = 0; i < p.level.blocks.Length; i++)
                    {
                        try
                        {
                            ushort x, y, z;
                            p.level.IntToPos(i, out x, out y, out z);

                            if (p.level.blocks[i] == Block.dirt)
                            {
                                if (Block.LightPass(p.level.blocks[p.level.IntOffset(i, 0, 1, 0)]))
                                {
                                    p.level.Blockchange(p, x, y, z, Block.grass);
                                    totalFixed++;
                                }
                            }
                            else if (p.level.blocks[i] == Block.grass)
                            {
                                if (!Block.LightPass(p.level.blocks[p.level.IntOffset(i, 0, 1, 0)]))
                                {
                                    p.level.Blockchange(p, x, y, z, Block.dirt);
                                    totalFixed++;
                                }
                            }
                        }
                        catch { }
                    } break;
                case "light":
                    for (int i = 0; i < p.level.blocks.Length; i++)
                    {
                        try
                        {
                            ushort x, y, z; bool skipMe = false;
                            p.level.IntToPos(i, out x, out y, out z);

                            if (p.level.blocks[i] == Block.dirt)
                            {
                                for (int iL = 1; iL < (p.level.depth - y); iL++)
                                {
                                    if (!Block.LightPass(p.level.blocks[p.level.IntOffset(i, 0, iL, 0)]))
                                    {
                                        skipMe = true; break;
                                    }
                                }
                                if (!skipMe)
                                {
                                    p.level.Blockchange(p, x, y, z, Block.grass);
                                    totalFixed++;
                                }
                            }
                            else if (p.level.blocks[i] == Block.grass)
                            {
                                for (int iL = 1; iL < (p.level.depth - y); iL++)
                                {
                                    if (Block.LightPass(p.level.blocks[p.level.IntOffset(i, 0, iL, 0)]))
                                    {
                                        skipMe = true; break;
                                    }
                                }
                                if (!skipMe)
                                {
                                    p.level.Blockchange(p, x, y, z, Block.dirt);
                                    totalFixed++;
                                }
                            }
                        }
                        catch { }
                    } break;
                case "grass":
                    for (int i = 0; i < p.level.blocks.Length; i++)
                    {
                        try
                        {
                            ushort x, y, z;
                            p.level.IntToPos(i, out x, out y, out z);

                            if (p.level.blocks[i] == Block.grass)
                                if (!Block.LightPass(p.level.blocks[p.level.IntOffset(i, 0, 1, 0)]))
                                {
                                    p.level.Blockchange(p, x, y, z, Block.dirt);
                                    totalFixed++;
                                }
                        }
                        catch { }
                    } break;
                case "dirt":
                    for (int i = 0; i < p.level.blocks.Length; i++)
                    {
                        try
                        {
                            ushort x, y, z;
                            p.level.IntToPos(i, out x, out y, out z);

                            if (p.level.blocks[i] == Block.dirt)
                                if (Block.LightPass(p.level.blocks[p.level.IntOffset(i, 0, 1, 0)]))
                                {
                                    p.level.Blockchange(p, x, y, z, Block.grass);
                                    totalFixed++;
                                }
                        }
                        catch { }
                    } break;
                default:
                    Help(p);
                    return;
            }

            Player.SendMessage(p, "Fixed " + totalFixed + " blocks.");
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/fixgrass <type> - Fixes grass based on type");
            Player.SendMessage(p, "<type> as \"\": Any grass with something on top is made into dirt, dirt with nothing on top is made grass");
            Player.SendMessage(p, "<type> as \"light\": Only dirt/grass in sunlight becomes grass");
            Player.SendMessage(p, "<type> as \"grass\": Only turns grass to dirt when under stuff");
            Player.SendMessage(p, "<type> as \"dirt\": Only turns dirt with nothing on top to grass");
        }
    }
}