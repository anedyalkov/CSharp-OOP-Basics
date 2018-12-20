namespace _03.WildFarm.Models.Foods
{
    using _03.WildFarm.Contracts;

    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; protected set; }
    }
}
