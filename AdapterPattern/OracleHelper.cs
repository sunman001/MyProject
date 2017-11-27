using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class OracleHelper : IHelper
    {
        public void add<T>()
        {
            throw new NotImplementedException();
        }

        public void update<T>()
        {
            throw new NotImplementedException();
        }
    }
}
