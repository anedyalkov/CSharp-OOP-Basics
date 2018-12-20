namespace _03.WildFarm.Models.Animals
{
    using _03.WildFarm.Contracts;

    public abstract class Bird : Animal, IBird
    {
        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; protected set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }

    }
}
