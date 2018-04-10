using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory.getName
{
  public   class LastFirst:GetName
    {
        public LastFirst (string name)
        {
            int i = name.IndexOf(",");
            if(i>0)
            {
                lastName = name.Substring(0,i);
                fistName = name.Substring(i+1).Trim();
            }
            else
            {
                lastName = name;
                fistName = "";
            }

        }
    }
}
