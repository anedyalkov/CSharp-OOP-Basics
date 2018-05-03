using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            var input = this.ReadInput();

            while (input != "END")
            {
                try
                {
                    var commandInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var command = commandInfo[0];
                    var commandArgs = commandInfo.Skip(1).ToArray();

                    ExecuteCommand(command, commandArgs);
                }
                catch (Exception e)
                {
                    if (e is InvalidOperationException)
                    {
                        OutputWriter($"Error: {e.Message}");
                    }
                }

                input = this.ReadInput();
            }

            OutputWriter(this.storageMaster.GetSummary());
        }

        private void ExecuteCommand(string command, string[] commandArgs)
        {
            switch (command)
            {
                case "AddProduct":
                    OutputWriter(this.storageMaster.AddProduct(commandArgs[0], double.Parse(commandArgs[1])));
                    break;
                case "RegisterStorage":
                    OutputWriter(this.storageMaster.RegisterStorage(commandArgs[0], commandArgs[1]));
                    break;
                case "SelectVehicle":
                    OutputWriter(this.storageMaster.SelectVehicle(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "LoadVehicle":
                    OutputWriter(this.storageMaster.LoadVehicle(commandArgs));
                    break;
                case "SendVehicleTo":
                    OutputWriter(this.storageMaster.SendVehicleTo(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2]));
                    break;
                case "UnloadVehicle":
                    OutputWriter(this.storageMaster.UnloadVehicle(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "GetStorageStatus":
                    OutputWriter(this.storageMaster.GetStorageStatus(commandArgs[0]));
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
    

  
