namespace DefiningClasses
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var counter = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < counter; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);

                family.AddMember(person);
            }

            var oldestPerson = family.GetOldestMember();
            Console.WriteLine(oldestPerson);
        }
    }
}
