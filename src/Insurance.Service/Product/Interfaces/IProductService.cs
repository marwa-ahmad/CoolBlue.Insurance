using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public interface IProductService
    {
        Task<ProductResponseDto> GetProductAsync(int productId);
    }
}