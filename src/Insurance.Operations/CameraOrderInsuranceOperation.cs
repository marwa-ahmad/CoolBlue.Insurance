using Insurance.Domain;
using System.Linq;

namespace Insurance.Operations
{
    public class CameraOrderInsuranceOperation : ICameraOrderInsuranceOperation
    {
        public float Calculate(IOrder order)
        {
            var containsCamerasMoreThanOne = order.Products.Where(p => p.IsInsured && p.ProductType == ProductType.Camera).Count() > 1;
            if (!containsCamerasMoreThanOne)
            {
                return 0;
            }
            return 500;
        }
    }
}
