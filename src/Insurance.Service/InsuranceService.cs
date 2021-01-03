using Insurance.Common;
using Insurance.Domain;
using Insurance.Operations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public class InsuranceService : IInsuranceService
    {
        private ILogger _logger;
        private IProductTypeService _productTypeService;
        private IProductService _productService;
        private IProductInsuranceManager _productInsuranceManager;


        public InsuranceService(IProductTypeService productTypeService, IProductService productService, IProductInsuranceManager productInsuranceManager, ILogger logger)
        {
            _logger = logger;
            _productTypeService = productTypeService;
            _productService = productService;
            _productInsuranceManager = productInsuranceManager;
        }

        public async Task<InsuranceResponseDto> GetProductInsuranceAsync(int productId)
        {
            var productDetails = await _productService.GetProductAsync(productId);
            if (productDetails == null)
            {
                throw new ProductNotFoundException($"Could not proceed with Get product's insurance; product[{productId}] was not found.");
            }

            var productType = await _productTypeService.GetProductTypeAsync(productDetails.ProductTypeId);
            if (productType == null)
            {
                throw new ProductTypeNotFoundException($"Could not proceed with Get product insurance; productType[{productDetails.ProductTypeId}] was not found.");
            }

            var product = new Product()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                ProductType = (ProductType)productDetails.ProductTypeId,
                SalesPrice = productDetails.SalesPrice,
                IsInsured = productType.CanBeInsured,
            };

            float insuranceValue = _productInsuranceManager.CalculateInsurance(product);

            return new InsuranceResponseDto() 
            {
                InsuranceValue = insuranceValue,
                ProductId = productId
            };
        }

        public async Task<OrderInsuranceResponseDto> GetOrderInsuranceAsync(OrderInsuranceRequestDto request)
        {
            var productsInsuranceTasks = new List<Task<InsuranceResponseDto>>();
            foreach (var productId in request.ProductsIds)
            {
                productsInsuranceTasks.Add(GetProductInsuranceAsync(productId));
            }
            var result = await Task.WhenAll(productsInsuranceTasks);

            if (result.IsEmpty())
            {
                _logger.LogInformation($"Could not proceed with Get order insurance; products' insurance were null/empty.");
                return null;
            }

            var totalInsurance = result.Sum(r => r.InsuranceValue);
            return new OrderInsuranceResponseDto()
            {
                TotalInsuranceValue = totalInsurance
            };
        }
    }
}
