using AnimalCentre.Models;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private Procedure chip;
        private Procedure dentalCare;
        private Procedure fitness;
        private Procedure nailTrim;
        private Procedure play;
        private Procedure vaccinate;
       

        public AnimalCentre()
        {
            hotel = new Hotel();
            this.chip = new Chip();
            this.dentalCare = new DentalCare();
            this.fitness = new Fitness();
            this.nailTrim = new NailTrim();
            this.play = new Play();
            this.vaccinate = new Vaccinate();
            AddoptedPets = new Dictionary<string, List<IAnimal>>();
        }

        public Dictionary<string, List<IAnimal>> AddoptedPets { get; }


        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = null;
            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
            }
            hotel.Accommodate(animal);
            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            chip.DoService(animal, procedureTime);
          
            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            vaccinate.DoService(animal, procedureTime);

            return $"{animal.Name} had vaccination procedure";
        }


        public string Fitness(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            fitness.DoService(animal, procedureTime);

            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            play.DoService(animal, procedureTime);

            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            dentalCare.DoService(animal, procedureTime);

            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            nailTrim.DoService(animal, procedureTime);

            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (!hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var animal = hotel.Animals[animalName];
            hotel.Adopt(animalName, owner);

            if (!this.AddoptedPets.ContainsKey(owner))
            {
                this.AddoptedPets.Add(owner, new List<IAnimal>());
            }

            this.AddoptedPets[owner].Add(animal);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }

        }

        public string History(string type)
        {
            switch (type)
            {
                case "Chip":
                    return chip.History();
                case "DentalCare":
                    return dentalCare.History();
                case "Fitness":
                    return fitness.History();
                case "NailTrim":
                    return nailTrim.History();
                case "Play":
                    return play.History();
                case "Vaccinate":
                    return vaccinate.History();
                default:
                    throw new ArgumentException("Invalid Procedure Type");
            }
        }
    }
}

