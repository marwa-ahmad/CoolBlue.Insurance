using Insurance.Common;
using Insurance.Domain;

namespace Insurance.Operations
{
    public class ProductInsuranceManager : IProductInsuranceManager
    {
        private readonly IBasicInsuranceOperation _basicInsuranceOperation;
        private readonly IExtraInsuranceOperation _extraInsuranceOperation;
        private readonly ILogger _logger;

        public ProductInsuranceManager(IBasicInsuranceOperation basicInsuranceOperation, IExtraInsuranceOperation extraInsuranceOperation, ILogger logger)
        {
            _basicInsuranceOperation = basicInsuranceOperation;
            _extraInsuranceOperation = extraInsuranceOperation;
            _logger = logger;
        }

        public float CalculateInsurance(IProduct product)
        {
            if (!product.IsInsured)
            {
                _logger.LogInformation($"Product[{product.Id}] is not insured.");
                return 0;
            }

            var salesPrice = product.SalesPrice;
            var productType = product.ProductType;

            float insuranceValue = _basicInsuranceOperation.Calculate(salesPrice);

            var totalInsuranceValue = _extraInsuranceOperation.Calculate(productType, insuranceValue);
            return totalInsuranceValue;
        }
    }
}
