using Insurance.Domain;

namespace Insurance.Operations
{
    public class ExtraInsuranceOperation : IExtraInsuranceOperation
    {
        public float Calculate(ProductType productType, float insuranceValue)
        {
            var totalInsurance = insuranceValue;
            float extraInsurance = 500;

            switch (productType)
            {
                case ProductType.Laptop:
                    totalInsurance += extraInsurance;
                    break;

                case ProductType.SmartPhone:
                    totalInsurance += extraInsurance;
                    break;

                default:
                    break;
            }

            return totalInsurance;
        }
    }
}
