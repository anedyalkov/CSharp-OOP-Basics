using System;

namespace DefiningClasses
{
    public class Car
    {

        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionFor1km = fuelConsumptionFor1km;
            TravelledDistance = 0;

        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionFor1km { get; set; }
        public double TravelledDistance { get; set; }
        
       

        public bool Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumptionFor1km;
            if (this.FuelAmount < fuelNeeded)
            {
                return false;
            }
            this.FuelAmount -= fuelNeeded;
            this.TravelledDistance += distance;
            return true;
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {TravelledDistance}";
        }
    }
}
