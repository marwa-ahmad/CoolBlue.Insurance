using Insurance.Domain;

namespace Insurance.Operations
{
    public interface ICameraOrderInsuranceOperation
    {
        float Calculate(IOrder order);
    }
}
