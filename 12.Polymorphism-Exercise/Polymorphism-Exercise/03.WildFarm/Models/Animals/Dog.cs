namespace _03.WildFarm.Models.Animals
{
    using _03.WildFarm.Contracts;
    using _03.WildFarm.Models.Foods;
    using System;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * 0.40;
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
