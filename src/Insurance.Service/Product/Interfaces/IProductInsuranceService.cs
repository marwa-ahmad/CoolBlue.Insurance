using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public interface IProductInsuranceService
    {
        Task<InsuranceResponseDto> GetProductInsuranceAsync(int productId);
        Task<ProductInsurance> GetProductInsuranceDetailsAsync(int productId);
    }
}
