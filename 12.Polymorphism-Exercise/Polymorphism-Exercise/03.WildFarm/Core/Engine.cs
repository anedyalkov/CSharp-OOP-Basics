namespace _03.WildFarm.Core
{
    using _03.WildFarm.Contracts;
    using _03.WildFarm.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private AnimalFactory animalFactory;
        private FoodFactory foodFactory;
        private IAnimal animal;
        private IFood food;
        private List<IAnimal> animals;
        public Engine()
        {
            animalFactory = new AnimalFactory();
            foodFactory = new FoodFactory();
            animals = new List<IAnimal>();
        }
        public void Run()
        {
            string input;
            var countLines = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    if (countLines % 2 == 0)
                    {
                        try
                        {
                            var animalInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                            animal = animalFactory.CreateAnimal(animalInfo);
                            countLines++;
                            continue;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            var foodInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                            food = foodFactory.CreateFood(foodInfo);
                            countLines++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }

                    try
                    {
                        Console.WriteLine(animal.ProduceSound());
                        animal.Eat(food);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    animals.Add(animal);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }

            animals.ForEach(a => Console.WriteLine(a));
        }
    }
}
