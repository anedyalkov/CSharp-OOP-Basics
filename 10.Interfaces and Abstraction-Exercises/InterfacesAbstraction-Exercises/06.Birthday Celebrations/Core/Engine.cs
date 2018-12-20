namespace _06.Birthday_Celebrations.Core
{
    using _06.Birthday_Celebrations.Contracts;
    using _06.Birthday_Celebrations.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {

            string input = Console.ReadLine();

            var inhabitants = new List<IInhabitant>();
            var birthables = new List<IBirthable>();

            while (input != "End")
            {
                var inputArgs = input.Split().ToArray();
                if (inputArgs[0] == "Citizen")
                {
                    IBirthable citizen = new Citizen(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]);
                    birthables.Add(citizen);
                }
                else if (inputArgs[0] == "Pet")
                {
                    IBirthable pet = new Pet(inputArgs[1], inputArgs[2]);
                    birthables.Add(pet);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            foreach (var item in birthables)
            {
                if (item.Birthdate.EndsWith(input))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}
