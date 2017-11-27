using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
   public    class HumanFactory :IFartoryMehod
    {
        /// <summary>
        /// 这里可以创建一个Human
        /// 可以在这里使用反射去创建
        /// 还可以在这里添加很多其他的逻辑
        /// 就是把业务类的依懒，转移成对中间层的依懒
        /// 而中间层是自己添加的
        /// </summary>
        /// <returns></returns>
        public  static IRace CreateHumanFactory()
        {
            return new Human();
        }

        public IRace CreateFactoy()
        {
            return new Human();
        }
    }
}
