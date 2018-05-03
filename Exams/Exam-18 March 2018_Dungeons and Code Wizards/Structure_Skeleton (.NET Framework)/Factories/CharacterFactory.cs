using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            Character character;
            switch (type)
            {
                case "Warrior":
                    character = new Warrior(name, parsedFaction);
                    break;
                case "Cleric":
                    character = new Cleric(name, parsedFaction);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            return character;
        }
    }
}

