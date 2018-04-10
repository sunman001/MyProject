using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory.getName
{
  public   class FirstFirst:GetName
    {
        public FirstFirst(string name)
        {
            int i = name.Trim().IndexOf(" ");    
            if(i>0)
            {
                fistName = name.Substring(0, i).Trim();
                lastName = name.Substring(i + 1).Trim();
            }
            else
            {
                lastName = name;
                fistName = "";
            }
        }
    }
}
