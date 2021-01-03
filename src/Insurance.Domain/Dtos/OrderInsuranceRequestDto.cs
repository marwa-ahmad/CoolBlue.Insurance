
using Insurance.Domain.ValidationExtension;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Insurance.Domain
{
    public class OrderInsuranceRequestDto
    {
        [JsonPropertyName("productsIds")]
        [CannotBeEmtyList]
        public IList<int> ProductsIds { get; set; }
    }
}
