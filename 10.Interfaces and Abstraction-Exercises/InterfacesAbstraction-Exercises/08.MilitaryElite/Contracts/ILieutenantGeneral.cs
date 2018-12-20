using System.Collections.Generic;

namespace _08.MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; }
    }
}
