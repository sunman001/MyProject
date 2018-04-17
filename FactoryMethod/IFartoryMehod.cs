using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// 开闭原则、单一职责、面向抽象
    /// </summary>
   public  interface IFartoryMehod
    {
        IRace CreateFactoy();
    }
}
