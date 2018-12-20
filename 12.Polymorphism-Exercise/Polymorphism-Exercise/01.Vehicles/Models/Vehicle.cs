

namespace _01.Vehicles.Models
{
    using _01.Vehicles.Contracts;

    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }
        public double FuelQuantity { get; protected set; }
        public double FuelConsumptionPerKm { get; protected set; }

        public string Drive(double distanceToTravel)
        {
            var distanceCanTravel = FuelQuantity / FuelConsumptionPerKm;

            if (distanceCanTravel < distanceToTravel)
            {
                return $"{GetType().Name} needs refueling";
            }
            else
            {
                var fuelSpent = distanceToTravel * FuelConsumptionPerKm;
                FuelQuantity -= fuelSpent;
                return $"{GetType().Name} travelled {distanceToTravel} km";
            }
        }

     

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }

   
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
