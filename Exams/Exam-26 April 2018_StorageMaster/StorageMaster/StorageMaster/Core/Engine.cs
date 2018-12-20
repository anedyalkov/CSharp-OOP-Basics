

namespace StorageMaster.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private bool isRunning;
        private StorageMaster storageMaster;

        public Engine(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
            this.isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    isRunning = false;
                    break;
                }
                try
                {
                    var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var command = inputArgs[0];
                    var commandArgs = inputArgs.Skip(1).ToArray();
                    Execute(command, commandArgs);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine(storageMaster.GetSummary());
        }

        private void Execute(string command, string[] commandArgs)
        {
            switch (command)
            {
                case "AddProduct":
                    Console.WriteLine(storageMaster.AddProduct(commandArgs[0], double.Parse(commandArgs[1])));
                    break;
                case "RegisterStorage":
                    Console.WriteLine(storageMaster.RegisterStorage(commandArgs[0], commandArgs[1]));
                    break;
                case "SelectVehicle":
                    Console.WriteLine(storageMaster.SelectVehicle(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "LoadVehicle":
                    Console.WriteLine(storageMaster.LoadVehicle(commandArgs));
                    break;
                case "SendVehicleTo":
                    Console.WriteLine(storageMaster.SendVehicleTo(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2]));
                    break;
                case "UnloadVehicle":
                    Console.WriteLine(storageMaster.UnloadVehicle(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "GetStorageStatus":
                    Console.WriteLine(storageMaster.GetStorageStatus(commandArgs[0]));
                    break;
                default:
                    break;
            }
        }
    }
}
