using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractFactory.operation
{
   /// <summary>
   /// 运算工厂 用于前端实例化对象 （工厂就是实列化合适的对象，通过多态返回父类的方式实现了计算器的结果）
   /// </summary>
  public   class OperationFactory
    {
        public static Operation CreateOperate(string operate)
        {
            Operation oper = null;
            switch (operate)

            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                case "/":
                    oper = new OperationDiv();
                    break;
                case "*":
                    oper = new OperationMul();
                    break;

            }
            return oper;
        }
    }
}
