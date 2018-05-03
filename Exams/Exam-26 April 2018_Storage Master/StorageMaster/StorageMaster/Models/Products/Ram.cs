using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Products
{
    public class Ram : Product
    {
        public Ram(double price) : base(price, 0.1)
        {
        }
    }
}
