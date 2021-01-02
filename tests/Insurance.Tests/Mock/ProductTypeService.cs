using Insurance.Domain;
using Insurance.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Tests.Mock
{
    public class ProductTypeService : IProductTypeService
    {
        private List<ProductTypeResponseDto> _productTypes;
        
        public ProductTypeService()
        {
            InitializeProductTypes();
        }

        private void InitializeProductTypes()
        {
            _productTypes = new List<ProductTypeResponseDto>()
            {
                new ProductTypeResponseDto(){ CanBeInsured = true, Id = 1, Name = "Mac"},
                new ProductTypeResponseDto(){ CanBeInsured = true, Id = 2, Name = "Washing machines"},
                new ProductTypeResponseDto(){ CanBeInsured = true, Id = 3, Name = "SLR cameras"}
            };
        }

        public Task<ProductTypeResponseDto> GetProductTypeAsync(int productTypeId)
        {
            return Task.Run(() => { return _productTypes.FirstOrDefault(p => p.Id == productTypeId); });
        }
    }
}
