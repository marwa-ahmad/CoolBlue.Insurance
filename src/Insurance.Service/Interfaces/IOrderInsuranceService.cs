
using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public interface IOrderInsuranceService
    {
        Task<OrderInsuranceResponseDto> GetOrderInsuranceAsync(OrderInsuranceRequestDto request);
    }
}
