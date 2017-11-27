using BridgePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BridgePattern.BridgePattern;

namespace MyReflection.Controllers
{
    public class BridePatternController : Controller
    {
        /// <summary>
        /// 桥接模式【变化封装】
        /// 那里变化就封装那里
        /// 解决多维度的变化
        /// 缺点 ：把变化的逻辑交给了上方
        /// </summary>
        /// <returns></returns>
        // GET: BridePattern
        public ActionResult Index()
        {
            Isystem Android = new AndroidSystem();
            Iversion AndroidVersion = new AndroidSystem();
            Isystem Winform=new WindfromSystem();
            Iversion WinfomVersion=new WindfromSystem();

            BasePhoneBridge phone=new GalaxyBridge();
            phone.System = Android;
            phone.Version = AndroidVersion;
            phone.Call();
            phone.Text();

            BasePhoneBridge lumaxi=new lumiaBridge();
            lumaxi.System = Winform;
            lumaxi.Version = WinfomVersion;

            return View();
        }
    }
}