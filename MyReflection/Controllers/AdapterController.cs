using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyReflection.Controllers
{
    /// <summary>
    /// 适配器模式属于结构式模式（对象与对象的关系）
    /// 适配器解决 某个类与项目中的类不匹配 为了匹配 使用适配器 
    /// 通过新增一个类 不修改原有的代码 这样就是适配器模式
    /// 对象适配器 和 类适配器
    /// 
    /// </summary>
    public class AdapterController : Controller
    {
        // GET: Adapter
        public ActionResult Index()
        {
            return View();
        }
    }
}