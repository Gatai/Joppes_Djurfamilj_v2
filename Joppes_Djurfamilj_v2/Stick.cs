using System;
using System.Collections.Generic;
using System.Text;

namespace Joppes_Djurfamilj_v2
{
    public class Stick : Toy
    {
        public Stick(string color = "Brown")
        {
            base.color = color;
            base.name = "Stick";
            base.quality = 2;
        }

        public override Toy CreateToy()
        {
            return new Stick();
        }

        public override string ToString()
        {
            return string.Format("{0} ", color);
        }
    }
}
