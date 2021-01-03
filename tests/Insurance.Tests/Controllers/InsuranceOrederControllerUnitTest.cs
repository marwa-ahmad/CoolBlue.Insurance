using Insurance.Api.Controllers;
using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Insurance.Domain;

namespace Insurance.Tests.Controllers
{
    public class OrederInsuranceControllerUnitTest : IClassFixture<SetupTestFixture>
    {
        private readonly IServiceProvider _serviceProvider;
        private OrderInsuranceController _orderInsuranceController;

        public OrederInsuranceControllerUnitTest(SetupTestFixture setuptestFixture)
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
                actual: ((OrderInsuranceResponseDto)((OkObjectResult)result).Value).TotalInsuranceValue
            );
        }

        [Theory]
        [MemberData(nameof(OrderInsuranceTestData.ProductsPriceBetween500And2000), MemberType = typeof(OrderInsuranceTestData))]
        public async Task GetOrderInsurance_ProductsPriceBetween500And2000_ExpectedInsuranceEach1500Euros(OrderInsuranceRequestDto request, float expectedOrderInsuranceValue)
        {
            var result = await _orderInsuranceController.GetOrderInsuranceAsync(request);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(
                expected: expectedOrderInsuranceValue,
                actual: ((OrderInsuranceResponseDto)((OkObjectResult)result).Value).TotalInsuranceValue
            );
        }

        [Theory]
        [MemberData(nameof(OrderInsuranceTestData.ProductsPriceAbove2000), MemberType = typeof(OrderInsuranceTestData))]
        public async Task GetOrderInsurance_ProductsPriceAbove2000_ExpectedInsuranceEach2500Euros(OrderInsuranceRequestDto request, float expectedOrderInsuranceValue)
        {
            var result = await _orderInsuranceController.GetOrderInsuranceAsync(request);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(
                expected: expectedOrderInsuranceValue,
                actual: ((OrderInsuranceResponseDto)((OkObjectResult)result).Value).TotalInsuranceValue
            );
        }
    }
}
