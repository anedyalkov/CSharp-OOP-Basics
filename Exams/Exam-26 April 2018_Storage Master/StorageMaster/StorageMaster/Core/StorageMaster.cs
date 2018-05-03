using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private List<Product> productPool;
        private List<Storage> storageRegistry;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            var productFactory = new ProductFactory();

            var product = productFactory.CreateProduct(type, price);
            productPool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storageFactory = new StorageFactory();

            var storage = storageFactory.CreateStorage(type, name);
            storageRegistry.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry.FirstOrDefault(s => s.Name == storageName);

            var vehicle = storage.GetVehicle(garageSlot);
            this.currentVehicle = vehicle;

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var count = 0;
            var namesCount = 0;

            foreach (var product in productNames)
            {
                namesCount++;

                if (!currentVehicle.IsFull)
                {
                    if (productPool.Any(p => p.GetType().Name == product))
                    {
                        var productToRemove = productPool.Last(p => p.GetType().Name == product);
                        currentVehicle.LoadProduct(productToRemove);
                        count++;
                        productPool.Remove(productToRemove);
                    }
                    else
                    {
                        throw new InvalidOperationException($"{product} is out of stock!");
                    }
                }
            }



            return $"Loaded {count}/{namesCount} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = storageRegistry.FirstOrDefault(st => st.Name == sourceName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException($"Invalid source storage!");
            }

            var destinationStorage = storageRegistry.FirstOrDefault(st => st.Name == destinationName);

            if (destinationStorage == null)
            {
                throw new InvalidOperationException($"Invalid destination storage!");
            }

            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            var freeSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {freeSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry.FirstOrDefault(st => st.Name == storageName);

            var vehicle = storage.GetVehicle(garageSlot);

            var productsInVehicle = vehicle.Trunk.Count;

            var unloadedCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedCount}/{productsInVehicle} products at {storage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = storageRegistry.FirstOrDefault(s => s.Name == storageName);

            var productsWeightSum = storage.Products.Sum(p => p.Weight);
            var storageCapacity = storage.Capacity;

            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToList();

            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
                productsWeightSum,
                storageCapacity,
                string.Join(", ", stockInfo));

            var storageGarage = storage.Garage
                 .ToList();
            var vehicleNames = storageGarage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToList();

            var vehicleFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));

            return string.Format(stockFormat + Environment.NewLine + vehicleFormat);
            
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            var orderedStorageRegistry = storageRegistry
                 .OrderByDescending(s => s.Products.Sum(p => p.Price))
                 .ToList();

            foreach (var storage in orderedStorageRegistry)
            {
                sb.AppendLine( $"{storage.Name}:" + Environment.NewLine + $"Storage worth: ${storage.Products.Sum(p => p.Price):F2}");
            }

            return sb.ToString().Trim();
        }
    }
}

