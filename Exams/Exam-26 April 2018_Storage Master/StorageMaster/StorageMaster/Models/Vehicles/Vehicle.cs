using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private readonly List<Product> trunk;


        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }
        public int Capacity { get; set; }

        public IReadOnlyCollection<Product> Trunk => trunk.AsReadOnly();

        public bool IsFull => trunk.Sum(t => t.Weight) >= Capacity;

        public bool IsEmpty => !this.Trunk.Any();

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            trunk.Add(product);
        }

        public Product Unload()
        {
            if (trunk.Count == 0)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            var lastProduct = trunk.LastOrDefault();
            trunk.Remove(lastProduct);

            return lastProduct;
        }
    }
}
