using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphic
{
    public abstract class Files : IFileOpen
    {
        private FileType fileType =FileType.doc;

        public FileType FileType
        {
            get { return fileType; }
        }
        public abstract void Open();

        public virtual void Delete()
        {
            
        }

        public virtual void ReName()
        {
            
        }
    }
}
