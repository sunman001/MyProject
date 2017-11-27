using DB.Interface;
using DB.Model;
using DB.Sqlserver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using MyReflection.Models;

namespace MyReflection.Controllers
{
   /// <summary>
   /// 1、反射的介绍 和原理（反射可动态的加载可配置可扩展 缺点：损耗性能）
   /// 2、通过反射获取信息、创建 对象、调用方法
   /// 3、实现程序的可配置
   /// 
   /// 1、依懒接口、完成可配置可扩展
   /// 2、去掉接口、反射调用方法、包括私有方法
   /// 3、反射破坏单例
   /// 
   /// 1、反射获取属性和赋值
   /// 2、封装数据库访问层
   /// 
   /// 反射的优点：动态加载
   /// 反射的缺点：1、代码多，使用复杂
   ///             2、避开编译器的检查
   ///             3、效率
   ///              快400倍的性能差异
   ///               100w次 8100ms 100次 0.8ms 绝对值很小
   ///               空间换时间，性能优化后，大概10倍差异，绝对值更小
   /// </summary>
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            //常规的做法
            // IDBHelper DBHelpers = new DBHelper();//先初始化再执行构造方法
            //DBHelpers.Query();

            IDBHelper idbhelper = SimleFactory.CreateFactory();//调用封装的反射方法
            idbhelper.Query();
            {
            string name = ConfigurationManager.AppSettings["name"];//从配置文件动态获取
            string[] nameArray = name.Split(',');
           Assembly assembly = Assembly.Load(nameArray[1]);//反射的入口 动态的加载dll
            Type dbHelperType = assembly.GetType(nameArray[0]);//基于类的完整名称 找出类型
            object oDBHelper = Activator.CreateInstance(dbHelperType);//根据类型，创建对象 编译器能识别的静态类型是object
            //下面一句话可以替代上面三句话
           // object obj = Activator.CreateInstance(nameArray[1], nameArray[0]).Unwrap();

            foreach(MethodInfo method in dbHelperType.GetMethods()) //用 MethodInfo可以找出此类型的所有方法 GetMethods
            {
                Console.WriteLine("名称：{0}",method.Name);
            }
            MethodInfo query = dbHelperType.GetMethod("Query", new Type[] { });//根据名字，找到此方法(无参)
            query.Invoke(oDBHelper, null);//调用此方法
            MethodInfo queryint = dbHelperType.GetMethod("Query", new Type[] { typeof(int) });//int重载的需要传入对应的参数类型，系统会调用对应的方法
            queryint.Invoke(oDBHelper, new object[] { 11 });
            MethodInfo querystring = dbHelperType.GetMethod("Query", new Type[] { typeof(string) });//string 
            querystring.Invoke(oDBHelper, new object[] { "name" });
            MethodInfo querystring1 = dbHelperType.GetMethod("Query", new Type[] { typeof(int), typeof(string) });//string 
            querystring1.Invoke(oDBHelper, new object[] { 11, "name" });
            MethodInfo query1 = dbHelperType.GetMethod("Query2", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);//可访问私有方法
            query1.Invoke(oDBHelper, new object[] { });
            IDBHelper dbHelperReflection = (IDBHelper)oDBHelper;//类型转换  is  然后as 强制转换 通过接口获取方法
            dbHelperReflection.Query();//完成方法的调用
            
            Type typeSingle = assembly.GetType("DB.MySql.Singleton");
            Object oObjectSingle = Activator.CreateInstance(typeSingle,true);//破坏单例 多次执行

            //常规的做法
            People people = new People();
            people.Id = 11;
            people.Name = "笨小孩";
            Console.WriteLine("Id:{0},Name{0}",people.Id,people.Name);
            // Assembly assemblyp = Assembly.Load("DB.Model");//反射入口
            //object objectP = assembly.GetType("DB.Model.People");//找到类型
            Type type = typeof(People);//找到类型可替代上面的两句代码
            object oObject = Activator.CreateInstance(type);//创建对象
            foreach (var prop in type.GetProperties())//找出此类型的所有属性
            {
              if(prop.Name.Equals("Id"))
                {
                    prop.SetValue(oObject,12);//赋值
                }
              if(prop.Name.Equals("Name"))
                {
                    prop.SetValue(oObject,"test");
                }
             Console.WriteLine("Id:{0},Name{1}", prop.Name ,prop.GetValue(oObject));//prop.Name属性名  GetValue(oObject)获取值
            }

            Type DBHelper = typeof(DBHelper);
            object obj = Activator.CreateInstance(DBHelper);
            IDBHelper dbH = (IDBHelper)obj;
            jmp_app app = dbH.FindBy<jmp_app>(1);

            DBHelper DBHelpers = new DBHelper();
            jmp_app app0 = DBHelpers.FindBy<jmp_app>(1);  
            }
          

            return View();
        }

        
    }
}