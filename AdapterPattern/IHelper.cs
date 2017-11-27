using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
   public  interface IHelper
   {
       void add<T>();
       void update<T>();
   }
}
