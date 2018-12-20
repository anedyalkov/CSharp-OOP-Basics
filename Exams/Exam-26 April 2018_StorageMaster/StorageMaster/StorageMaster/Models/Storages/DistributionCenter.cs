namespace StorageMaster.Models.Storages
{
    using System;
    using System.Collections.Generic;
    using StorageMaster.Models.Vehicles;

    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name) : base(name, capacity: 2, garageSlots: 5, vehicles: new List<Vehicle> { new Van(),new Van(),new Van()})
        {

        }
    }
}
