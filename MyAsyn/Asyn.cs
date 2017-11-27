using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyAsyn
{
    /// <summary>
    /// 进程是一个应用程序占有的CPU 磁盘等
    /// 线程隶属于某一个进程，是进程的执行单元
    /// 任何操作的响应都是由线程完成的，线程是最小的运行单元
    /// 
    /// 同步方法：发起一个功能调用后，一定等待完成之后，才返回，才继续运行下去
    /// 异步方法：发起一个功能调用后，不等待完成就直接返回，就直接继续运行下去
    /// Ajax :异步刷新
    /// 异步其实就是多线程的并发(异步启动了多个线程执行计算任务，而主线程没被占用)
    /// 同步方法慢，主线程（UI）忙于计算，
    /// 异步方法快， 计算任务由子线程完成 原因是异步启动多个线程，使用了更多的资源在计算 消耗资源《资源换时间》
    /// 异步执行是随机的无序的
    /// </summary>
    public class Asyn
    {
        private delegate void DoSomethingHandler(string name);

        public void  AsyncMehtod()
        {
           // DoSomethingHandler method = new DoSomethingHandler(DoSomething);
             Action<string> method = this.DoSomething;
            AsyncCallback callback = new AsyncCallback(this.CustomerCallback);//方法的返回值，形参必须一致
            for(int i=0;i <5;i++)
            {
               string name = "异步"+i;
              IAsyncResult asyncResult= method.BeginInvoke(name,callback,"AAA");//异步调用
                //第三个参数回调是可以写入的 状态参数
                //回调
   
            }
          
        }

        public void TaskMehtod()
        {
            Console.WriteLine("接到一个项目");
            Console.WriteLine("沟通需求，确认需求，谈妥价格");
            Console.WriteLine("签合同收取50%费用");
            Console.WriteLine("高级版帅选学员，组建团队");
            Console.WriteLine("开始干活");
            //开启多线程
            TaskFactory taskefactory = new TaskFactory();
            List<Task> tasklist = new List<Task>();//任务集合
            //如果想每个task后输入一个进度 怎么办《可以用ContinueWhenAny或者WaitAny 完成一个删除一个进程任务 》

            tasklist.Add(taskefactory.StartNew(() => this.coding("", "orm")));
            tasklist.Add(taskefactory.StartNew(() => this.coding("", "bpm")));

            //有没有又等待，又不卡界面（new 一个子线程 全包裹起来 然后waitall）
            tasklist.Add(taskefactory.ContinueWhenAny(tasklist.ToArray(), tList => Console.WriteLine("第一个完成任务的领取红包{0}", Thread.CurrentThread.ManagedThreadId))) ;

              tasklist.Add(taskefactory.ContinueWhenAll(tasklist.ToArray(), tList => Console.WriteLine("进入一个联调测试阶段{0}", Thread.CurrentThread.ManagedThreadId)));

             Task.WaitAny(tasklist.ToArray());//等待任意一个任务完成后开始执行测试 会阻塞当前线程
              Console.WriteLine("某个模块开发完成后，老师部署起来准备测试");

            Task.WaitAll(tasklist.ToArray());//等待所有任务完成然后往后走，会阻塞当前线程
             Console.WriteLine("开发验收完毕，收取剩余费用");
            Console.WriteLine("项目结束后，大家分钱");
        }

        public void coding(string a,string b)
        {
            
        }
        public void DoSomething(string Name)
        {
            Console.WriteLine(Name);
        }

        public void CustomerCallback(IAsyncResult result)
        {
            Console.WriteLine("执行CustomerCallback",result.AsyncState);
        }
    }
}
