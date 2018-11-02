namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var persons = new List<Person>();
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                var personName = tokens[0];
                if (!persons.Any(p => p.Name == personName))
                {
                    var person = new Person(personName);
                    persons.Add(person);
                }
                

                if (tokens[1] == "company")
                {
                    var person = persons.FirstOrDefault(p => p.Name == personName);
                    var companyName = tokens[2];
                    var departmentName = tokens[3];
                    var salary = decimal.Parse(tokens[4]);
                    var company = new Company(companyName,departmentName,salary);
                    person.Company = company;
                }
                else if (tokens[1] == "car")
                {
                    var model = tokens[2];
                    var speed = int.Parse(tokens[3]);
                    var car = new Car(model, speed);
                    var person = persons.FirstOrDefault(p => p.Name == personName);
                    person.Car = car;
                }
                else if (tokens[1] == "parents")
                {
                    var parentName = tokens[2];
                    var birthday = tokens[3];
                    var parent = new Parent(parentName, birthday);
                    var person = persons.FirstOrDefault(p => p.Name == personName);
                    person.AddParent(parent);
                }
                else if (tokens[1] == "children")
                {
                    var childtName = tokens[2];
                    var birthday = tokens[3];
                    var child = new Child(childtName, birthday);
                    var person = persons.FirstOrDefault(p => p.Name == personName);
                    person.AddChild(child);
                }
                else if (tokens[1] == "pokemon")
                {
                    var pokemonName = tokens[2];
                    var pokemonType = tokens[3];
                    var pokemon = new Pokemon(pokemonName, pokemonType);
                    var person = persons.FirstOrDefault(p => p.Name == personName);
                    person.AddPokemon(pokemon);
                }
            }
            string searchedPerson = Console.ReadLine();

            var personToPrint = persons.FirstOrDefault(p => p.Name == searchedPerson);
            Console.WriteLine(personToPrint);
           
        }
    }
}
