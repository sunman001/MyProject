using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractFactory
{
    /// <summary>
    /// 一个工厂三大种族
    /// </summary>
   public  class WarnFactory:AbstractFacotry
    {
        public override IRace CreateFirst()
        {
            return new Human();
        }

        public override IRace CreateTrhee()
        {
            return new Orc();
        }

        public override IRace CreateTwo()
        {
            throw new NotImplementedException();
        }
    }

      
    
}
