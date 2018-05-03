﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name) : base(name, capacity: 1, garageSlots: 2, vehicles: new Vehicle[] { new Truck()})
        {

        }
    }
}
