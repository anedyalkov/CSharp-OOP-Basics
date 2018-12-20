namespace _02.VehiclesExtension.Models
{
    using _02.VehiclesExtension.Contracts;
    using System;

    public abstract class Vehicle : IVehicle
    {
        private double tankCapacity;
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            
        }
        public double FuelQuantity
        {
            get{ return fuelQuantity; }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
            
        }
        public double FuelConsumptionPerKm { get; protected set; }

        public double TankCapacity
        {
            get { return tankCapacity; }
            protected set
            {
                tankCapacity = value;
            }
        }

        public virtual string Drive(double distanceToTravel)
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

        public abstract string DriveEmpty(double distanceToTravel);


        public virtual void Refuel(double liters)
        {
            if (liters <= 0 )
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            if (liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            FuelQuantity += liters;
        }


        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
