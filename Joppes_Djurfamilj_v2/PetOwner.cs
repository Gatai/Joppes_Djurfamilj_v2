using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Joppes_Djurfamilj_v2
{
    public class PetOwner
    {
        private string name = "Joppe";
        //private int age = 25;
        private List<Animal> petList = new List<Animal>();
        private List<Toy> toyList = new List<Toy>();

        public void Menu()
        {
            Console.WriteLine($"Välkommen {name}");
            Console.WriteLine();

            HardCodeAnimal();
            HardCodedToy();

            var input = 0;
            while (input != 5)
            {
                Console.WriteLine("Select follows 1-5");
                Console.WriteLine("1. Play fetch");
                Console.WriteLine("2. Feed Animal");
                Console.WriteLine("3. List animals");
                Console.WriteLine("4. Check Toys");
                Console.WriteLine("5. Exit");
                input = GetNumber("", 1, 5);

                //Empty space
                Console.WriteLine();

                switch (input)
                {
                    case 1:
                        Fetch();
                        break;

                    case 2:
                        Feed();
                        break;

                    case 3:
                        ListAnimals();
                        break;

                    case 4:
                        CheckToy();
                        break;

                    case 5:
                        Console.WriteLine("Closing the program...");
                        break;
                }

                // Emplty space
                Console.WriteLine();
            }
        }

        public void Fetch()
        {
            Console.WriteLine("Here is a list of all pets.");
            ConsoleHelper.LineOutPut();
            for (int i = 0; i < petList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {petList[i].FetchInformationToString()}");
            }
            Console.WriteLine();
            var indexPet = GetNumber("Which animal do you want to play with? (select number)", 1, petList.Count);
            var selectedPet = petList[indexPet - 1];

            Console.WriteLine();

            Console.WriteLine("All toys");
            ConsoleHelper.LineOutPut();
            var counter = 0;
            //Print the toys
            foreach (var toy in toyList)
            {
                counter++;
                Console.WriteLine($"{counter} {toy} {toy.GetType().Name}");
            }

            Console.WriteLine();
            var indexToy = GetNumber("Choose which toy you want to play with? select number", 1, toyList.Count);
            var selectedToy = toyList[indexToy - 1];

            Console.WriteLine();

            //Check if pet has played
            var hasPlayed = selectedPet.Interact(selectedToy);

            switch (hasPlayed)
            {
                case Animal.InteractResult.Played:
                    Console.WriteLine($"{name} leker med {selectedPet.FetchInformationToString()} med en {selectedToy.ToString()}{selectedToy.GetType().Name}");
                    break;

                case Animal.InteractResult.Hungry:
                    selectedPet.HungryAnimal();
                    break;

                case Animal.InteractResult.NotInMood:
                    Console.WriteLine($"{name} are not in the mood right now!");
                    break;

                case Animal.InteractResult.ToyBroken:
                    Console.WriteLine("Toy is broken, cant play with it!");
                    break;
            }
        }

        public void Feed()
        {
            Console.WriteLine("List of anminals");
            ConsoleHelper.LineOutPut();
            var counter = 0;
            //Write all animals
            foreach (var pet in petList)
            {
                counter++;

                Console.WriteLine($"{counter}: {pet.FeedInformationToString()}");
            }
            Console.WriteLine();
            var indexPet = GetNumber("Which animal do you want to feed", 1, petList.Count);
            var selectedPet = petList[indexPet - 1];

            Console.WriteLine("What food?");
            var favFood = Console.ReadLine();

            var eatMood = selectedPet.Eat(favFood.ToLower());

            switch (eatMood)
            {
                case Animal.EatResult.NotHungry:
                    Console.WriteLine($"{selectedPet.FetchInformationToString()} is not hungry!");
                    break;
                case Animal.EatResult.DontLikeTheFood:
                    Console.WriteLine($"{selectedPet.FetchInformationToString()} don't like the {favFood}, I want my favorite food! ");
                    break;
                case Animal.EatResult.Eat:
                    Console.WriteLine($"You just fed {selectedPet.ToString()} and are full!");
                    Console.WriteLine();
                    break;
            }
        }

        public void CheckToy()
        {
            var counter = 0;
            //print toys
            foreach (var toy in toyList)
            {
                counter++;
                Console.WriteLine($"{counter}: {toy.CheckToyInformationToString()}");
            }
            Console.WriteLine();
            var IsBuying = GetBool("Will you buy? Answer y/n");

            if (IsBuying)
            {
                var indexToy = GetNumber("Which toy would you like to buy a new one?", 1, toyList.Count);
                var selectedToy = toyList[indexToy - 1];
                BuyToy(selectedToy, indexToy);
            }
        }

        public void BuyToy(Toy selectedToy, int indexToy)
        {
            if (selectedToy.IsBroken)
            {
                toyList.RemoveAt(indexToy - 1);
                Console.WriteLine($"You just bougth one {selectedToy.BuyToyInformationToString()}");
                var newToy = selectedToy.CreateToy();
                toyList.Add(newToy);
            }
            else
            {
                Console.WriteLine($"{selectedToy.CheckToyInformationToString()} is not broke yeat");
            }
        }

        public void ListAnimals()
        {
            foreach (var animal in petList)
            {
                //To access ToSting() in puppy and not in animal class
                if (animal is Puppy)
                {
                    Console.WriteLine(((Puppy)animal).ToString());
                }
                else
                {
                Console.WriteLine(animal.ToString());
                }
            }
        }

        public int GetNumber(string text, int? min = null, int? max = null)
        {
            Console.WriteLine(text);
            while (true)
            {
                var tempNumber = 0;
                var inputNumber = Console.ReadLine();

                var isNumber = int.TryParse(inputNumber, out tempNumber);
                if (!isNumber)
                {
                    Console.WriteLine("Invalid input, must be a number!");
                }
                //HasValue checks if min has a value or not.
                else if (min.HasValue && max != null && tempNumber < min || tempNumber > max)
                {
                    Console.WriteLine($"The input must be between {min} - {max}.");
                }
                else
                {
                    //Return the number
                    return tempNumber;
                }
            }
        }

        public bool GetBool(string text)
        {
            Console.WriteLine(text);

            while (true)
            {
                var input = Console.ReadLine();

                if (input.ToLower() == "n")
                {
                    return false;
                }
                else if (input.ToLower() == "y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input, must be y or n!");
                }
            }
        }

        public void HardCodedToy()
        {
            //Det kan bara finnas en boll och stick
            Toy toyRed = new Ball();
            toyList.Add(toyRed);

            Toy toyStick = new Stick();
            toyList.Add(toyStick);

            Toy toyYarn = new Yarn();
            toyList.Add(toyYarn);
        }

        public void HardCodeAnimal()
        {
            Animal dogPingvin = new Dog("Pingvin", 10);
            petList.Add(dogPingvin);

            Animal dogTingeling = new Dog("Tingeling", 15);
            petList.Add(dogTingeling);

            Animal dogBling = new Dog("Bling", 18);
            petList.Add(dogBling);

            //Puppy
            Animal puppyBambu = new Puppy("Bambu", 3);
            petList.Add(puppyBambu);

            Animal puppyHong = new Puppy("Hong", 1);
            petList.Add(puppyHong);


            //Catt  
            Animal catMing = new Cat("Ming", 10);
            petList.Add(catMing);

            Animal catMango = new Cat("Mango", 4);
            petList.Add(catMango);

            Animal catSalami = new Cat("Salami", 2);
            petList.Add(catSalami);

         
        }

        //Osäker här på hur formatet skall vara
        //public override string ToString()
        //{
        //    return base.ToString();
        //}

    }
}
