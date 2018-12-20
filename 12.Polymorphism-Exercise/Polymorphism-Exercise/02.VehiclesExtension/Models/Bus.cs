namespace _02.VehiclesExtension.Models
{
    using System;

    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override string Drive(double distanceToTravel)
        {
            //FuelConsumptionPerKm += 1.4;
            var distanceCanTravel = FuelQuantity / (FuelConsumptionPerKm + 1.4);

            if (distanceCanTravel < distanceToTravel)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            else
            {
                var fuelSpent = distanceToTravel * (FuelConsumptionPerKm + 1.4);
                FuelQuantity -= fuelSpent;
                return $"{GetType().Name} travelled {distanceToTravel} km";
            }
        }
        public override string DriveEmpty(double distanceToTravel)
        {
            var distanceCanTravel = FuelQuantity / FuelConsumptionPerKm;

            if (distanceCanTravel < distanceToTravel)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            else
            {
                var fuelSpent = distanceToTravel * FuelConsumptionPerKm;
                FuelQuantity -= fuelSpent;
                return $"{GetType().Name} travelled {distanceToTravel} km";
            }
        }
    }
}
