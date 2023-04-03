namespace ProductsManagement.DAL.Entities
{
    public class ProductReviews
    {
        public int Id { get; set; }
        public int? Trackedproductsid { get; set; }
        public string? Reviewcontent { get; set; }
        public string Username { get; set; } = null!;
        public string? Userphoto { get; set; }
        public double Rating { get; set; }

        public virtual TrackedProducts? TrackedProduct { get; set; }
    }
}
