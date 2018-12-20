using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private bool isRunning;
        private DungeonMaster dungeonMaster;

        public Engine(DungeonMaster dungeonMaster)
        {
            this.isRunning = true;
            this.dungeonMaster = dungeonMaster;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var input = this.ReadInput();
                try
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        this.isRunning = false;
                        break;
                    }
                    var commandInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var command = commandInfo[0];
                    var commandArgs = commandInfo.Skip(1).ToArray();

                    ExecuteCommand(command, commandArgs);
                }
                catch (Exception e)
                {
                    if (e is ArgumentException)
                    {
                        OutputWriter($"Parameter Error: {e.Message}");

                    }
                    if (e is InvalidOperationException)
                    {
                        OutputWriter($"Invalid Operation: {e.Message}");
                    }
                }
            }

            OutputWriter("Final stats:");
            OutputWriter(this.dungeonMaster.GetStats());
        }

        private void ExecuteCommand(string command, string[] commandArgs)
        {
            switch (command)
            {
                case "JoinParty":
                    OutputWriter(this.dungeonMaster.JoinParty(commandArgs));
                    break;
                case "AddItemToPool":
                    OutputWriter(this.dungeonMaster.AddItemToPool(commandArgs));
                    break;
                case "PickUpItem":
                    OutputWriter(this.dungeonMaster.PickUpItem(commandArgs));
                    break;
                case "UseItem":
                    OutputWriter(this.dungeonMaster.UseItem(commandArgs));
                    break;
                case "UseItemOn":
                    OutputWriter(this.dungeonMaster.UseItemOn(commandArgs));
                    break;
                case "GiveCharacterItem":
                    OutputWriter(this.dungeonMaster.GiveCharacterItem(commandArgs));
                    break;
                case "GetStats":
                    OutputWriter(this.dungeonMaster.GetStats());
                    break;
                case "Attack":
                    OutputWriter(this.dungeonMaster.Attack(commandArgs));
                    break;
                case "Heal":
                    OutputWriter(this.dungeonMaster.Heal(commandArgs));
                    break;
                case "EndTurn":
                    OutputWriter(this.dungeonMaster.EndTurn(commandArgs));
                    break;
                case "IsGameOver":
                    this.isRunning = this.dungeonMaster.IsGameOver();
                    break;
            }
        }

        private void OutputWriter(string result)
        {
            Console.WriteLine(result);
        }

        private string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
