﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Joppes_Djurfamilj_v2
{
    public class Cat : Animal
    {
        private Random random = new Random();
        public Cat(string name, int age)
        {
            base.name = name;
            base.age = age;
            base.favoriteFood = "päron";
            base.breed = "Catt";
            base.hungry = true;
            base.damage = 1;
        }

        public override InteractResult Interact(Toy toy)
        {
            //Kontrollera om djuret är hungirg
            if (hungry)
            {
                return InteractResult.Hungry;
            }

            if (toy.IsBroken)
            {
                return InteractResult.ToyBroken;
            }

            //Slumpa ett mood allternativ
            var rand = random.Next(2);
            if (rand == 0)
            {
                return InteractResult.NotInMood;
            }

            //Efter att ha lekt
            energy = energy - 1;
            if (energy == 0)
            {
                hungry = true;
            }

            toy.LowerQuality(damage);

            return InteractResult.Played;
        }

        public override void HungryAnimal()
        {
            Console.WriteLine("There is a 50% chance that a cat finds a mouse and gets full, otherwise the cat is still hungry.");
            var randNumber = random.Next(2);

            ConsoleHelper.Reloading();

            if (randNumber == 1)
            {
                Console.WriteLine($"{name} catchs the mouse and are not hungry anymore!");
                hungry = false;
                energy = 2;
            }
            else
            {
                Console.WriteLine($"{name} did not find a mouse, I want my favorite food ({favoriteFood})");
            }
        }

        public new string ToString()
        {
            return string.Format("{0}, Age: {1}, Favorite Food: {2}, Hungry: {3}", name, age, favoriteFood, hungry);
        }

    }
}
