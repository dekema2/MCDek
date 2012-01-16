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
using System.Text;

namespace MCLawl
{
    public class Report
    {
        string name, ip, reason;

        public string Name { get { return name; } }
        public string IP { get { return ip; } }
        public string Reason { get { return reason; } }

        public Report(Player p, string reason)
        {
            name = p.name;
            ip = p.ip;
            this.reason = reason;
        }
    }
}
