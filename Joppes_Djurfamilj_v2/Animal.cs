using System;
using System.Collections.Generic;
using System.Text;

namespace Joppes_Djurfamilj_v2
{
    public abstract class Animal
    {
        protected string name;
        protected int age;
        protected string favoriteFood;
        protected string breed;
        protected bool hungry = false;
        protected int energy = 6;
        protected int damage;

        //Different behaviors
        public enum InteractResult
        {
            Played = 0,
            Hungry = 1,
            NotInMood = 2,
            ToyBroken = 3,
        }

        //Different behaviors
        public enum EatResult
        {
            NotHungry = 0,
            DontLikeTheFood = 1,
            Eat = 2,
        }

        public abstract InteractResult Interact(Toy toy);

        public EatResult Eat(string food)
        {
            //If the animal does not get his favorite food
            if (favoriteFood != food)
            {
                //Print this
                return EatResult.DontLikeTheFood;
            }
            //If the animal is not hungry, it does not want to eat
            if (hungry == false)
            {
                return EatResult.NotHungry;
            }

            hungry = false;

            //Reset energy
            energy = 2;
            
            return EatResult.Eat;
        }

        public virtual void HungryAnimal()
        {
            Console.WriteLine($"gny, {name} dont want to play i want to eat my favorite food!");
        }

        public string FetchInformationToString()
        {
            return string.Format("{0}, breed {1}, hungry: {2}", name, breed, hungry);
        }
        public string FeedInformationToString()
        {
            return string.Format("{0}, Favorite Food: {1} Hungry: {2} ", name, favoriteFood, hungry);
        }

        public override string ToString()
        {
            return string.Format("{0}, Age: {1}, Favorite Food: {2}, Breed: {3}, Hungry: {4} (animal klass)", name, age, favoriteFood, breed, hungry);
        }


    }
}
