using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInherit
{

    public class BirdAdapter : ITweetable
    {
        private Bird _bird;

        public BirdAdapter(Bird bird)
        {
            _bird = bird;
        }
        public void ToTweet()
        {
            //为不同的子类实现不同的ToTweet行为
        }

        public void ShowType()
        {
            _bird.ShowType();
        }
    }
}
