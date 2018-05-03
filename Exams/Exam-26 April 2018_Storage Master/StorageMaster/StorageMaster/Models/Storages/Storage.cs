using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage
    {
        private readonly Vehicle[] garage;
        private readonly List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.products = new List<Product>();
            this.garage = new Vehicle[garageSlots];

            InitializeGarage(vehicles);
        }



        public string Name { get; protected set; }

        public int Capacity { get; protected set; }

        public int GarageSlots { get; set; }

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;


        public IReadOnlyCollection<Vehicle> Garage => garage;
        public IReadOnlyCollection<Product> Products => products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
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
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            var vehicle = garage[garageSlot];

            if (!deliveryLocation.garage.Any(v => v == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            var slotNumber = 0;

            for (int i = 0; i < deliveryLocation.garage.Length; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    slotNumber = i;
                    deliveryLocation.garage[i] = vehicle;
                    garage[garageSlot] = null;
                    break;
                }
            }


            return slotNumber;
        }

        public int UnloadVehicle(int garageSlot)
        {
            var unloadeProductsCount = 0;

            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            var vehicle = this.garage[garageSlot];

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                var product = vehicle.Unload();
                unloadeProductsCount++;
                products.Add(product);
            }

            return unloadeProductsCount;

        }
        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var count = 0;
            foreach (var vehicle in vehicles)
            {
                this.garage[count] = vehicle;
                count++;
            }
        }
    }
}
