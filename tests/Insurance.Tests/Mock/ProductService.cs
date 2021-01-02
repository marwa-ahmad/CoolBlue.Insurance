using Insurance.Domain;
using Insurance.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Tests
{
    public class ProductService : IProductService
    {
        private List<ProductResponseDto> _productTypes;

        public ProductService()
        {
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            _productTypes = new List<ProductResponseDto>()
            {
                new ProductResponseDto(){ ProductTypeId  = 1, SalesPrice = 400,Id = 11},
                new ProductResponseDto(){ ProductTypeId = 1, SalesPrice = 500, Id = 12},
                new ProductResponseDto(){ ProductTypeId = 3, SalesPrice = 400, Id = 13}
            };
        }

        public Task<ProductResponseDto> GetProductAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
