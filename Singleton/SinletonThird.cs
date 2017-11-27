using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingleton
{
  public   class SinletonThird
    {
        private SinletonThird()
        {

        }
        private static SinletonThird _sinletonThird = new SinletonThird();//和静态构造函数类似只能初始化一次
        public static  SinletonThird CreateInstance()
        {
            return _sinletonThird;
        }
    }
}
