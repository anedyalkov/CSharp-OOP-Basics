using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        private string NameExceptionMessage = "Name cannot be null or whitespace!";

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }

        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(NameExceptionMessage);
                }
                name = value;
            }
        }

        public double BaseHealth { get; protected set; }

        public double Health
        {
            get { return health; }
            set
            {
                health = Math.Min(value, this.BaseHealth);
            }
        }


        public double BaseArmor { get; protected set; }

        public double Armor
        {
            get { return armor; }
            set
            {
                armor = Math.Min(value, BaseArmor);
            }
        }

        public double AbilityPoints { get; protected set; }

        public Bag Bag { get; protected set; }

        public Faction Faction { get; protected set; }

        public bool IsAlive { get; set; } = true;

        public virtual double RestHealMultiplier => 0.2;


        public  virtual void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (hitPoints > this.Armor)
            {
                
                if (this.Health <= (hitPoints - this.Armor))
                {
                    this.Health = 0;
                    this.Armor = 0;
                }
                else
                {
                    this.Health -= (hitPoints - this.Armor);
                    this.Armor = 0;
                }
            }
            else
            {
                this.Armor -= hitPoints;
            }

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }


        public virtual void Rest()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            this.Health += (this.BaseHealth * this.RestHealMultiplier);
        }

        public virtual void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }

       

        public virtual void UseItemOn(Item item, Character character)
        {
            if (!this.IsAlive && character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(character);
        }

        public virtual void GiveCharacterItem(Item item, Character character)
        {
            if (!this.IsAlive && character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.ReceiveItem(item);
        }

        public virtual void ReceiveItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            this.Bag.AddItem(item);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            var status = string.Empty;
            if (IsAlive)
            {
                status = "Alive";
            }
            else
            {
                status = "Dead";
            }
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}
