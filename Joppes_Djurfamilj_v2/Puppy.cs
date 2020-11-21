using System;
using System.Collections.Generic;
using System.Text;

namespace Joppes_Djurfamilj_v2
{
    public class Puppy : Dog
    {
        private int month;
        public Puppy(string name, int month) : base(name, 0)
        {
            base.name = name;
            this.month= month;
            base.breed = "Puppy";
            base.damage = 1;
        }

        public new string ToString()
        {
            return string.Format("{0}, Month: {1}, Favorite Food: {2}, Breed: {3}, Hungry: {4}", name, month, favoriteFood, breed, hungry);
        }
    }
}
