using System.Collections.Generic;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public void PokemonsLoseHealth()
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                Pokemons[i].Health -= 10;
                if (Pokemons[i].Health <= 0)
                {
                    Pokemons.Remove(Pokemons[i]);

                }
            }
        }
    }
}
