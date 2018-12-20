namespace _05.BorderControl.Core
{
    using _05.BorderControl.Contracts;
    using _05.BorderControl.Factories;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private InhabitantFactory inhabitantFactory;

        public Engine()
        {
            inhabitantFactory = new InhabitantFactory();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            var inhabitants = new List<IInhabitant>();

            while (input != "End")
            {
               
                IInhabitant inhabitant = inhabitantFactory.CreateInhabitant(input);

                inhabitants.Add(inhabitant);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            foreach (var item in inhabitants)
            {
                if (item.Id.EndsWith($"{input}"))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
