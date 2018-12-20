namespace _05.PizzaCalories
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
             Dough dough;
             Topping topping;
             Pizza pizza;

            try
            {
                var pizzaInfo = Console.ReadLine().Split(" ".ToCharArray()).ToArray();
                var pizzaName = pizzaInfo[1];
                pizza = new Pizza(pizzaName);

                var doughInfo = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                var flourType = doughInfo[1];
                var bakingTechnique = doughInfo[2];
                var weight = double.Parse(doughInfo[3]);
                dough = new Dough(flourType.ToLower(), bakingTechnique.ToLower(), weight);
                pizza.Dough = dough;

                string toppingInfo;
                while ((toppingInfo = Console.ReadLine()) != "END")
                {
                    string[] toppingParams = toppingInfo.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                    var toppingName = toppingParams[1].ToLower();
                    var toppingWeight = double.Parse(toppingParams[2]);
                    topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine(pizza);
        }
    }
}
