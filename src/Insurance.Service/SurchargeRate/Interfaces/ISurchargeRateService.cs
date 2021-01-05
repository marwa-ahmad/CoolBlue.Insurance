using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public interface ISurchargeRateService
    {
        Task<SurchargeRateCreateResponseDto> CreateSurchargeRateAsync(SurchargeRateCreateRequestDto request);
    }
}
