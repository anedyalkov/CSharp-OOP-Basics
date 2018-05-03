﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Backpack : Bag
    {
        private const int DefaultCapacity = 100;

        public Backpack() : base(DefaultCapacity)
        {
        }
    }
}
