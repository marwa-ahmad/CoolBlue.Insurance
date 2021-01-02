using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain
{
    public class ProductInsurance
    {
        public int ProductId { get; set; }
        public float InsuranceValue { get; set; }
        public string ProductTypeName { get; set; }
        public bool ProductTypeHasInsurance { get; set; }
        public float SalesPrice { get; set; }
    }
}
