using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        //private const int DefaultWeight = 5;

        public PoisonPotion() : base(weight: 5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            //Това бях пропуснал да го направя
            character.Health = Math.Max(0, character.Health - 20);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
