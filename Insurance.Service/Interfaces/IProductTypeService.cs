using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public interface IProductTypeService
    {
        Task<ProductTypeResponseDto> GetProductTypeAsync(int productTypeId);
    }
}