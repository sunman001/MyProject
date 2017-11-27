using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 此类加上特性
    /// </summary>
      [Customer("test",1, Id = 1)]
    public class User
    {
      
        public int Id { get; set; }
      
        public string Name { get; set; }
    }
    public class Student:User
    {
        public string CalssName { get; set; }
    }

   
}
