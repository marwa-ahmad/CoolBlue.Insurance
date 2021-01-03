using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public interface IInsuranceService
    {
        Task<InsuranceResponseDto> GetProductInsuranceAsync(int productId);
        Task<OrderInsuranceResponseDto> GetOrderInsuranceAsync(OrderInsuranceRequestDto request);
    }
}
