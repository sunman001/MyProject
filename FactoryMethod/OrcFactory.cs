using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
  public   class OrcFactory :IFartoryMehod
    {
        public IRace CreateFactoy()
        {
            return new Orc();
        }

        public  IRace CreateOrcFacotry()
        {
            return new Orc();
        }
    }
}
