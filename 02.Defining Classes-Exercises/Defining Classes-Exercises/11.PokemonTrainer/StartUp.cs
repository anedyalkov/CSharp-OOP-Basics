namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                var line = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                var trainerName = line[0];
                var pokemonName = line[1];
                var pokemonElement = line[2];
                var pokemonHealth = int.Parse(line[3]);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    var trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                    var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                    trainer.AddPokemon(pokemon);
                }
                else
                {
                    var existingTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                    var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                    existingTrainer.AddPokemon(pokemon);
                }
            }
            string secondInput;
            while ((secondInput = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == secondInput))
                    {
                        trainer.NumberOfBadges += 1;
                    }
                    else
                    {
                        trainer.PokemonsLoseHealth();
                    }
                }
            }

            var orderedTrainers = trainers
                .OrderByDescending(t => t.NumberOfBadges)
                .ToList();

            foreach (var trainer in orderedTrainers)
            {
                Console.WriteLine(trainer.Name + " " + trainer.NumberOfBadges + " " + trainer.Pokemons.Count);
            }
        }
    }
}
