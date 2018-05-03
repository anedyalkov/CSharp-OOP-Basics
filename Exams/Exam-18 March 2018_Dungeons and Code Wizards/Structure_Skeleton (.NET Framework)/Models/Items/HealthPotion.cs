using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int DefaultWeight = 5;

        public HealthPotion() : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20;
        }
    }
}
