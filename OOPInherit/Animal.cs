using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInherit
{
    /// <summary>
    /// 抽象类动物类
    /// </summary>
    public abstract  class Animal
    {
        public abstract void ShowType();//抽象方法

        public void Eat()
        {
           Console.WriteLine("Animal always eat");
        }
    }
}
