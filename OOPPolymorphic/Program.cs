using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphic
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadManager lm = new LoadManager();
            lm.LoadFiles(new WordFile());
            //等
        }
    }
}
