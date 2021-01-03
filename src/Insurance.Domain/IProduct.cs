namespace Insurance.Domain
{
    public interface IProduct
    {
        ProductType ProductType { get; set; }
        int Id { get; set; }
        float SalesPrice { get; set; }
        bool IsInsured { get; set; }
    }
}
