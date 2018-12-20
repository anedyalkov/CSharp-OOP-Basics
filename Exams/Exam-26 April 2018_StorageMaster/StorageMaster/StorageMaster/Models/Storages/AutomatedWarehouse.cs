﻿using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name) : base(name, capacity: 1, garageSlots: 2, vehicles:new List<Vehicle>{ new Truck()})
        {
        }
    }
}
