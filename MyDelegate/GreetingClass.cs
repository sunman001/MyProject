using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegate
{
 public    class GreetingClass
    {
        public static void GreetingChinese(string name)
        {
            Console.WriteLine("{0},早上好", name);
        }
        public static void GreetingEnglish(string name)
        {
            Console.WriteLine("{0},Morning",name);
        }

        /// <summary>
        /// 不同的国家，不同的问候方式怎么实现
        /// 加参数，加判断
        /// 增加国家，修改方法
        /// 职责不单一
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public static void Greeting(string name, PeopleType type)//传的是值，根据值来决定行为
        {
            if (type == PeopleType.chinese)
            {
                Console.WriteLine("{0},早上好", name);
            }
            else if (type == PeopleType.English)
            {
                Console.WriteLine("{0},English", name);
            }
            else
            {
                throw new Exception("");
            }
        }
        /// <summary>
        /// 委托对扩展开放 对修改关闭  
        /// 声明委托调用
        /// </summary>
        /// <param name="name"></param>
        /// <param name="handler"></param>
        public static void Greeting(string name, GreetingHandler handler)//传入一个方法进去
        {
            handler.Invoke(name);
        }

        public delegate void GreetingHandler(string name);//声明一个委托

        ///Action是一个委托方法 省去声明委托声明   
        //public static void Greeting(string name,Action<string > handler)
        // {
        //     handler.Invoke(name);
        // }
        public enum PeopleType
        {
            chinese=0,
            English=1
        }


        public delegate void TryFunc();

        public delegate void ErrorFunc(Exception ex);

        public delegate void FinallyFunc();

        /// <summary>
        /// 使用委托 封装try--catch---finally
        /// </summary>
        /// <param name="tryFunc"></param>
        /// <param name="errorFunc"></param>
        /// <param name="finallyFunc"></param>
        public static void TryCatchFuc(TryFunc tryFunc,ErrorFunc errorFunc,FinallyFunc finallyFunc)
        {
            try
            {
                tryFunc.Invoke();
            }
            catch(Exception ex)
            {
                errorFunc?.Invoke(ex);
            }
            finally
            {

                finallyFunc();
            }
        }
    }
}
