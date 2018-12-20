namespace StorageMaster.Core
{
    using global::StorageMaster.Factories;
    using global::StorageMaster.Models.Products;
    using global::StorageMaster.Models.Storages;
    using global::StorageMaster.Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StorageMaster
    {
        private StorageFactory storageFactory;
        private ProductFactory productFactory;
        private VehicleFactory vehicleFactory;
        private List<Storage> storageRegistry;
        private List<Product> products;
        private Vehicle vehicle;

        public StorageMaster()
        {
            storageRegistry = new List<Storage>();
            products = new List<Product>();
            storageFactory = new StorageFactory();
            productFactory = new ProductFactory();
            vehicleFactory = new VehicleFactory();

        }
        public string AddProduct(string type, double price)
        {
            //var product = productFactory.CreateProduct(type, price);
            //products.Add(product);
            //return $"Added {type} to pool";
            Product product;
            switch (type)
            {
                case "Gpu":
                    product = new Gpu(price);
                    break;
                case "HardDrive":
                    product = new HardDrive(price);
                    break;
                case "Ram":
                    product = new Ram(price);
                    break;
                case "SolidStateDrive":
                    product = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid product type!");
            }

           products.Add(product);
           return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = storageFactory.CreateStorage(type, name);
            storageRegistry.Add(storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry.FirstOrDefault(s => s.Name == storageName);
            vehicle = storage.GetVehicle(garageSlot);
            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductsCount = 0;
            var namesCount = 0;
            foreach (var productName in productNames)
            {
                namesCount++;

                if (!vehicle.IsFull)
                {
                    if (!products.Any(p => p.GetType().Name == productName))
                    {
                        throw new InvalidOperationException($"{productName} is out of stock!");
                    }

                    var lastProduct = products.LastOrDefault(p => p.GetType().Name == productName);
                    if (lastProduct == null)
                    {
                        continue;
                    }
                    else
                    {
                        products.Remove(lastProduct);
                        vehicle.LoadProduct(lastProduct);
                        loadedProductsCount++;
                    }
                }
            }

            return $"Loaded {loadedProductsCount}/{namesCount} products into {vehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = storageRegistry.FirstOrDefault(s => s.Name == sourceName);
            var destinationStorage = storageRegistry.FirstOrDefault(s => s.Name == destinationName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException($"Invalid source storage!");
            }
            if (destinationStorage == null)
            {
                throw new InvalidOperationException($"Invalid destination storage!");
            }

            vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            var freeSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);
            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {freeSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry.FirstOrDefault(s => s.Name == storageName);
            vehicle = storage.GetVehicle(garageSlot);
            var productsInVehicle = vehicle.Trunk.Count();
            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);
            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
            //var storage = storageRegistry.FirstOrDefault(s => s.Name == storageName);
            //var productsWeightSum = storage.Products.Sum(p => p.Weight);
            //var storageCapacity = storage.Capacity;
            //var products = storage.Products;

            //var stockInfo = products.GroupBy(p => p.GetType().Name)
            //     .Select(g => new
            //     {
            //         Name = g.Key,
            //         Count = g.Count()
            //     })
            //     .OrderByDescending(p => p.Count)
            //     .ThenBy(p => p.Name)
            //     .Select(p => $"{p.Name} ({p.Count})")
            //     .ToList();

            //var stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
            //    productsWeightSum,
            //    storageCapacity,
            //    string.Join(", ", stockInfo));

            //var storageGarage = storage.Garage
            //   .ToList();
            //var vehicleNames = storageGarage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToList();

            //var vehicleFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));

            //return string.Format(stockFormat + Environment.NewLine + vehicleFormat);

            var storage = storageRegistry.FirstOrDefault(st => st.Name == storageName);
            var products = storage.Products.ToList();
            var sumOfProductsWeight = products.Sum(p => p.Weight);
            var storageCapacity = storage.Capacity;
            var stockInfo = products
                .GroupBy(p => p.GetType().Name)
                .Select(gr => new
                {
                    ProductsCount = gr.Count(),
                    ProductName = gr.Key
                })
                .OrderByDescending(p => p.ProductsCount)
                .ThenBy(p => p.ProductName)
                .Select(p => $"{p.ProductName} ({p.ProductsCount})")
                .ToList();

            var vehicles = storage.Garage.ToList();
            var vehiclesAsString = new List<string>();

            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i] == null)
                {
                    vehiclesAsString.Add("empty");
                }
                else
                {
                    string vehicleName = vehicles[i].GetType().Name;
                    vehiclesAsString.Add(vehicleName);
                }
            }

            string stockFormat = $"Stock ({sumOfProductsWeight}/{storageCapacity}): [{string.Join(", ", stockInfo)}]";
            string garageFormat = $"Garage: [{string.Join("|", vehiclesAsString)}]";
            string result = stockFormat + Environment.NewLine + garageFormat;

            return result;
        }

        public string GetSummary()
        {
            var orderedStorages = storageRegistry
                .OrderByDescending(s => s.Products.Sum(p => p.Price))
                .ToList();
            var sb = new StringBuilder();
            foreach (var storage in orderedStorages)
            {
                var totalMoney = storage.Products.Sum(p => p.Price);
                sb.AppendLine($"{storage.Name}:")
                    .AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}

