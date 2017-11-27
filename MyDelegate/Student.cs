using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegate
{
 public    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Study()
        {
            List<int> list = new List<int>();
            foreach (int j in list.Where(num=>num>50))
            {
                list.Add(j);
            }
           
            int a = list.Count;
            Console.WriteLine();
        }
    }
}
