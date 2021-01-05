using Insurance.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Repository
{
    public interface ISurchargeRateRepository
    {
        Task<ProductTypeSurchargeRate> AddSurchargeRateAsync(ProductTypeSurchargeRate productTypeSurchargeRate);
        Task<List<SurchargeRate>> GetSurchargeRateAsync(int productTypeId);
    }
}