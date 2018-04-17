using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractFactory
{
    /// <summary>
    /// 设计模式：就是平常写代码中的经验和总结
    /// 一个工厂三个种族
    /// </summary>
   public  class ForzeThroneFactory: AbstractFacotry
    {
        public override IRace CreateFirst()
        {
            return new Wei();
        }
        
        public override IRace CreateTrhee()
        {
            return new Shu();
        }

        public override IRace CreateTwo()
        {
            return new Qun();
        }
    }
}
