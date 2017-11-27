using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySingleton
{
    /// <summary>
    /// 单列模式：保证进程该对象只有一个实列
    /// 
    /// 一个类只能实例化一次要用单例模式
    /// 静态变量在内存中只会存在一次
    /// </summary>    
    public class Singleton
    {
        //private bool IsInit = false;//每次调用都是False
        private static bool IsInit = false;//第一次False,后面TRUE
        private long LResult = 0;
        private static object Singleton_Lock = new object();
        public int Id { get; set; }
        public void SayHi()
        {
            Console.WriteLine("您好");
        }
        private Singleton()
        {
           // lock (Singleton_Lock)
           // {
               // if (IsInit == false)
              //  {
                    for (int j = 0; j < 100000000; j++)
                    {
                        LResult += j;
                    }
                     Console.WriteLine("在这里被初始化了，LResult={0},TrheadId={1}", LResult, Thread.CurrentThread.ManagedThreadId);
                    IsInit = true;

               // }
               // else
               // {
                    Console.WriteLine("LResult={0},ThreadId={1}",LResult,Thread.CurrentThread.ManagedThreadId);
              //  }
          ///  }
        }

        private static Singleton _Singleton = null;
        //创建个实例化的方法
        public static Singleton CreateInstance()
        {
            if (_Singleton == null)//先看看是否初始化过 不需要等待锁
            {
                lock (Singleton_Lock)//加锁一开始线程都等待这里
                {
                    if (_Singleton == null)//还是检查是否为空
                    {
                        _Singleton = new Singleton();
                    }
                }
            }
            return _Singleton;
        }
    }
}
