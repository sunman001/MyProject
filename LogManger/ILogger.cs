using LogManger.EnumHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManger
{
   public  interface ILogger
    {
        void Logger(LogType Type,  string summary,string message);
    }
}
