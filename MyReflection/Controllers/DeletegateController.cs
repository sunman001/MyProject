using MyDelegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestLambda;
using TOOL;
using static MyDelegate.GreetingClass;

namespace MyReflection.Controllers
{
    public class DeletegateController : Controller
    {
       
        // GET: Deletegate
        public ActionResult Index()
        {
            DeletegateClass.Show();
            GreetingClass.Greeting("波波",PeopleType.chinese);//普通调用

            GreetingHandler handel = new GreetingHandler(GreetingClass.GreetingChinese);//委托实列化 方法作为参数传入
           // GreetingHandler h = GreetingClass.GreetingChinese;
            GreetingClass.Greeting("波波", handel);
            //用action 代替委托方法 可省去声明委托一步（没有返回参数）
            //Action<string> action = GreetingClass.GreetingChinese;
            //GreetingClass.Greeting("波波",action);//委托调用
            Action act1 = () => { };//没有参数，就是一个小括号，没有方法体 就是一个大括号(可以有16个参数)
            Action<string>act2 = a => Console.WriteLine(a);//只有一个参数 可以去掉小括号
            Func<int> func1 = () => DateTime.Now.Day;//如果方法体只有一行 ，可以去掉大括号、分号、return
            Func<int ,string> func2=i=>i.ToString();//可以有16个参数

            Type type = typeof(Cat);//找到类型
            var obj = Activator.CreateInstance(type);
            Cat cat = (Cat)obj;
            cat.Miao();
            cat.CatMiaoHandlerMethod = Dog.Wang;
            cat.CatMiaoHandlerMethod += Mouse.Run;
            cat.CatMiaoHandlerMethod += Baby.Kry;
            //cat.CatMiaoHandlerMethod();
            cat.Miao();
            // cat.CatMiaoHandlerMethodEvent = new CatMiaoHandler(Dog.Wang);//事件不能被初始化
            cat.CatMiaoHandlerMethodEvent += Dog.Wang;
            cat.CatMiaoHandlerMethodEvent += Mouse.Run;
            cat.CatMiaoHandlerMethodEvent += Baby.Kry;
            cat.Miao();
            //cat.CatMiaoHandlerMethodEvent();//不能被外部调用
            //linq 调用
            LinqTest liqntest = new LinqTest();
            liqntest.Methods();
            liqntest.Sort();

            DelegateExtend extend = new DelegateExtend();
            extend.Test();
            DBHelperSQL sqlhelper = new DBHelperSQL();
            sqlhelper.insert("Insert into jmp_app (a_user_id,a_name,a_platform_id,a_paymode_id,a_apptype_id,a_key,a_notifyurl)values (1,'1222222',1,1,1,23,11111)");


            return View();
        }
    }
}