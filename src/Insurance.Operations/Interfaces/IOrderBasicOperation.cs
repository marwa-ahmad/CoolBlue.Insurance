using Insurance.Domain;

namespace Insurance.Operations
{
    public interface IOrderBasicOperation
    {
        float Calculate(IOrder order);
    }
}
