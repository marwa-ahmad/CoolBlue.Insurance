using Insurance.Domain;

namespace Insurance.Operations
{
    public interface IOrderInsuranceManager
    {
        float CalculateInsurance(IOrder order);
    }
}