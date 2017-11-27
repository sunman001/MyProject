using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class GalaxyBridge : BasePhoneBridge
    {
        public override void Call()
        {
           Console.WriteLine("User OS {0}.{1}.{2}",this.GetType().Name,this.System ,this.Version);
        }

      
        public override void Text()
        {
            Console.WriteLine("User OS {0}.{1}.{2}", this.GetType().Name, this.System, this.Version);
        }

       
    }
}
