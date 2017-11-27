
using MyNew;
using System.Web.Mvc;
using TOOL;

namespace MyReflection.Controllers
{
    public class MyNewController : Controller
    {
        /// <summary>
        /// new 
        /// 1、作为运算符，用于创建对象和调用构造函数
        /// 2、作为修饰符，用于向基类成员隐藏继承成员
        /// 3、作为约束，用于在泛型声明中约束可能用作类型参数的参数的类型（new约束指定泛型类声明中的任何类型参数都必须有公共的无参数构造函数，当泛型类创建类型的新实列时，将此约束应用于类型参数）
        /// new 作为约束和其他约束共存时，必须在最后指定
        /// 4、使用new实现多态，
        /// a、new 一个Class 时 ，new完成了一下两个方面的内容，一是调用newobj命令来为实例在托管中分配内存，而是调用构造函数来实现对象初始化
        /// b、new 一个struct 时 ，new运算符用于调用其带构造函数，完成实列的初始化
        /// c、new 一个INT时，new运算符用于初始化其值为0
        /// 值类型分配于线程的堆栈（stack）上，并变量本身就保存其实值，因此也不受GC得控制，而引用类型变量，包含了指向托管堆的引用，内存分配于托管堆（managed heap ）上，内存收集由GC完成
        /// 
        /// </summary>
        /// <returns></returns>

        // GET: MyNew
        public ActionResult Index()
        {
            Nmuber nmuber = new Nmuber();
            IntNumber intnumber = new IntNumber();
            Nmuber basenumber = new IntNumber();
            basenumber.ShowInfo();//调用IntNumber的方法
            basenumber.ShowNumber();//调用IntNumber的方法

            MyGenericerTest myGenericerTest = new MyGenericerTest();
            myGenericerTest.Test();
            AdoClass adoclass = new AdoClass();
            adoclass.Get();

            return View();
        }
    }
}