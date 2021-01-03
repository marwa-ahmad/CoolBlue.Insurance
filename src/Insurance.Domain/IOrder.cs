using System.Collections.Generic;

namespace Insurance.Domain
{
    public interface IOrder
    {
        List<ProductInsurance> Products { get; set; }
    }
}
