using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphic
{
    public class WordFile : DocFile
    {
        public override void Open()
        {
            Console.WriteLine("Open the Word File.");
        }
    }
}
