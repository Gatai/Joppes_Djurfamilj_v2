using System;
using System.Collections.Generic;
using System.Text;

namespace Joppes_Djurfamilj_v2
{
    public abstract class Toy
    {
        protected string name;
        protected string color;
        protected int quality = 4;
        public bool IsBroken
        {
            get
            {
                return quality <= 0;
            }
        }
        public abstract Toy CreateToy();

        public int LowerQuality(int number)
        {
            quality = quality - number;
            return quality;
        }

        public string CheckToyInformationToString()
        {
            return string.Format("{0} {1} (quality: {2})", color, name , quality);
        }
        public string BuyToyInformationToString()
        {
            return string.Format("{0} {1} ", color, name);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}", name, color, quality);
        }
    }

}
