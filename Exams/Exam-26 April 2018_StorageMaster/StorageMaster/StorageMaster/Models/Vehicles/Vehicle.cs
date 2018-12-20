namespace StorageMaster.Models.Vehicles
{
    using StorageMaster.Models.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Vehicle
    {
        private List<Product> trunk;

        protected Vehicle(int capacity)
        {
            Capacity = capacity;
            trunk = new List<Product>();
        }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<Product> Trunk => trunk.AsReadOnly();
        
        public bool IsFull => trunk.Sum(t => t.Weight) >= Capacity;
   
        //public bool IsEmpty => !this.Trunk.Any();
        public bool IsEmpty => Trunk.Count == 0;

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
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            var lastProduct = trunk.LastOrDefault();
            trunk.Remove(lastProduct);
            return lastProduct;
        }
    }
}
