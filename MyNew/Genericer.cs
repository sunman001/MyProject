using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNew
{
   public  class Genericer<T> where T:new()

    {
        public T GetItem()
        {
            return new T();
        }
    }
}
