
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesignPattern.SimpleFactory;
using SimpleFactory.getName;
using static DesignPattern.SimpleFactory.Factory;


namespace MyReflection.Controllers
{
    /// <summary>
    /// 上端
    /// 高类聚低耦合
    /// </summary>
    public class SimpleFactoryController : Controller
    {
        /// <summary>
        /// 简单工厂
        /// 设计模式是为了解决一类的问题，不同的设计模式解决不同的问题
        /// </summary>
        /// <returns></returns>
        // GET: SimpleFactory
        public ActionResult Index()
        {
            ///前端可以输入 “fistname lastname”或者“lastname,firstname”
            string name = "";//模拟前端输入的姓名
            GetName getname = NameFactory.CreateNameFactory(name);
            var firtName = getname.getFirstName();
            var lastName = getname.getLastName();

            //1、这种写法 上下端耦合 面向细节           
            Human human = new Human();
            human.ShowKing();
            Orc orc = new Orc();
            orc.ShowKing();
            //目标面向抽象 屏蔽细节
            //这种方式还有细节
            IRace ihuman = new Human();
            ihuman.ShowKing();

            //这种属于简单工厂
            IRace humanFactory = Factory.CreateFactory(RaceType.Human);
            humanFactory.ShowKing();

            //web.cong指令
            IRace iRace = Factory.CreateFactoryConfig();
            iRace.ShowKing();
            //反射
            IRace Irace = Factory.CreateInstance();
            Irace.ShowKing();
            return View();
        }
    }
}