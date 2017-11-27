using PrototypePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyReflection.Controllers
{
    /// <summary>
    /// 原型模式
    /// 原型模式：创建型设计模行，关注对象的创建
    /// new一次实列 通过原型COPY 可获取多个实列
    /// 按需更新 
    /// </summary>
    public class PrototypeController : Controller
    {
        // GET: YUXING
        public ActionResult Index()
        {
            StudentPrototype student1 =StudentPrototype.CreateTance();
            student1.Id = 3;
            student1.Name = "111";//=new string("111");
            //字符串在内存上是不可变得，每一次都是一个new的动作
            student1.Class.ClassId = 2;
            student1.Class.ClassName = "测试";
            StudentPrototype student2 = StudentPrototype.CreateTance();
            student2.Id = 4;
            student2.Name = "444";
            student2.Class.ClassId = 4;
            student2.Class.ClassName = "4测试";

            StudentPrototype student3 = StudentPrototype.CreateInstanceSerialize();
            student3.Id = 6;
            student3.Name = "666";//=new string("111");
            //字符串在内存上是不可变得，每一次都是一个new的动作
            student3.Class.ClassId = 6;
            student3.Class.ClassName = "666";
            StudentPrototype student4 = StudentPrototype.CreateInstanceSerialize();
            student4.Id = 7;
            student4.Name = "7";
            student4.Class.ClassId = 7;
            student4.Class.ClassName = "7777";

            return View();
        }
    }
}