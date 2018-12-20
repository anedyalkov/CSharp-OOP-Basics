using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure, IProcedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException($"Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;

            animal.Happiness -= 7;

            procedureHistory.Add(animal);
        }
    }
}
