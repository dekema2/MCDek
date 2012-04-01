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
using MCDek;
namespace MCLawl
{
    public class CmdBind : Command
    {
        public override string name { get { return "bind"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public CmdBind() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            if (message.Split(' ').Length > 2) { Help(p); return; }
            message = message.ToLower();
            if (message == "clear")
            {
                for (byte d = 0; d < 128; d++) p.bindings[d] = d;
                Player.SendMessage(p, "All bindings were unbound.");
                return;
            }

            int pos = message.IndexOf(' ');
            if (pos != -1)
            {
                byte b1 = Block.Byte(message.Substring(0, pos));
                byte b2 = Block.Byte(message.Substring(pos + 1));
                if (b1 == 255) { Player.SendMessage(p, "There is no block \"" + message.Substring(0, pos) + "\"."); return; }
                if (b2 == 255) { Player.SendMessage(p, "There is no block \"" + message.Substring(pos + 1) + "\"."); return; }

                if (!Block.Placable(b1)) { Player.SendMessage(p, Block.Name(b1) + " isn't a special block."); return; }
                if (!Block.canPlace(p, b2)) { Player.SendMessage(p, "You can't bind " + Block.Name(b2) + "."); return; }
                if (b1 > (byte)64) { Player.SendMessage(p, "Cannot bind anything to this block."); return; }

                if (p.bindings[b1] == b2) { Player.SendMessage(p, Block.Name(b1) + " is already bound to " + Block.Name(b2) + "."); return; }

                p.bindings[b1] = b2;
                message = Block.Name(b1) + " bound to " + Block.Name(b2) + ".";

                Player.SendMessage(p, message);
            }
            else
            {
                byte b = Block.Byte(message);
                if (b > 100) { Player.SendMessage(p, "This block cannot be bound"); return; }

                if (p.bindings[b] == b) { Player.SendMessage(p, Block.Name(b) + " isn't bound."); return; }
                p.bindings[b] = b; Player.SendMessage(p, "Unbound " + Block.Name(b) + ".");
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/bind <block> [type] - Replaces block with type.");
            Player.SendMessage(p, "/bind clear - Clears all binds.");
        }
    }
}