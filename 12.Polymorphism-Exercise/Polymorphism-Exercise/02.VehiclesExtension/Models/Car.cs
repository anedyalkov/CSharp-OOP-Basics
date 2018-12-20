namespace _02.VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            FuelConsumptionPerKm += 0.9;
        }

        public override string DriveEmpty(double distanceToTravel)
        {
            throw new System.NotImplementedException();
        }
    }
}
