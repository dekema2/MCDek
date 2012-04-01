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
    public class CmdRoll : Command
    {
        public override string name { get { return "roll"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdRoll() { }

        public override void Use(Player p, string message)
        {
            int min, max; Random rand = new Random();
            try { min = int.Parse(message.Split(' ')[0]); }
            catch { min = 1; }
            try { max = int.Parse(message.Split(' ')[1]); }
            catch { max = 7; }

            Player.GlobalMessage(p.color + p.name + Server.DefaultColor + " rolled a &a" + rand.Next(Math.Min(min, max), Math.Max(min, max) + 1).ToString() + Server.DefaultColor + " (" + Math.Min(min, max) + "|" + Math.Max(min, max) + ")");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/roll [min] [max] - Rolls a random number between [min] and [max].");
        }
    }
}