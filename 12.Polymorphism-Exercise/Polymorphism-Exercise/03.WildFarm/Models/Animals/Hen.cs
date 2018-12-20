using _03.WildFarm.Contracts;

namespace _03.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void Eat(IFood food)
        {
            Weight += food.Quantity * 0.35;
            FoodEaten = food.Quantity;
        }
    }
}
