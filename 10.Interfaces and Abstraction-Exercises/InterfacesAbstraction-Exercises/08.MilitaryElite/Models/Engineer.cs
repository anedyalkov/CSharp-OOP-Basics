namespace _08.MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _08.MilitaryElite.Contracts;
    using _08.MilitaryElite.Enums;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<IRepair>(); 
        }

        public ICollection<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps}")
                .AppendLine($"Repairs:")
                 .AppendLine(string.Join(Environment.NewLine, Repairs));

            return sb.ToString().Trim();
        }
    }
}
