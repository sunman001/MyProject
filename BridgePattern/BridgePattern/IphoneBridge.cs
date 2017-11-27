using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class IphoneBridge : BasePhoneBridge
    {
        public override void Call()
        {
            Console.WriteLine("",this.GetType().Name,this.System ,this.Version);
        }

       

        public override void Text()
        {
            Console.WriteLine("", this.GetType().Name, this.System, this.Version);
        }

      
    }
}
