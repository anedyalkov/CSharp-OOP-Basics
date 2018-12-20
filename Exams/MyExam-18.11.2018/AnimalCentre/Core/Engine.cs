using System;
using System.Linq;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private bool isRunning;
        private AnimalCentre animalCentre;

        public Engine(AnimalCentre animalCentre)
        {
            this.animalCentre = animalCentre;
            this.isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    isRunning = false;
                    break;
                }
                try
                {
                    var inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var command = inputArgs[0];
                    var commandArgs = inputArgs.Skip(1).ToArray();
                    Execute(command, commandArgs);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"InvalidOperationException: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ArgumentException: {ex.Message}");
                }
            }

            foreach (var owner in animalCentre.AddoptedPets.OrderBy(o => o.Key))
            {
                Console.WriteLine($"--Owner: {owner.Key}");
                Console.WriteLine($"   - Adopted animals: {string.Join(" ", owner.Value.Select(a => a.Name))}");
            }
        }

        private void Execute(string command, string[] commandArgs)
        {
            switch (command)
            {
                case "RegisterAnimal":
                    Console.WriteLine(animalCentre.RegisterAnimal(commandArgs[0], commandArgs[1], int.Parse(commandArgs[2]), int.Parse(commandArgs[3]), int.Parse(commandArgs[4])));
                    break;
                case "Chip":
                    Console.WriteLine(animalCentre.Chip(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "Vaccinate":
                    Console.WriteLine(animalCentre.Vaccinate(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "Fitness":
                    Console.WriteLine(animalCentre.Fitness(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "Play":
                    Console.WriteLine(animalCentre.Play(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "DentalCare":
                    Console.WriteLine(animalCentre.DentalCare(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "NailTrim":
                    Console.WriteLine(animalCentre.NailTrim(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "Adopt":
                    Console.WriteLine(animalCentre.Adopt(commandArgs[0], commandArgs[1]));
                    break;
                case "History":
                    Console.WriteLine(animalCentre.History(commandArgs[0]));
                    break;
                default:
                    break;
            }
        }
    }
}
