using MyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MyReflection.Controllers
{
    /// <summary>
    /// Cache 
    /// 缓存：就是为了快速获取结果，获取过一次之后,二次获取速度快
    /// 网站性能优化的第一步就是使用缓存
    /// 缓存的缺点：实时性不够是最大的缺点
    /// 
    /// </summary>
    public class CacheController : Controller
    {
        // GET: Cache
        public ActionResult Index()
        {
            //自己实现缓存


            for (int i=0;i<5;i++)
            {
                string key = string.Format("{0}_{1}_{2}", "Program", "Count", 13);
                int iResult = 0;
                if (CustomCache.Exist(key))
                {
                    iResult = CustomCache.Get<int>(key);
                }
                else
                {
                    iResult = Count(13);
                    CustomCache.Add(key , iResult);
                }

                Console.WriteLine("这里是第{0}次获取数据，结果为{1}",i,Count(12));
            }
            
            //使用内置缓存类方法如下：
            {
             string CacheKey = "CacheKey001";
            if (CacheHelper.IsCache(CacheKey))//判断缓存是否存在
            {
                int a = 0;
                a = CacheHelper.GetCaChe<int>(CacheKey);//获取缓存

            }
            else
            {
                CacheHelper.CacheOjbectLocak<int>(1, CacheKey, 0);//存入缓存
            }   
            }
            
            return View();
        }

        /// <summary>
        /// 模拟一个耗时的请求，数据库/远程接口/本地硬盘
        /// </summary>
        /// <returns></returns>
        private static int Count(int j)
        {
            int iResult = 0;
            for (int i=0;i<j;i++)
            {
                iResult += i;
            }
            Thread.Sleep(2000);
            return iResult;
        }
    }
}