namespace Insurance.Operations
{
    public class BasicInsuranceOperation : IBasicInsuranceOperation
    {
        public float Calculate(float salesPrice)
        {
            float insuranceValue = 0;

            switch (salesPrice)
            {
                case float n when n < 500:
                    insuranceValue = 0;
                    break;

                case float n when n >= 500 && n < 2000:
                    insuranceValue = 1000;
                    break;

                case float n when n >= 2000:
                    insuranceValue = 2000;
                    break;

                default:
                    break;
            }

            return insuranceValue;
        }
    }
}
