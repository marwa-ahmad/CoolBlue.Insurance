using Insurance.Common;
using Insurance.Domain;
using Insurance.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public class SurchargeRateService : ISurchargeRateService
    {
        private ILogger _logger;
        private IProductTypeService _productTypeService;
        private ISurchargeRateRepository _surchargeRateRepository;

        public SurchargeRateService(ILogger logger, IProductTypeService productTypeService, ISurchargeRateRepository surchargeRateRepository)
        {
            _logger = logger;
            _productTypeService = productTypeService;
            _surchargeRateRepository = surchargeRateRepository;
        }

        public async Task<SurchargeRateCreateResponseDto> CreateSurchargeRateAsync(SurchargeRateCreateRequestDto request)
        {
            var isProductIdExists = await _productTypeService.IsProductTypeIdExistsAsync(request.ProductTypeId);
            if (!isProductIdExists)
            {
                var message = $"ProductTypeId[{request.ProductTypeId}] is not found.";
                _logger.LogError(message);
                throw new SurchargeRateProductTypeNotFoundException(message);
            }
            
            var productTypeSurchargeRate = new ProductTypeSurchargeRate()
            {
                ProductTypeId = request.ProductTypeId,
                SurchargeRates = request.SurchareRates.Select(r => new SurchargeRate() { Rate = r }).ToList()
            };

            var surchargeRate = await _surchargeRateRepository.AddSurchargeRateAsync(productTypeSurchargeRate);

            return new SurchargeRateCreateResponseDto() 
            {
                SurchareRates = surchargeRate.SurchargeRates.Select(r=>r.Rate).ToList(),
                ProductTypeId = surchargeRate.ProductTypeId
            };
        }
    }
}
