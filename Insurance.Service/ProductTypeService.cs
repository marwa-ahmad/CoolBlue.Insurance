using Insurance.Common;
using Insurance.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IConfiguration _configuration;
        private static HttpClient ProductTypeClient;
        private ILogger _logger;

        private readonly string GetSingleProductTypeEndpoint;


        public ProductTypeService(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;
            _configuration = configuration;

            if (ProductTypeClient == null)//hint: used a non-static constructor because of the DI
            {
                ProductTypeClient = new HttpClient();
                ProductTypeClient.BaseAddress = new Uri(configuration["ProductType:ServiceUrl"]);
            }
            GetSingleProductTypeEndpoint = _configuration["ProductType:GetSingleProductType"];
        }

        public async Task<ProductTypeResponseDto> GetProductTypeAsync(int productTypeId)
        {
            _logger.LogInformation($"Attmpt to get ProductType[{productTypeId}] details.");

            var result = await ProductTypeClient.GetAsync(string.Format("{0}{1:G}", GetSingleProductTypeEndpoint, productTypeId));
            result.EnsureSuccessStatusCode();

            var productTypeDetailsResponse = await result.Content.ReadAsStringAsync();
            var productTypeDetails = JsonConvert.DeserializeObject<ProductTypeResponseDto>(productTypeDetailsResponse);
            if (productTypeDetails == null)
            {
                _logger.LogInformation($"ProductType[{productTypeId}] details was not found.");
                return null;
            }

            _logger.LogInformation($"Succeeded; status code[{result.StatusCode}], get ProductType[{productTypeId}] details.");

            return productTypeDetails;
        }
    }
}
