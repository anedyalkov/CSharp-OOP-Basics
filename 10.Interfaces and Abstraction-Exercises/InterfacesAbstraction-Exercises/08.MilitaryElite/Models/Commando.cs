namespace _08.MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _08.MilitaryElite.Contracts;
    using _08.MilitaryElite.Enums;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps}")
                .AppendLine($"Missions:")
                 .AppendLine(string.Join(Environment.NewLine, Missions));

            return sb.ToString().Trim();
        }
    }
}
