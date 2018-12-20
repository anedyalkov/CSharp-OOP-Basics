namespace _03.WildFarm.Factories
{
    using _03.WildFarm.Contracts;
    using _03.WildFarm.Models.Foods;
    using System;

    public class FoodFactory
    {
        public IFood CreateFood(params string[] foodInfo)
        {
            var type = foodInfo[0];

            switch (type)
            {
                case "Vegetable":
                    return new Vegetable(int.Parse(foodInfo[1]));
                case "Fruit":
                    return new Fruit(int.Parse(foodInfo[1]));
                case "Meat":
                    return new Meat(int.Parse(foodInfo[1]));
                case "Seeds":
                    return new Seeds(int.Parse(foodInfo[1]));
                default:
                    throw new Exception("Invalid input!");
            }
        }
    }
}
