namespace Insurance.Domain
{
    public class Product : IProduct
    {
        public ProductType ProductType { get; set; }
        public int Id { get; set; }
        public float SalesPrice { get; set; }
        public bool IsInsured { get; set; }
    }
}
