using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgePattern
{
    public class WindfromSystem : Isystem, Iversion
    {
        public string IVersion()
        {
            throw new NotImplementedException();
        }

        public string System()
        {
            throw new NotImplementedException();
        }
    }
}
