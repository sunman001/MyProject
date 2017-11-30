using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphic
{
  public abstract   class DocFile:Files 
    {
        //计算文档页数
        public virtual  int GetPageCount()
        {
            int count = 2;
            return count;
        }
    }
}
