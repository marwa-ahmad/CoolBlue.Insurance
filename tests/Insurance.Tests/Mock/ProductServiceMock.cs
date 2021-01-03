using Insurance.Domain;
using Insurance.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Tests
{
    public class ProductServiceMock : IProductService
    {
        private List<ProductResponseDto> _products;

        public ProductServiceMock()
        {
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            _products = new List<ProductResponseDto>()
            {
                new ProductResponseDto(){ ProductTypeId  = 33, SalesPrice = 600, Id = 1},
                new ProductResponseDto(){ ProductTypeId = 32, SalesPrice = 400, Id = 2},
                new ProductResponseDto(){ ProductTypeId = 21, SalesPrice = 700, Id = 3},
                new ProductResponseDto(){ ProductTypeId = 33, SalesPrice = 400, Id = 4},
                new ProductResponseDto(){ ProductTypeId = 33, SalesPrice = 2000, Id = 5},
                new ProductResponseDto(){ ProductTypeId = 32, SalesPrice = 2000, Id = 6}
            };
        }

        public Task<ProductResponseDto> GetProductAsync(int productId)
        {
            return Task.Run(() => { return _products.FirstOrDefault(p => p.Id == productId); });
        }
    }
}
