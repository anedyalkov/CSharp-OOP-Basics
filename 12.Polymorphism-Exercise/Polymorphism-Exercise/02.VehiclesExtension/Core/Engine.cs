namespace _02.VehiclesExtension.Core
{
    using _02.VehiclesExtension.Contracts;
    using _02.VehiclesExtension.Models;
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var carInfo = Console.ReadLine().Split().ToArray();
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            var truckInfo = Console.ReadLine().Split().ToArray();
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            var busInfo = Console.ReadLine().Split().ToArray();
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

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
                else if (typeOfVehicle == "Bus")
                {
                    vehicle = bus;
                }
                try
                {
                    if (command == "Drive")
                    {
                        Drive(vehicle, inputArgs);
                    }
                    else if (command == "DriveEmpty")
                    {
                        DriveEmpty(vehicle, inputArgs);
                    }
                    else if (command == "Refuel")
                    {
                        Refuel(vehicle, inputArgs);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }



            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }

        private void DriveEmpty(IVehicle vehicle, string[] inputArgs)
        {
            var distanceToTravel = double.Parse(inputArgs[2]);
            Console.WriteLine(vehicle.DriveEmpty(distanceToTravel));
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
