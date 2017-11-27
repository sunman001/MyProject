using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegate
{
  public    class DelegateExtend
    {
        /// <summary>
        /// Func 是一种委托方法，常用有两个参数，前面的是输入参数，后面的是输出参数
        /// Func最多有16个输入参数，有且只有一个输出参数
        /// action 也是一种委托方法，但是它没有返回类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="t"></param>
       public void MyMethodB<T>(Func<T,int> func,T t)
        {
            Console.WriteLine(func(t));     
        }

        public int MyMethodA(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            return 1;
        }

        public  void Test()
        {
            //使用func调用MyMethodA方法
            Func<string , int> func = MyMethodA;
            Console.WriteLine(func("111"));

            MyMethodB<string>(new Func<string, int>(MyMethodA), "fei");

            MyMethodB(new Func<string,int>(MyMethodA),"fe1");


        }
      
    }
}
