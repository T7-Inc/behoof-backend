namespace ProductsManagement.DAL.Entities
{
    public class ProductReviews
    {
        public int Id { get; set; }
        public int TrackedProductsId { get; set; }
        public string? ReviewContent { get; set; }
        public string Username { get; set; } = null!;
        public string? UserPhoto { get; set; }
        public double Rating { get; set; }

        public virtual TrackedProducts? TrackedProduct { get; set; }
    }
}
