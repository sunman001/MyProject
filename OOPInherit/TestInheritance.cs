using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//理解继承、关注封装、品味多台、玩转接口
namespace OOPInherit
{
    ///规则制胜：密封类不可以被继承
    ///类：单继承，接口多继承
    /// 继承多关注于共通性 而多态多着眼于差异性
    /// <summary>
    /// 创建个各类对象 ，由于Animal为抽象类
    /// 1、继承是可传递的，子类是对父类的扩展，必须继承父类方法，同时可以添加新方法
    /// 2、子类可以调用父类方法和字段，而父类不能调用子类方法和字段
    /// 3、虚方法如何实现覆盖写操作，使得父类指针可以指向子类对象成员
    /// 4、new 关键字在虚方法继承中阻断作用
    /// </summary>
  public  class TestInheritance
    {
        //Bird bird 创建的是一个Bird 类型的引用，而new Bird() 完成的是创建Bird对象，分配内存空间和初始化操作，然后将这个对象引用赋给bird变量，也就是建立bird变量与Bird对象的关联
        /// <summary>
        /// 面向对象的基本原则
        /// 多聚合，少继承
        /// 低耦合，高内聚
        /// 
        /// </summary>
        public void Test()
        {
            Bird bird = new Bird();
            Bird bird2 = new Chicken();
            bird2.ShowType();//调用Chicken的方法 

            Chicken chicken = new Chicken();

            BirdAdapter ba = new BirdAdapter(new Bird());
           
            ba.ToTweet();
            ba.ShowType();
        }

    }
}
