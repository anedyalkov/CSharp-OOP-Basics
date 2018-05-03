using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Satchel : Bag
    {
        private const int DefaultCapacity = 20;

        public Satchel() : base(DefaultCapacity)
        {
        }
    }
}
