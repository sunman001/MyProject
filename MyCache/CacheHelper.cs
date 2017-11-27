using System;
using System.Net.Configuration;
using System.Runtime.Caching;
namespace MyCache
{

    public class CacheHelper
    {
        private static readonly object Singleton_Lock = new object();
        private static readonly object _objectCahe = new object();

        private static CacheHelper cacheHelper = null;

        private CacheHelper()
        {

        }

        public static CacheHelper Single
        {
            get { return cacheHelper ?? (cacheHelper = new CacheHelper()); }
        }

        public static CacheHelper SingelLock
        {
            get
            {
                if (cacheHelper == null)
                {
                    lock (Singleton_Lock)
                    {
                        if (cacheHelper == null)
                        {
                            cacheHelper = new CacheHelper();
                        }
                    }
                }
                return cacheHelper;
            }
        }

        /// <summary>
        /// 判断是否已存在缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsCache(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("缓存键不能为空");
            try
            {
                if (MemoryCache.Default[key] == null)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        /// <summary>
        /// 释放默认缓存
        /// </summary>
        public static void RelaseCache()
        {
            MemoryCache.Default.Dispose();
        }

        /// <summary>
        /// 新增缓存
        /// </summary>
        /// <typeparam name="T">缓存值</typeparam>
        /// <param name="t"></param>
        /// <param name="key">缓存Key值</param>
        /// <param name="time">返回缓存值</param>
        /// <returns></returns>
        public static T CacheOjbectLocak<T>(T t, string key, double time = 0.0)
        {
            if (t == null)
            {
                throw new ArgumentException("缓存数据不能为空");
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("缓存区不能为空");
            }
            T objectValue = default(T);
            try
            {
                if (MemoryCache.Default[key] == null)
                {
                    lock (Singleton_Lock)
                    {
                        if (MemoryCache.Default[key] == null)
                        {
                            objectValue = t;
                            var item = new CacheItem(key, objectValue);
                            var policy = new CacheItemPolicy();
                            if (time > 0)
                            {
                                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(time);
                            }
                            policy.Priority = CacheItemPriority.Default;
                            MemoryCache.Default.Add(item, policy);
                        }
                    }
                }
                else
                {
                    objectValue = (T)MemoryCache.Default[key];
                }

            }
            catch (Exception ex)
            {
                MemoryCache.Default.Dispose();
                throw new Exception("缓存失败，错误信息：" + ex.Message);
            }
            return objectValue;
        }
        /// <summary>
        /// 缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="key"></param>
        /// <param name="time"></param>
        /// <returns>返回缓存值</returns>
        public static T UpdateCacheObjectLocak<T>(T t, string key, double time = 0.0)
        {
            if (t == null)
            {
                throw new ArgumentException("缓存数据不能为空");
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("缓存键不能为空");
            }
            T objectValue = default(T);
            try
            {
                if (MemoryCache.Default[key] == null)
                {
                    lock (_objectCahe)
                    {
                        if (MemoryCache.Default[key] == null)
                        {
                            objectValue = t;
                            var item = new CacheItem(key, objectValue);
                            var policy = new CacheItemPolicy();
                            if (time > 0)
                            {
                                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(time);

                            }
                            policy.Priority = CacheItemPriority.Default;
                            MemoryCache.Default.Add(item, policy);
                        }
                    }


                }
                else
                {
                    lock (_objectCahe)
                    {
                        MemoryCache.Default.Remove(key);
                        if (MemoryCache.Default[key] == null)
                        {
                            objectValue = t;
                            var item = new CacheItem(key, objectValue);
                            var policy = new CacheItemPolicy();
                            if (time > 0)
                            {
                                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(time);

                            }
                            policy.Priority = CacheItemPriority.Default;
                            MemoryCache.Default.Add(item, policy);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                MemoryCache.Default.Dispose();
                throw new Exception(e.Message);

            }
            return objectValue;
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetCaChe<T>(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new Exception("key键不能为空");
            if (MemoryCache.Default[key] == null) throw new Exception("key键没有缓存数据");
            return (T)MemoryCache.Default[key];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <param name="func">委托</param>
        /// <returns></returns>
        public static T CachGet<T>(string key, Func<T> func)
        {
            T result = default(T);//准备一个结果集
            if (CustomCache.Exist(key))
            {
                result = CustomCache.Get<T>(key);
            }
            else
            {
                result = func.Invoke();
                CustomCache.Add(key, result);
            }
            return result;
        }

    }
}
