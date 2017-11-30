using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /// <summary>
    /// 通过继承的方式可以重复使用 不可改变
    /// 类识别器
    /// 继承是强耦合 和父类绑死的 
    /// </summary>
    public class RedistHelperClass : RedisHelper, IHelper
    {
        public void add<T>()
        {
            base.Add<T>();
        }

        public void update<T>()
        {
            base.Upadte<T>();
        }
    }
}
