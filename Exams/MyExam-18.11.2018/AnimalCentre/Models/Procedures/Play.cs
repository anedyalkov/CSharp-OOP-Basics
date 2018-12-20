using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure, IProcedure
    {

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException($"Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;

            animal.Energy -= 6;
            animal.Happiness += 12;

            procedureHistory.Add(animal);
        }
    }
}
