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
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) : base(name, health: 100, armor: 50, abilityPoints: 40, bag: new Satchel(), faction: faction)
        {

        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this == character)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
