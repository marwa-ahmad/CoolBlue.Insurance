using Insurance.Domain;

namespace Insurance.Operations
{
    public interface IProductInsuranceManager
    {
        float CalculateInsurance(IProduct product);
    }
}