using Insurance.Domain;
using System.Linq;

namespace Insurance.Operations
{
    public class OrderBasicOperation : IOrderBasicOperation
    {
        /// <summary>
        /// Sums order's all products' insurance value.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public float Calculate(IOrder order)
        {
            var totalInsuranceValue = order.Products.Sum(p => p.InsuranceValue);
            return totalInsuranceValue;
        }
    }
}
