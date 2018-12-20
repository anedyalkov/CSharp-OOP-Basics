namespace _03.WildFarm.Models.Animals
{
    using _03.WildFarm.Contracts;
    using _03.WildFarm.Models.Foods;
    using System;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }


        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * 0.25;
                FoodEaten = food.Quantity;
            }
            else
            {
                FoodEaten = 0;
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
