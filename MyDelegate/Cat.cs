using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegate
{
    /// <summary>
    /// 猫叫 
    /// 导致 狗叫 老鼠跑等
    /// 委托是一种类型，事件是一个实例，带EVENT关键字的实例
    /// </summary>
   public  class Cat
    {
        public CatMiaoHandler CatMiaoHandlerMethod;//委托实列
        public event CatMiaoHandler CatMiaoHandlerMethodEvent;//声明事件，事件的本质就是委托一个实例，加了event关键字修饰
        //委托是一种类型 事件是委托类型的实列
        public void Miao()
        {
            Console.WriteLine("猫叫了一声");
            CatMiaoHandlerMethod?.Invoke();
            CatMiaoHandlerMethodEvent?.Invoke();
            //Dog.Wang();
            //Mouse.Run();
        }
    }
    public delegate void CatMiaoHandler();
}
