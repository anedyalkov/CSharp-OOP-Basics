using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
