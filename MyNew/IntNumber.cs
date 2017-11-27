using System;

namespace MyNew
{
   public  class IntNumber:Nmuber
   {
       protected new int number = 455;

       public new virtual void   ShowInfo()
       {
          Console.WriteLine(" new class ");
       }

       public override void ShowNumber()
       {
           Console.WriteLine(base.number.ToString());
           Console.WriteLine(number.ToString());
       }
    }
}
