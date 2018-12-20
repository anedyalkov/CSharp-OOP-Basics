using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Animals
{
    public class Dog : Animal,IAnimal
    {
        public Dog(string name, int energy, int happiness, int procedureTime) : base(name, energy, happiness, procedureTime)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
