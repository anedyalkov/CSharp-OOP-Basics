namespace _01.Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKm { get; }
        string Drive(double distanceToTravel);
        void Refuel(double liters);
    }
}
