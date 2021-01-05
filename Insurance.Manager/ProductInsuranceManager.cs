using Insurance.Common;
using Insurance.Domain;
using Insurance.Operations;
using Insurance.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Manager
{
    public class ProductInsuranceManager : IProductInsuranceManager
    {
        private readonly IBasicInsuranceOperation _basicInsuranceOperation;
        private readonly IExtraInsuranceOperation _extraInsuranceOperation;
        private readonly ISurchargeRateRepository _surchargeRateRepository;
        private readonly ILogger _logger;

        public ProductInsuranceManager(IBasicInsuranceOperation basicInsuranceOperation, IExtraInsuranceOperation extraInsuranceOperation, ILogger logger, ISurchargeRateRepository surchargeRateRepository)
        {
            _basicInsuranceOperation = basicInsuranceOperation;
            _extraInsuranceOperation = extraInsuranceOperation;
            _logger = logger;
            _surchargeRateRepository = surchargeRateRepository;
        }

        public async Task<float> CalculateInsuranceAsync(IProduct product)
        {
            if (!product.IsInsured)
            {
                _logger.LogInformation($"Product[{product.Id}] is not insured.");
                return 0;
            }

            var salesPrice = product.SalesPrice;
            var productType = product.ProductType;

            var insuranceValue = _basicInsuranceOperation.Calculate(salesPrice);

            var insuranceValueAfterSpecialAssets = _extraInsuranceOperation.Calculate(productType, insuranceValue);
            
            var surchargeRate = await _surchargeRateRepository.GetSurchargeRateAsync((int)productType);
            var totalSurchargeValue = 0f;
            if (surchargeRate != null)
            {
                totalSurchargeValue = surchargeRate.Select(r => (float)(r.Rate / 100f) * salesPrice).Sum();
            }

            var totalInsuranceValue = insuranceValueAfterSpecialAssets + totalSurchargeValue;
            return totalInsuranceValue;
        }
    }
}
