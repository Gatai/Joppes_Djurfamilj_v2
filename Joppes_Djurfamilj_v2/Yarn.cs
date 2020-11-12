using System;
using System.Collections.Generic;
using System.Text;

namespace Joppes_Djurfamilj_v2
{
    public class Yarn: Toy
    {
        public Yarn(string color = "Green")
        {
            base.color = color;
            base.name = "Yarn";
            base.quality = 6;
        }

        public override Toy CreateToy()
        {
            return new Yarn();
        }

        public override string ToString()
        {
            return string.Format("{0} ", color);
        }
    }
}
