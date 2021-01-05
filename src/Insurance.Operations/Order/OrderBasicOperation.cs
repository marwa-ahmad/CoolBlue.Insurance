using Insurance.Domain;
using System.Linq;

namespace Insurance.Operations
{
    public class OrderBasicOperation : IOrderBasicOperation
    {
        public float Calculate(IOrder order)
        {
            var totalInsuranceValue = order.Products.Sum(p => p.InsuranceValue);
            return totalInsuranceValue;
        }
    }
}
