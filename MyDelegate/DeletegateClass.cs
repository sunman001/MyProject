using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 委托
/// 事件：（一个动作 触发 别的一系列动作）
/// </summary>
namespace MyDelegate
{
    public delegate void OutNoReturnNoPara();//委托还可以处于Class外面
    public delegate void OutNoReturnWithPara(int x, int y);
    public class DeletegateClass
    {
        public delegate void NoReturnNoPara();//1声明委托
        public delegate void NoReturnWithPara(int x,int y);
        public delegate string NoPara();
        public delegate DateTime WithPara(string name,int size);
        public static void Show()
        {
            Student student = new Student();//声明类以及调用
            student.Id = 11;
            student.Name = "";
            student.Study();
            NoReturnWithPara method = new NoReturnWithPara(Plus);//2委托的实例化，传入一个方法名称 要求方法签名一致
            NoReturnWithPara method1 = Plus;//简明声明委托
            //用Lamdba表达式实现
            {
                NoReturnWithPara method2=(x,y)=>Console.WriteLine("x={0},y={1}", x, y);//匿名方法体
            }
            method.Invoke(1,2);//3调用
            method.BeginInvoke(1,2,null,null);//没有委托就没有异步
            method(1,2);//调用
            Plus(4,5);
            method += Plus;
            method += Plus;
            method += Plus;
            method -= Plus;//多播委托

            //foreach (NoReturnNoPara item in method.GetInvocationList())//获取委托的实列
            //{
            //    item.Invoke();
            //}
           
        }

        private  static void Plus(int x,int y)
        {
            Console.WriteLine("x={0},y={1}",x,y);
        }
    }
}
