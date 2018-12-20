using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Animals
{
    public class Pig : Animal,IAnimal
    {
        public Pig(string name, int energy, int happiness, int procedureTime) : base(name, energy, happiness, procedureTime)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
