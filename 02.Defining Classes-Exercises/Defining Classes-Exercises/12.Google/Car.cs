namespace DefiningClasses
{
    using System.Text;

    public class Car
    {
        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }
        public string Model { get; set; }
        public int Speed { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Model} {Speed}");
            return sb.ToString().Trim();
        }
    }
}