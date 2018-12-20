namespace _06.Animals.Core
{
    using _06.Animals.Animals;
    using _06.Animals.Factories;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private AnimalFactory animalFactory;
        private List<Animal> animals;

        public Engine()
        {
            animalFactory = new AnimalFactory();
            animals = new List<Animal>();
        }
        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "Beast!")
            {
                try
                {
                    var type = input;
                    var data = Console.ReadLine().Split();

                    var name = data[0];
                    var age = int.Parse(data[1]);
                    var gender = data[2];

                    Animal animal = animalFactory.CreateAnimal(type,name, age, gender);
                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
