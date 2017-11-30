using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInherit
{
    /// <summary>
    /// 派生类继承了基类的所有属性和方法，并且只能有一个基类
    /// 在.NET中 System.object是所有类型的最终基类，这种继承方式称为实现继承
    /// </summary>
    public class Bird : Animal
    {
        private string type = "Bird";
        public override void ShowType()
        {
            Console.WriteLine("Type is {0}", type);
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
