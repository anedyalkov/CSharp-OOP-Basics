using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            Item item;
            switch (itemName)
            {
                case "ArmorRepairKit":
                    item = new ArmorRepairKit();
                    break;
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                case "PoisonPotion":
                    item = new PoisonPotion();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            return item;
        }
    }
}
