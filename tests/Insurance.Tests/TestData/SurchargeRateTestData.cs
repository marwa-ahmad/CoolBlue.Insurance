using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Tests
{
    public class SurchargeRateTestData
    {
        public static IEnumerable<object[]> ValidSurchargeRates = new List<object[]>
        {
            new object[]
            {
                new ProductTypeSurchargeRateRequestDto()
                {
                    ProductTypeId = 33,
                    SurchareRates = new List<float>(){ 20, 10, 10}
                }
            }
        };

        //public static IEnumerable<object[]> CreateDistinctSurchargeRates = new List<object[]>
        //{
        //    new object[]
        //    {
        //        new SurchargeRateCreateRequestDto()
        //        {
        //            ChargeRates = new List<ChargeRates>()
        //            {
        //                new ChargeRates()
        //                {
        //                    new SurchargeRate(){Name = "Taxs", Percentage = 12.5f},
        //                    new SurchargeRate(){Name = "Shipping", Percentage = 3.0f},
        //                }
        //            }
        //        },
        //        new List<string>(){ "Taxs", "Shipping"}
        //    }
        //};

        //public static IEnumerable<object[]> TwoProductTypesWithSurchargeRates_SingleStep = new List<object[]>
        //{
        //    new object[]
        //    {
        //        new ProductTypeSurchargeRateRequestSingleDto()
        //        {
        //            ProductTypesChargeRates = new List<ProductTypeChargeRatesSingle>()
        //            {
        //                new ProductTypeChargeRatesSingle()
        //                {
        //                    ProductTypeId = 33,
        //                    SurchareRates = new List<float>(){ 20, 10, 5}
        //                },
        //                new ProductTypeChargeRates()
        //                {
        //                    ProductTypeId = 21,
        //                    SurchareRates = new List<float>(){15}
        //                }
        //            }
        //        }
        //    }
        //};
    }
}
