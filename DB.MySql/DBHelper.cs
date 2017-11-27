using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.MySql
{
    public class DBHelper : IDBHelper
    {
        public T FindBy<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void Query()
        {
            Console.WriteLine("这里是{0}的Query",this.GetType().FullName);
        }

        public void Query(string name)
        {
           Console.WriteLine("这里是{0}的Query", this.GetType().FullName);

        }

        public void Query(int id)
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }
        public void Query(int id, string name)
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }
        
        public  void Query1(int id)
        {
            Console.WriteLine("这里是{0}的Query1", this.GetType().FullName);
        }
        private void  Query2()
        {
            Console.WriteLine("这里是{0}的Query2", this.GetType().FullName);
        }
         
    }
}
