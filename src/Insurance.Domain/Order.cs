using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain
{
    public class Order : IOrder
    {
        public List<ProductInsurance> Products { get; set; }
    }
}
