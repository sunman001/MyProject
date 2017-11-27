using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLambda
{
    /// <summary>
    /// Lambda 表达式是一种可用创建委托或表达式目录树类型的匿名函数，通过使用Lambda 表达式，可以写入可作为参数传递或作为函数调用值
    /// </summary>
    public class Lambda
    {
        delegate int del(int i);//声明
        delegate void TestDelegate(string s);
        
       
        public void testLambda()
        {
            //调用并用Lambda表示实现内部的方法
            del myDeletegate = x => x * x;
            int j = myDeletegate(5);

            TestDelegate del = n =>
            {
                string s = n + "Wrold";
            };

            //带有标准查询运算符的lambda 
            Func<int, bool> myfunc = x => x == 5;
            bool result = myfunc(4);//return false of course

            int[] numbers = {5,4,1,3,9,8,6,7,2,0 };
            int oddNumbers = numbers.Count();
            int first=numbers.First(n=>n/2==1);

            List<jmp_app> listapp = new List<jmp_app>();
            listapp.Where(x=>x.a_key=="1");//Lamdba中的类型推理

            IEnumerable<int> numbersQuery = from number in numbers where number >= 1 select number;

            foreach (int i  in numbersQuery )
            {
                Console.Write(i+"");
            }

        }

       
    }
}
