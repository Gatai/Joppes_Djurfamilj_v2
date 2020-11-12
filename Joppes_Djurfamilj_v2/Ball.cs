using System;
using System.Collections.Generic;
using System.Text;

namespace Joppes_Djurfamilj_v2
{
    public class Ball : Toy
    {
        public Ball(string color = "Red")
        {
            base.color = color;
            base.name = "Ball";
        }

        public override Toy CreateToy()
        {
            return new Ball();
        }

        public override string ToString()
        {
            return string.Format("{0} ", color);
        }
    }
}
