using System.Collections.Generic;

namespace _08.MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; }
    }
}
