namespace _07.FoodShortage.Core
{
    using _07.FoodShortage.Contracts;
    using _07.FoodShortage.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private HashSet<IBuyer> buyers;
        public Engine()
        {
            buyers = new HashSet<IBuyer>();
        }
        public void Run()
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var lineArgs = Console.ReadLine().Split().ToArray();

                if (lineArgs.Length == 4)
                {
                    IBuyer citizen = new Citizen(lineArgs[0], int.Parse(lineArgs[1]), lineArgs[2], lineArgs[3]);
                    buyers.Add(citizen);
                }
                else if (lineArgs.Length == 3)
                {
                    IBuyer rebel = new Rebel(lineArgs[0], int.Parse(lineArgs[1]), lineArgs[2]);
                    buyers.Add(rebel);
                }
            }

            string name = Console.ReadLine();

            while (name != "End")
            {
                bool buyerExists = false; 
                foreach (var buyer in buyers)
                {
                    if (buyer is Citizen)
                    {
                        var citizen = (Citizen)buyer;
                        if (citizen.Name == name)
                        {
                            buyerExists = true;
                        }

                        if (buyerExists)
                        {
                            citizen.BuyFood();
                            buyerExists = false;
                        }
                    }
                    else if (buyer is Rebel)
                    {
                        var rebel = (Rebel)buyer;
                        if (rebel.Name == name)
                        {
                            buyerExists = true;
                        }

                        if (buyerExists)
                        {
                            rebel.BuyFood();
                            buyerExists = false;
                        }
                    }
                }

                name = Console.ReadLine();
            }

            var totalFood = buyers.Sum(b => b.Food);

            Console.WriteLine(totalFood);
        }
    }
}
