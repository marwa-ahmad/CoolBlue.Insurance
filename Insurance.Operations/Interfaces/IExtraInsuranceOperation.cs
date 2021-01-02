using Insurance.Domain;

namespace Insurance.Operations
{
    public interface IExtraInsuranceOperation
    {
        float Calculate(ProductType productType, float insuranceValue);
    }
}
