using LogManger.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManger.PlatfromFactory
{
    public class AdministratorGlobalFactory : IAbstractFactory
    {
        public ILogger CreateLog()
        {
            return new AdministratorLogger();
        }
    }
}
