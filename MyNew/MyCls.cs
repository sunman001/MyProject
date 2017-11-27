using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNew
{
    public class MyCls
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public MyCls()
        {
            _name = "Emma";
        }

    }
}
