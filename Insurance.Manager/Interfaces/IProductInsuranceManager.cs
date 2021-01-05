using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Manager
{
    public interface IProductInsuranceManager
    {
        Task<float> CalculateInsuranceAsync(IProduct product);
    }
}