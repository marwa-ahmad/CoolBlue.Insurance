using System;

namespace Insurance.Common
{
    public class ProductTypeAlreadyHasSurchargeRateException : Exception
    {
        public ProductTypeAlreadyHasSurchargeRateException(string message) : base(message)
        {
        }
    }
}
