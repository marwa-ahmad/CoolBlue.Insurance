using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Insurance.Tests.Controllers
{
    /// <summary>
    /// Two approaches to assign surcharge rate to a product type:
    /// 1. simple choice in three stpes:(preferred; because of the separation of concern, high maintainability, decoupled solution)
    /// 1.a. create endpoint for creating surcharge rates; Name, Value --> returns the Id of the surcharge rate created or the whole object created
    /// 1.b. create endpoint to list all surcharge rates; Id, Name, Value
    /// 1.c. create endpoint to assign product type to its surcharge rates; productTypeId, surchargeRatesIds
    /// 
    /// 2. one single step
    /// 2.a CreateSurchareRateProductType; send productId with list of floats which are surchargeRates
    /// Cons of 2nd choice is: 
    ///     could add add multiple surcharge rates with the same value
    ///     not extendable functionality; not easy to maintain
    /// 
    /// </summary>
    public class SurchargeRateControllerUnitTest : IClassFixture<SetupTestFixture>
    {
        private readonly IServiceProvider _serviceProvider;
        private SurchargeRateController _surchargeRateController;

        public SurchargeRateControllerUnitTest(SetupTestFixture setuptestFixture)
        {
            _serviceProvider = setuptestFixture.ServiceProvider;

            _surchargeRateController = _serviceProvider.GetService<SurchargeRateController>();
        }

        //[Theory]
        //[MemberData(nameof(SurchargeRateTestData.CreateDistinctSurchargeRates), MemberType = typeof(SurchargeRateTestData))]
        //public async Task CreateSurchargeRates_ExpectedCreated(SurchargeRateCreateRequestDto surchargeRateCreateRequestDto, List<string> expectedSurchargeNames)
        //{
        //    //we need async data structure for storing the product type and its surcharge rate
        //    var result = await _surchargeRateController.CreateSurchargeRates(surchargeRateCreateRequestDto);
        //    Assert.IsType<CreatedResult>(result);

        //    Assert.Equal(
        //        expected: expectedSurchargeNames,
        //        actual: ((SurchargeRateCreateResponseDto)((OkObjectResult)result).Value).SurchargeRates.Select(r => r.Name).ToList()
        //    );
        //}

        //[Theory]
        //[MemberData(nameof(SurchargeRateTestData.CreateDistinctSurchargeRates), MemberType = typeof(SurchargeRateTestData))]
        //public async Task GetSurchargeRates_ExpectedList(SurchargeRateCreateRequestDto surchargeRateCreateRequestDto, List<string> expectedSurchargeNames)
        //{
        //    var result = await _surchargeRateController.CreateSurchargeRates(surchargeRateCreateRequestDto);
        //    Assert.IsType<CreatedResult>(result);

        //    Assert.Equal(
        //        expected: expectedSurchargeNames,
        //        actual: ((SurchargeRateCreateResponseDto)((OkObjectResult)result).Value).SurchargeRates.Select(r => r.Name).ToList()
        //    );

        //    var result = await _surchargeRateController.GetSurchargeRates();
        //    Assert.IsType<CreatedResult>(result);

        //    Assert.Equal(
        //        expected: expectedSurchargeNames,
        //        actual: ((SurchargeRatesGetResponseDto)((OkObjectResult)result).Value).SurchargeRates.Select(r => r.Name).ToList()
        //    );
        //}

        [Theory]
        [MemberData(nameof(SurchargeRateTestData.ValidSurchargeRates), MemberType = typeof(SurchargeRateTestData))]
        public async Task AddProductTypeSurchargeRates_ExpectedCreated(ProductTypeSurchargeRateRequestDto productTypeSurchargeRateRequestDto)
        {
            //we need async data structure for storing the product type and its surcharge rate
            var result = await _surchargeRateController.CreateProductTypeSurchareRate(productTypeSurchargeRateRequestDto);
            Assert.IsType<CreatedResult>(result);
        }

        //[Theory]
        //[MemberData(nameof(SurchargeRateTestData.TwoProductTypesWithThreeSurchargeRates), MemberType = typeof(SurchargeRateTestData))]
        //public async Task AddProductTypeSurchargeRatesSingleStep_ExpectedCreated(ProductTypeSurchargeRateRequestDto productTypeSurchargeRateRequestDto)
        //{
        //    //we need async data structure for storing the product type and its surcharge rate
        //    var result = await _surchargeRateController.AddProductTypeSurchargeRates(productTypeSurchargeRateRequestDto);
        //    Assert.IsType<CreatedResult>(result);
        //}
    }
}
