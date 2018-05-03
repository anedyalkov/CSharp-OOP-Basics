using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        public HardDrive(double price) : base(price, 1)
        {
        }
    }
}
