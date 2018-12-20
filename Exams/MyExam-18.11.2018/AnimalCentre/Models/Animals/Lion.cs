using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Animals
{
    public class Lion : Animal,IAnimal
    {
        public Lion(string name, int energy, int happiness, int procedureTime) : base(name, energy, happiness, procedureTime)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
