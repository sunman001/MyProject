using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public class RealSubject : ISubject
    {
        public RealSubject ()
        {
              
         }
        public void Dosomething()
        {
            Thread.Sleep(2000);
            Console.WriteLine("买票");
            //Console.WriteLine("日志");
        }

        public bool GetSomething()
        {
            Console.WriteLine("是否有票");
            return true;
        }
    }
}
