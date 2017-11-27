using MyAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyReflection.Controllers
{
    /// <summary>
    /// 1、什么是Attribute 
    /// 特性只有通过反射访问
    /// </summary>
    public class AttributeController : Controller
    {
        // GET: Attribute
        public ActionResult Index()
        {
            User user = new User()
            {
              Id=11,
              Name="波波"
            };

            Type type = typeof(User);
            object[]attributeArrary=type.GetCustomAttributes(typeof(CustomerAttribute), true);//获取对应特性的属性
            if(attributeArrary !=null && attributeArrary.Length>0)
            {
                ((CustomerAttribute)attributeArrary[0]).showAttribute();
            }

            string reark=   UserState.Delete.GetReark();
            string Descript = UserState.Frozen.GetDescript();
            return View();
        }
    }
}