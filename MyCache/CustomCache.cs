using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCache
{
    public class CustomCache
    {
        /// <summary>
        /// 静态：常驻内存
        /// 字典：多个KEY-VALUE
        /// </summary>
        /// Dictionary 表示键和值得集合【单线程】
        private static Dictionary<string, object> dictionary = new Dictionary<string, object>();//准备字典

        //可能有多线程同时访问的键值集合
        private static ConcurrentDictionary<string, object> concurrentDictionary =
            new ConcurrentDictionary<string, object>();

        

        /// <summary>
        /// 判断是否次KEY的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Exist(string key)
        {
          
            return dictionary.ContainsKey(key);

        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        public static void Add<T>(String key, T t)
        {
            dictionary[key] = t;
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            return (T)dictionary[key];
        }

    }
}
