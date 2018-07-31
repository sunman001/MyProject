using abstractFactory;
using abstractFactory.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyReflection.Controllers
{
    /// <summary>
    /// 抽象工厂其实就是对产品级的扩展
    /// 延迟 一个工厂用于多个职责
    /// </summary>
    public class AbstractFactoryController : Controller
    {
        // GET: AbstractFactory
        public ActionResult Index()
        {
            //ForzeThroneFactory factory = new ForzeThroneFactory();
            //var human = factory.CreateHuman();//创建对象在工厂里面
            //human.ShowKing();
            ForzeThroneFactory factory = new ForzeThroneFactory();
            IRace huam = factory.CreateFirst();
            huam.ShowKing();
            return View();
        }

        /// <summary>
        /// 计算器
        /// </summary>
        /// <returns></returns>
        public ActionResult Calculator()
        {
            Operation oper;
            oper = OperationFactory.CreateOperate("+");
            oper.NumberA = 1;
            oper.NumberB = 2;
            double result = oper.GetResult();
            return View();
        }
    }
}