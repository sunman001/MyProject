using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManger
{
    public  interface ILogWrite
    {
        // void write(UserLog userlog);
        void write<T>(T userlog) where T:class;
    }
}
