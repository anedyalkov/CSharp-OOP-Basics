namespace _08.MilitaryElite.Models
{
    using _08.MilitaryElite.Contracts;
    using _08.MilitaryElite.Enums;
    using System.Text;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }

    }
}
