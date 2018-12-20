using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> characterParty;
        private List<Item> itemPool;
        private int rounds;

        public DungeonMaster()
        {
            this.characterParty = new List<Character>();
            this.itemPool = new List<Item>();
            this.rounds = 0;
        }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var characterType = args[1];
            var name = args[2];

            var characterFactory = new CharacterFactory();

            var character = characterFactory.CreateCharacter(faction, characterType, name);
            characterParty.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];
            var itemFactory = new ItemFactory();
            var item = itemFactory.CreateItem(itemName);
            itemPool.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            var character = characterParty.FirstOrDefault(ch => ch.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            var item = itemPool.LastOrDefault();

            itemPool.Remove(item);
            character.ReceiveItem(item);

            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = characterParty.FirstOrDefault(ch => ch.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            character.UseItem(character.Bag.GetItem(itemName));

            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = characterParty.FirstOrDefault(ch => ch.Name == giverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            var receiver = characterParty.FirstOrDefault(ch => ch.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = characterParty.FirstOrDefault(ch => ch.Name == giverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            var receiver = characterParty.FirstOrDefault(ch => ch.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            //var sortedCharacterParty = characterParty
            //      .OrderByDescending(ch => ch.IsAlive)
            //      .ThenByDescending(ch => ch.Health)
            //      .ToList();

            //var result = string.Join(Environment.NewLine, sortedCharacterParty);

            //return result;
            var sb = new StringBuilder();
            var sortedCharacterParty = characterParty
                  .OrderByDescending(ch => ch.IsAlive)
                  .ThenByDescending(ch => ch.Health)
                  .ToList();

            foreach (var ch in sortedCharacterParty)
            {
                sb.AppendLine($"{ch}");
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = characterParty.FirstOrDefault(ch => ch.Name == attackerName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            var receiver = characterParty.FirstOrDefault(ch => ch.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (!(attacker is IAttackable warrior))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            warrior.Attack(receiver);

            var sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! " +
                $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");


            if (receiver.IsAlive == false)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = characterParty.FirstOrDefault(ch => ch.Name == healerName);

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            var healingReceiver = characterParty.FirstOrDefault(ch => ch.Name == healingReceiverName);

            if (healingReceiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (!(healer is IHealable healerCharacter))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            healerCharacter.Heal(healingReceiver);

            var sb = new StringBuilder();

            sb.AppendLine($"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!");

            return sb.ToString().Trim();
        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = characterParty.Where(ch => ch.IsAlive).ToList();

            var sb = new StringBuilder();
            foreach (var ch in aliveCharacters)
            {
                var healthBeforeRest = ch.Health;
                ch.Rest();
                sb.AppendLine($"{ch.Name} rests ({healthBeforeRest} => {ch.Health})");
            }

            if (aliveCharacters.Count <= 1)
            {
                this.rounds++;
            }

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if ((this.rounds > 1) && (this.characterParty.Count(c => c.IsAlive) <= 1))
            {
                return true;
            }

            return false;
        }
    }
}
