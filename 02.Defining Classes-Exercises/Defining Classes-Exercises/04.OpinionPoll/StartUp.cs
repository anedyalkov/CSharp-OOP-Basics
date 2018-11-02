namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var counter = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < counter; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);
                persons.Add(person);
            }
            var orderedPersons = persons.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

            foreach (var person in orderedPersons)
            {
                Console.WriteLine(person);
            }

        }
    }
}
