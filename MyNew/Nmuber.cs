using System;
namespace MyNew
{
    public class Nmuber
    {
        protected int number = 120;

        public virtual void  ShowInfo()
        {
            Console.WriteLine("---Base class");
        }

        public virtual void ShowNumber()
        {
            Console.WriteLine(number.ToString());
        }
    }
}
