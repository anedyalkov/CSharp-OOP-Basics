namespace _03.WildFarm.Models.Animals
{
    using _03.WildFarm.Contracts;
    using _03.WildFarm.Models.Foods;
    using System;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }


        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Meat)
            {
                Weight += food.Quantity * 0.30;
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

