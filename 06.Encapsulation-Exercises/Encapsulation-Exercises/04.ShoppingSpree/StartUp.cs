namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            var persons = new List<Person>();
            var products = new List<Product>();

            var peopleElements = Console.ReadLine().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < peopleElements.Length; i++)
            {
                var tokens = peopleElements[i].Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                var personName = tokens[0];
                var money = decimal.Parse(tokens[1]);
                try
                {
                    var person = new Person(personName, money);
                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

            }

            var productElements = Console.ReadLine().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < productElements.Length; i++)
            {
                var tokens = productElements[i].Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                var productName = tokens[0];
                var cost = decimal.Parse(tokens[1]);
                try
                {
                    var product = new Product(productName, cost);
                    products.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            var input = Console.ReadLine();
            while (true)
            {
                if (input == "END")
                {
                    break;
                }

                var commands = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = commands[0];
                var product = commands[1];

                var currentPerson = persons.FirstOrDefault(p => p.Name == name);
                var productToBought = products.FirstOrDefault(p => p.Name == product);
                try
                {
                    currentPerson.Buy(productToBought);
                    Console.WriteLine($"{currentPerson.Name} bought {productToBought.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            persons.ForEach(p => Console.WriteLine(p));
        }
    }
}



