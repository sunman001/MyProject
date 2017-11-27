using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingleton
{
    /// <summary>
    /// （1、私有构造函数2、声明静态实列3、静态构造函数new 同一个对象 4、静态方法使用同一个对象）
    /// </summary>
    public class SinletonSecond
    {
      
        public long LResult = 0;
        public static SinletonSecond _SinletonSecond = null;
        private SinletonSecond()
        {
          for(int i=0;i<100000000;i++)
            {
                LResult += i;
            }
            Console.WriteLine();
        }
        static SinletonSecond ()//CLR运行时候，第一次使用这个类之前，一定会而且只会执行一次
        {
            _SinletonSecond = new SinletonSecond();
        }
       public static SinletonSecond CreateInstance()
        {
            return _SinletonSecond;
        }
    }
}
