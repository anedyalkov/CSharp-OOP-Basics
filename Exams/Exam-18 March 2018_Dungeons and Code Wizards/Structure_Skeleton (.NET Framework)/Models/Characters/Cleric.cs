using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Bags;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character,IHealable
    {
        public Cleric(string name, Faction faction) : base(name, health: 50, armor: 25, abilityPoints: 40, bag: new Backpack(), faction: faction)
        {
            
        }
        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints; 
        }
    }
}
