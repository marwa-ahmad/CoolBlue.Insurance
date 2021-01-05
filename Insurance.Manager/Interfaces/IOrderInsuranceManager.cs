using Insurance.Domain;

namespace Insurance.Manager
{
    public interface IOrderInsuranceManager
    {
        float CalculateInsurance(IOrder order);
    }
}