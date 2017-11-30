using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEncapsulation
{
    /// <summary>
    /// 字段（field）通常定义为private,表示类的状态信息，CLR支持只读和读写的字段，值得注意的是大部分情况下字段，值得注意的是，大部分情况下字段都是可读可写的，只读字段只能在构造函数中被赋值，其他方法不能改变只读字段
    /// 属性（property）通常定义为public 表示类的对外成员，属性具有可读、可写属性，通过get和set访问器来实现其读写控制
    /// get 和set对属性的读写控制，是通过实现get 和set 的组合来实现的 get 读，set 写
    /// 通过对公共属性的访问来实现对类状态信息的读写控制，主要有两点好处：一是避免了对数据安全的访问限制，包含内部数据的可靠性，而是避免了类扩展或者修改带来的变量连锁反应
    /// </summary>
    public class Client
    {
        private string name;
        private int age;
        private string password;

        public string Name
        {
            get { return name; }
            set { name = value == null ? string.Empty : value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if ((value > 0) && (value < 150))
                {
                    age = value;
                }
                else
                {
                    {
                        throw new ArgumentException("年龄信息不正确");
                    }
                }
            }
        }
    }
}
