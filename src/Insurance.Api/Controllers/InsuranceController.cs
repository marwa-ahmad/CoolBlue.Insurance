using System.Threading.Tasks;
using Insurance.Common;
using Insurance.Domain;
using Insurance.Service;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Api.Controllers
{
    [Route("api/[controller]")]
    public class InsuranceController : Controller
    {
        private IInsuranceService _insuranceService; 
        public InsuranceController(ILogger logger, IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet]
        [Route("product/{id:int}")]
        public async Task<InsuranceResponseDto> GetProductInsuranceAsync(int productId)
        {
            var productInsurance = await _insuranceService.GetProductInsuranceAsync(productId);
            return productInsurance;
        }
    }
}
