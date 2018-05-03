using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class DistributionCenter : Storage
    {
        public  DistributionCenter(string name) : base(name, capacity: 2, garageSlots: 5, vehicles: new Vehicle[]{ new Van(), new Van(), new Van()})
        {
        }
    }
}
