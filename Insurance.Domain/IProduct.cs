namespace Insurance.Domain
{
    public interface IProduct
    {
        ProductType ProductType { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        float SalesPrice { get; set; }
        bool IsInsured { get; set; }
    }
}
