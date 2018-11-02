namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            

            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split();
                try
                {
                    var person = new Person(tokens[0],
                                       tokens[1],
                                       int.Parse(tokens[2]),
                                       decimal.Parse(tokens[3]));

                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            var team = new Team("SoftUni");
            foreach (var p in persons)
            {
                team.AddPlayer(p);
            }
           
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
