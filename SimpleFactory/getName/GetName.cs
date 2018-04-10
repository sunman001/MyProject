using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory.getName
{
   public  class GetName
    {
        protected string fistName,lastName;
        public string getFirstName()
        {
            return fistName;
        }

        public string getLastName()
        {
            return lastName;
        }

    }
}
