using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 一个代理，完全可以完成购买和查询火车票的功能
    /// 包一层：没有什么技术
    /// </summary>
    public class ProxySubject : ISubject
    {
        // private   ISubject _subject = new RealSubject();
        private ISubject _Isbject = null;//可做到延迟 需要的时候实例化
        private static bool GetSomethingCache = false;//缓存结果
        private static bool IsInit = false;//数据有没有第一次获取
        public void Dosomething()
        {
            if(this._Isbject==null)
            {
                _Isbject = new RealSubject();
            }
           
               this._Isbject.Dosomething();
            Console.WriteLine("finsih Dosomething");//日志

        }

        public bool GetSomething()
        {
            if (this._Isbject == null)
            {
                _Isbject = new RealSubject();
            }
            if (!IsInit)
            {
                GetSomethingCache = this._Isbject.GetSomething();//缓存
                IsInit = true;
            }
            bool result= _Isbject.GetSomething();
            Console.WriteLine("finsih GetSomething");//日志
            return result;
        }
    }
}
