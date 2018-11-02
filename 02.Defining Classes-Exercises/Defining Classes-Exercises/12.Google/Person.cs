using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
            Parents = new List<Parent>();
            Children = new List<Child>();
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public Company Company { get; set; }
        public Car Car { get; set; }
        private List<Parent> Parents { get; set; }
        private List<Child> Children { get; set; }
        private List<Pokemon> Pokemons { get; set; }

        public void AddParent(Parent parent)
        {
            Parents.Add(parent);
        }
        public void AddChild(Child child)
        {
            Children.Add(child);
        }
        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name}");
            if (Company == null)
            {
                sb.AppendLine("Company:");
            }
            else
            {
                sb.AppendLine("Company:");
                sb.AppendLine($"{Company}");
            }
            if (Car == null)
            {
                sb.AppendLine("Car:");
            }
            else
            {
                sb.AppendLine("Car:");
                sb.AppendLine($"{Car}");
            }
            sb.AppendLine("Pokemon:");
            if (Pokemons.Count != 0)
            {
                foreach (var pokemon in Pokemons)
                {
                    sb.AppendLine($"{pokemon.Name} {pokemon.Type}");
                }
            }
            sb.AppendLine("Parents:");
            if (Parents.Count != 0)
            {
                foreach (var parent in Parents)
                {
                    sb.AppendLine($"{parent.Name} {parent.Birthday}");
                }
            }
            sb.AppendLine("Children:");
            if (Children.Count != 0)
            {
                foreach (var child in Children)
                {
                    sb.AppendLine($"{child.Name} {child.Birthday}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
