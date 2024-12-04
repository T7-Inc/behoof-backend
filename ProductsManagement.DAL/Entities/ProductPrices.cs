namespace ProductsManagement.DAL.Entities
{
    public class ProductPrices
    {
        public int Id { get; set; }
        public int TrackedProductsId { get; set; }
        public double Price { get; set; }
        public DateTime Created { get; set; }

        public virtual TrackedProducts? TrackedProduct { get; set; }
    }
}