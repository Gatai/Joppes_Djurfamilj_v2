using System;

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

        public string Name => name;

        public enum InteractResult
        {
            Played = 0,
            Hungry = 1,
            NotInMood = 2,
            ToyBroken = 3,
        }

        public enum EatResult
        {
            NotHungry = 0,
            DontLikeTheFood = 1,
            Eat = 2,
        }

        public abstract InteractResult Interact(Toy toy);

        public virtual EatResult Eat(string food)
        {
            if (favoriteFood != food)
            {
                return EatResult.DontLikeTheFood;
            }
            if (hungry == false)
            {
                return EatResult.NotHungry;
            }

            hungry = false;

            energy = 2;
            
            return EatResult.Eat;
        }

        public virtual void HungryAnimal()
        {
            Console.WriteLine($"gny, {name} want to eat my favorite food!");
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
            return string.Format("{0}, Age: {1}, Favorite Food: {2}, Breed: {3}, Hungry: {4}", name, age, favoriteFood, breed, hungry);
        }


    }
}
