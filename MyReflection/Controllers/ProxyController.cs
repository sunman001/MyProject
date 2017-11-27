using ProxyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyReflection.Controllers
{
    /// <summary>
    /// 1、代理模式proxy
    /// 2、AOP:日志代理、延迟代理、权限代理、单列代理、缓存代理
    /// 
    /// 行为型设计模式：关注对象和行为分离
    /// 延迟：按需获取，只有到真的需要的时候，才去占用资源
    /// 缓存：第一次正常获取 ，第二页在缓存中获取
    /// 
    /// 行为型设计模式：关注对象和行为分离
    /// AOP:面向切面编程 (在不修改业务逻辑之外 增加额外的需求) 
    /// WebService
    /// MVC filter
    /// </summary>
    public class ProxyController : Controller
    {
        // GET: Proxy
        public ActionResult Index()
        {
            ISubject _subject = new RealSubject();//持有资源
            Console.WriteLine("dosomething else");//一直占用资源
            Console.WriteLine("dosomething else");
            Console.WriteLine("dosomething else");
            _subject.Dosomething();
            _subject.GetSomething();

            ISubject _Proxysubject = new ProxySubject();
            Console.WriteLine("dosomething else");
            _Proxysubject.Dosomething();//使用的时候调用
            _Proxysubject.GetSomething();
            return View();
        }
    }
}