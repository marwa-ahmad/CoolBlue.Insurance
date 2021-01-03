using System;

namespace Insurance.Common
{
    public class ProductTypeNotFoundException : Exception
    {
        public ProductTypeNotFoundException(string message) : base(message)
        {
        }
    }
}
