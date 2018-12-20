namespace AnimalCentre.Models.Contracts
{
    using AnimalCentre.Models.Animals;
    using System.Collections.Generic;

    public interface IProcedure
    {
        //List<IAnimal> ProcedureHistory { get; set; }
        string History();
        void DoService(IAnimal animal, int procedureTime);
    }
}
