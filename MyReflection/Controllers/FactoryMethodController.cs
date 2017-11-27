using FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyReflection.Controllers
{
    /// <summary>
    /// 开闭原则（对扩展开放，对修改关闭）
    /// 每个类创建一个工厂 就是工厂方法
    /// 1、对象的创建转移到工厂里面去
    /// 2、完美支持开闭原则（对扩展开放，对修改关闭）
    /// 缺点：代码很多
    /// 如果对象创建复杂/创建过程可能变化/创建过程可能需要扩展
    /// 
    /// </summary>
    public class FactoryMethodController : Controller
    {
        /// <summary>
        /// 工厂方法
        /// </summary>
        /// <returns></returns>
        // GET: FactoryMethod
        public ActionResult Index()
        {
          //  HumanFactory humanfactory = new HumanFactory();
            IRace irace = HumanFactory.CreateHumanFactory();
            //使用接口
            IFartoryMehod humamfactory = new HumanFactory();
            IRace iraces = humamfactory.CreateFactoy();
            return View();
        }
    }
}