namespace _06.Animals.Animals
{
    public class Kitten : Cat
    {
        
        public Kitten(string name, int age) : base(name, age, "Female")
        {
            
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
