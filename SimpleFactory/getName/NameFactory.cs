using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory.getName
{
   public  class NameFactory
    {
        public NameFactory ()
        {

        }
        //获取姓名的工厂
        public static GetName CreateNameFactory(string name)
        {
            int i = name.IndexOf(",");
            if (i > 0)
                return new LastFirst(name);
            else
                return new FirstFirst(name);
        }
    }
}
