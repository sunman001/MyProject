using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /// <summary>
    /// 通过组合对象适配器模式
    /// 组合优于继承
    /// 比较灵活
    /// </summary>

    public class RedistHelperObject : IHelper
    {
        // private RedisHelper _redisHelper = new RedisHelper();
        private RedisHelper _redisHelper=null;

        public RedistHelperObject(RedisHelper redisHelper)
        {
            this._redisHelper = redisHelper;
        }
        public void add<T>()
        {
            this._redisHelper.Add<T>();
        }

        public void update<T>()
        {
            this._redisHelper.Upadte<T>();
        }
    }
}
