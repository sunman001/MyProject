using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInherit
{
   public  class Chicken:Bird
   {
       private string type = "Chicken";

       public override void ShowType()
       {
           Console.WriteLine("Type is {0}", type);
       }

       public void ShowColr()
       {
           Console.WriteLine("Color is {0}",Color);
       }
   }
}
