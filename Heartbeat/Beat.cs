using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCDek
{
    public interface Beat
    {
        string URL { get; }
        string Parameters { get; set; }
        bool Log { get; }

        void Prepare();
        void OnPump(string line);

    }
}