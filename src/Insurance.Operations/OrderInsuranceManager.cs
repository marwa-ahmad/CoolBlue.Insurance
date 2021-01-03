using Insurance.Common;
using Insurance.Domain;
using Newtonsoft.Json;
using System;

namespace Insurance.Operations
{
    public class OrderInsuranceManager: IOrderInsuranceManager
    {
        private readonly IOrderBasicOperation _orderBasicOperation;
        private readonly ICameraOrderInsuranceOperation _cameraOrderInsuranceOperation;
        private readonly ILogger _logger;

        public OrderInsuranceManager(ICameraOrderInsuranceOperation cameraInsuranceOperation, IOrderBasicOperation orderBasicOperation, ILogger logger)
        {
            _cameraOrderInsuranceOperation = cameraInsuranceOperation;
            _orderBasicOperation = orderBasicOperation;
            _logger = logger;
        }

        public float CalculateInsurance(IOrder order)
        {
            var basicOrderInsuranceValue = _orderBasicOperation.Calculate(order);

            var camerasInsuranceValue = _cameraOrderInsuranceOperation.Calculate(order);
            
            var serializedObject = JsonConvert.SerializeObject(order);

            _logger.LogInformation($"Order initial insurance value [{basicOrderInsuranceValue}]. " +
                $"Order cameras insurance value {camerasInsuranceValue}{Environment.NewLine}" 
                + $" order json object: [{serializedObject}]");

            return basicOrderInsuranceValue + camerasInsuranceValue;
        }
    }
}
