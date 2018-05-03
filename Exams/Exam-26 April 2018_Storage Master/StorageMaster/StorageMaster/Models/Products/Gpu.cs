using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Products
{
    public class Gpu : Product
    {
        public Gpu(double price) : base(price, 0.7)
        {
        }
    }
}
