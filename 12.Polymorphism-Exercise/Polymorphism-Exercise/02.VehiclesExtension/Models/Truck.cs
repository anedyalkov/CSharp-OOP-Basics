namespace _02.VehiclesExtension.Models
{
    using System;

    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            FuelConsumptionPerKm += 1.6;
        }

        public override string DriveEmpty(double distanceToTravel)
        {
            throw new System.NotImplementedException();
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            if (liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            FuelQuantity += liters * 0.95;
        }
    }
}
