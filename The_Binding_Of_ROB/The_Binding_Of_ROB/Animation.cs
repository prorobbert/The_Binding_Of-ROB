using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Binding_Of_ROB
{
    class Animation
    {
        public int offsetTop;
        public int offsetLeft;
        public int numFrames;

        public Animation(int offsetTop, int offsetLeft, int numFrames)
        {
            this.offsetTop = offsetTop;
            this.offsetLeft = offsetLeft;
            this.numFrames = numFrames;

        }
    }
}
