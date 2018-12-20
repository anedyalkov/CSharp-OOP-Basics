namespace _03.WildFarm.Models.Animals
{
    using _03.WildFarm.Contracts;

    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract void Eat(IFood food);
       
        public abstract string ProduceSound();
       
    }
}
