using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractFactory
{
   public  class Orc:IRace
    {
        public void ShowKing()
        {
            Console.WriteLine("欢迎你");
        }
    }
}
