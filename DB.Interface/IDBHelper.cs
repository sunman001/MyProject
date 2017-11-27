using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interface
{
  public   interface IDBHelper
    {
        void Query();
        void Query(int id);
        void Query(string name);
        void Query(int id,string name);
        void Query1(int id);
        T FindBy<T>(int id);
    }
}
