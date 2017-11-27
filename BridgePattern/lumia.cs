using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class lumia : BasePhone
    {
        public override void Call()
        {
            throw new NotImplementedException();
        }

        public override string System()
        {
            return "winform";
        }

        public override void Text()
        {
            throw new NotImplementedException();
        }

        public override string Version()
        {
            return "6.0";
        }
    }
}
