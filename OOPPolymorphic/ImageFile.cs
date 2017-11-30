using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphic
{
  public abstract  class ImageFile:Files 
    {
        public virtual  void ZoomIn()
        {
            //放大
        }

        public virtual void ZoomOut()
        {
            //缩小比例
        }
    }
}
