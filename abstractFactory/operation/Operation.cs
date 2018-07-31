using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractFactory.operation
{
    /// <summary>
    /// 运算类
    /// </summary>
  public   class Operation
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }


        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }
}
