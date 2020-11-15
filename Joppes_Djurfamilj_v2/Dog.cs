using System;
using System.Collections.Generic;
using System.Text;

namespace Joppes_Djurfamilj_v2
{
    public class Dog : Animal
    {
        //private string name;
        //private int age;
        public Dog(string name, int age)
        {
            base.name = name;
            base.age = age;
            base.favoriteFood = "äpple";
            base.breed = "Dog";
            base.hungry = false;
            base.damage = 2;
        }

        public override InteractResult Interact(Toy toy)
        {
            //validate if the pet can play
            if (hungry)
            {
                return InteractResult.Hungry;
            }

            if (toy.IsBroken)
            {
                return InteractResult.ToyBroken;
            }

            //Calculate energy left
            energy = energy - 1;

            if (energy == 0)
            {
                hungry = true;
            }
            
            toy.LowerQuality(damage);

            return InteractResult.Played;
        }

        public new string ToString()
        {
            return string.Format("Name: {0}, Age: {1}, Favorite Food: {2}, Breed: {3}, Hungry: {4}", name, age, favoriteFood, breed, hungry);
        }
    }
}
