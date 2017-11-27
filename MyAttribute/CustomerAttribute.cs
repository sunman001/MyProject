using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 特性影响编译和行为
    /// </summary>
   public  class CustomerAttribute:Attribute
    {
        public int Id { get; set; }
        private string name { get; set; }
        private int sex { get; set; }
        public CustomerAttribute (string Name)
        {
            this.name = Name;
        }
        public CustomerAttribute (string Name,int Sex)
        {
            this.name = Name;
            this.sex = Sex;
        }

        public void showAttribute()
        {
            Console.WriteLine("name:{0},sex{1}",name ,sex);
        }

       
    }
}
