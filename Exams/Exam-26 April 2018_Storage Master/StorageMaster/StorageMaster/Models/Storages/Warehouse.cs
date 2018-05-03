using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
        public Warehouse(string name) : base(name, capacity: 10, garageSlots: 10, vehicles: new List<Vehicle> { new Semi(), new Semi(), new Semi()})
        {
        }
    }
}
