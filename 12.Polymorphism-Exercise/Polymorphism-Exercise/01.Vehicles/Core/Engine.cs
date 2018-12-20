namespace _01.Vehicles.Core
{
    using _01.Vehicles.Contracts;
    using _01.Vehicles.Models;
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var carInfo = Console.ReadLine().Split().ToArray();
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            var truckInfo = Console.ReadLine().Split().ToArray();
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var inputArgs = Console.ReadLine().Split().ToArray();

                var command = inputArgs[0];
                var typeOfVehicle = inputArgs[1];

                IVehicle vehicle = null;

                if (typeOfVehicle == "Car")
                {
                    vehicle = car;
                }
                else if (typeOfVehicle == "Truck")
                {
                    vehicle = truck;
                }

                if (command == "Drive")
                {
                    Drive(vehicle, inputArgs);
                }
                else if (command == "Refuel")
                {
                    Refuel(vehicle, inputArgs);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void Drive(IVehicle vehicle, string[] inputArgs)
        {
            var distanceToTravel = double.Parse(inputArgs[2]);
            Console.WriteLine(vehicle.Drive(distanceToTravel));
        }

        private static void Refuel(IVehicle vehicle, string[] inputArgs)
        {
            var liters = double.Parse(inputArgs[2]);
            vehicle.Refuel(liters);
        }
    }
}

