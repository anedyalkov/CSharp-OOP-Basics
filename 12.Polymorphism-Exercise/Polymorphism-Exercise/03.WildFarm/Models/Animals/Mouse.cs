

namespace _03.WildFarm.Models.Animals
{
    using _03.WildFarm.Contracts;
    using _03.WildFarm.Models.Foods;
    using System;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
            {
                Weight += food.Quantity * 0.10;
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
