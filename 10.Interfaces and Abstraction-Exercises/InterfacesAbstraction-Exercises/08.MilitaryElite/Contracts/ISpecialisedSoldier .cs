using _08.MilitaryElite.Enums;

namespace _08.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
