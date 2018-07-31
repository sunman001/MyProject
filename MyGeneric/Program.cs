using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    /// <summary>
    /// 泛型
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("欢迎大家");
            int iValue = 123;
            long iValueLong = 4555;
            MethodShow.ShowInt(iValue);
            MethodShow.ShowLong(iValueLong);
            MethodShow.ShowT<int>(iValue);
        }

        public class MethodShow
        {
            /// <summary>
            /// int参数
            /// </summary>
            /// <param name="iParmeter"></param>
            public static void ShowInt(int iParmeter)
            {
                Console.WriteLine("这里是MethodShow ShowInt{0} 类型{1}",iParmeter,iParmeter.GetType());
            }
            /// <summary>
            /// long 参数
            /// </summary>
            /// <param name="iParmeter"></param>
            public static void ShowLong(long iParmeter)
            {
                Console.WriteLine("这里是MethodShow ShowLong{0} 类型{1}",iParmeter,iParmeter.GetType());
            }

            /// <summary>
            /// 泛型
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="t"></param>
            public static void ShowT<T>( T t)
            {
                Console.WriteLine("这里是MethodShow ShowT {0} 类型 {1}",t,t.GetType());  
            }
            public static T Get<T>(int id,T t)
            {
                return default(T);
            }
        }
    }
}
