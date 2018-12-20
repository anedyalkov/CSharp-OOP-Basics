namespace _08.MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _08.MilitaryElite.Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Privates:")
                .AppendLine(string.Join(Environment.NewLine, Privates));
   
            return sb.ToString().Trim();
        }
    }
}
