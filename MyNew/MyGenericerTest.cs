using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNew
{
   public  class MyGenericerTest
    {
        public void Test()
        {
           Genericer<MyCls> mycls = new Genericer<MyCls>();
            var name = mycls.GetItem().Name;

        }
    }
}
