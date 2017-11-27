using MySingleton;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyReflection.Controllers
{
    /// <summary>
    /// 单例模式
    /// 一个类在整个进程中只会实例化一次
    /// </summary>
    public class SingletonController : Controller
    {
        // GET: Singleton
        public ActionResult Index()
        {
            //for(int i=0;i<10;i++) //这样子会实例化10次
            //{
            //Singleton singleton = new Singleton();//实例化 其实是调用构造函数
            //singleton.SayHi();
            //}
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Task> taskList = new List<Task>();//多线程
            TaskFactory taskFactory = new TaskFactory();

            for (int i = 0; i < 10; i++)
            {
                taskList.Add(taskFactory.StartNew(() =>
                {
                    Singleton singleton = Singleton.CreateInstance();
                    singleton.SayHi();
                }));
            }

            Task.WaitAll(taskList.ToArray());
            stopwatch.Stop();
            Console.WriteLine("一共耗时{0}毫秒",stopwatch.ElapsedMilliseconds);
            return View();
        }
    }
}