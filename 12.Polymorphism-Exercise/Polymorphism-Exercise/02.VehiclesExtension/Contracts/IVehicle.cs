namespace _02.VehiclesExtension.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKm { get; }
        double TankCapacity { get; }
        string Drive(double distanceToTravel);
        string DriveEmpty(double distanceToTravel);
        void Refuel(double liters);
    }
}
