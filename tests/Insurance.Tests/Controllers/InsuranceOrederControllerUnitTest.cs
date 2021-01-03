using Insurance.Api.Controllers;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance.Tests.Controllers
{
    public class InsuranceOrederControllerUnitTest : IClassFixture<SetupTestFixture>
    {
        private readonly IServiceProvider _serviceProvider;
        private OrderInsuranceController _orderInsuranceController;

        public InsuranceOrederControllerUnitTest(SetupTestFixture setuptestFixture)
        {
            _serviceProvider = setuptestFixture.ServiceProvider;

            _orderInsuranceController = _serviceProvider.GetService<OrderInsuranceController>();
        }


        [Theory]
        [MemberData(nameof(OrderInsuranceTestData.ProductsPriceBelow500), MemberType = typeof(OrderInsuranceTestData))]
        public async Task GetOrderInsurance_ProductsPriceBelow500_ExpectedInsuranceEach500Euros(OrderInsuranceRequestDto request, float expectedOrderInsuranceValue)
        {
            var result = await _orderInsuranceController.GetOrderInsuranceAsync(request);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(
                expected: expectedOrderInsuranceValue,
                actual: ((OrderInsuranceResponseDto)((OkObjectResult)result).Value).InsuranceValue
            );
        }

    }
}
