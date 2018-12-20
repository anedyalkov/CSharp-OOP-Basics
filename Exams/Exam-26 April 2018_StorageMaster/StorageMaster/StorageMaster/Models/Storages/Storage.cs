namespace StorageMaster.Models.Storages
{
    using StorageMaster.Models.Products;
    using StorageMaster.Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Storage
    {
        private Vehicle[] garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            garage = new Vehicle[garageSlots];
            products = new List<Product>();
            InitializeGarage(vehicles);
        }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int GarageSlots  { get; set; }
        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(garage);
        public IReadOnlyCollection<Product> Products => products.AsReadOnly();


        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            var vehicle = garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
          
            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {

            var vehicle = this.GetVehicle(garageSlot);

            if (!deliveryLocation.garage.Any(v => v == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }
            this.garage[garageSlot] = null;

            int freeSlot = 0;
            for (int i = 0; i < deliveryLocation.garage.Length; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    freeSlot = i;
                    break;
                }
            }

            deliveryLocation.garage[freeSlot] = vehicle;
            return freeSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var vehicle = this.GetVehicle(garageSlot);
            var countOfUnloadedProducts = 0;
            while (vehicle.IsEmpty == false && this.IsFull == false)
            {
                var product = vehicle.Unload();
                this.products.Add(product);
                countOfUnloadedProducts++;
            }

            return countOfUnloadedProducts;
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var index = 0;
            foreach (var vehicle in vehicles)
            {
                this.garage[index] = vehicle;
                index++;
            }
        }
    }
}
