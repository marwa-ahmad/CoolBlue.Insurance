using System;

namespace Insurance.Common
{
    public class SurchargeRateProductTypeNotFoundException : Exception
    {
        public SurchargeRateProductTypeNotFoundException(string message) : base(message)
        {
        }
    }
}
