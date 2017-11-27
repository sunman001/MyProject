using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class Galaxy : BasePhone
    {
        public override void Call()
        {
           Console.WriteLine("User OS {0}.{1}.{2}",this.GetType().Name,this.System() ,this.Version());
        }

        public override string System()
        {
            return "Android";
        }

        public override void Text()
        {
            Console.WriteLine("User OS {0}.{1}.{2}", this.GetType().Name, this.System(), this.Version());
        }

        public override string Version()
        {
            return "6.0";
        }
    }
}
