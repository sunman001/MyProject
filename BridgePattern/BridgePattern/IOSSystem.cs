using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgePattern
{
    public class IOSSystem : Isystem, Iversion
    {
        public   string IVersion()
        {
            return "6.0";
        }

        public string System()
        {
            return "IOS";
        }
    }
}
