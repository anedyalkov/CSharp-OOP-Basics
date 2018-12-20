using System.Collections.Generic;

namespace _08.MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; }
    }
}
