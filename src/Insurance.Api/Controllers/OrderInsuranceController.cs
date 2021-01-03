using Insurance.Common;
using Insurance.Domain;
using Insurance.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Insurance.Api.Controllers
{
    [Route("api/insurance")]
    [Produces("application/json")]
    public class OrderInsuranceController : Controller
    {
        private IInsuranceService _insuranceService;

        public OrderInsuranceController(ILogger logger, IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        /// <summary>
        /// Get the order's insurance cost based on its products' sales price.
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("product/{productId}")]
        [SwaggerOperation(Summary = "Product's insurance", Description = "Gets product's insurance cost based on its sales price")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OrderInsuranceResponseDto), Description = "Returns the order's total insurance cost")]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "This means no product with the given id was found.")]
        public async Task<IActionResult> GetOrderInsuranceAsync(OrderInsuranceRequestDto request)
        {
            OrderInsuranceResponseDto productsInsurance = await _insuranceService.GetOrderInsuranceAsync(request);
            if (productsInsurance == null)
            {
                return NoContent();
            }
            return Ok(productsInsurance);
        }
    }
}
