using Insurance.Domain;
using System.Collections.Generic;

namespace Insurance.Tests
{
    public class SurchargeRateTestData
    {
        public static IEnumerable<object[]> ValidSurchargeRates = new List<object[]>
        {
            new object[]
            {
                new SurchargeRateCreateRequestDto()
                {
                    ProductTypeId = 2,
                    SurchareRates = new List<float>(){ 20, 10}
                }
            }
        };

        public static IEnumerable<object[]> InsuranceWithSurchargeRate = new List<object[]>
        {
            new object[]
            {
                20,
                2900,
                new SurchargeRateCreateRequestDto()
                {
                    ProductTypeId = 124,
                    SurchareRates = new List<float>(){ 20, 10}
                }
            }
        };
    }
}
