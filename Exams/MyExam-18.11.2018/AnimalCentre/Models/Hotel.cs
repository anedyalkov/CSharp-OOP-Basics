namespace AnimalCentre.Models
{
    using System.Collections.Generic;
    using AnimalCentre.Models.Contracts;
    using System;

    public class Hotel : IHotel
    {
        private const int capacity = 10;
        public Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            animals = new Dictionary<string, IAnimal>();
            Capacity = capacity;
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => animals;
        public int Capacity { get; set; }

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count == capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (!animals.ContainsKey(animal.Name))
            {
                animals.Add(animal.Name, animal);
            }
            else
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var animal = animals[animalName];
            animal.Owner = owner;
            animal.IsAdopt = true;
            animals.Remove(animalName);
        }
    }
}
