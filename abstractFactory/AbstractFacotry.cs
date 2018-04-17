using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractFactory
{
    /// <summary>
    /// 人族--暗夜--兽族
    /// 魏 蜀 吴
    /// </summary>
   public abstract  class AbstractFacotry
    {
      public abstract   IRace CreateFirst();
        public abstract IRace CreateTwo();
        public abstract IRace CreateTrhee();
     

    }
}
