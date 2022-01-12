using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsConverter
{
    class MainContext
    {
        CmdRun _cmdrun = new CmdRun();
        public CmdRun CmdRun
        { set { } get { return _cmdrun; } }
    }
}
