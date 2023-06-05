namespace ProductsManagement.DAL.Entities
{
    public class TrackedProducts
    {
        public TrackedProducts()
        {
            ProductOffers = new HashSet<ProductOffers>();
            ProductPhotos = new HashSet<ProductPhotos>();
            ProductPrices = new HashSet<ProductPrices>();
            ReviewProducts = new HashSet<ProductReviews>();
            UserLikedProducts = new HashSet<UserLikedProducts>();
            UserTrackedProducts = new HashSet<UserTrackedProducts>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Producturl { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double? Aproximateprofit { get; set; }
        public double Minprice { get; set; }
        public double Maxprice { get; set; }
        public double? Ratingbyreviews { get; set; }

        public virtual ICollection<ProductOffers> ProductOffers { get; set; }
        public virtual ICollection<ProductPhotos> ProductPhotos { get; set; }
        public virtual ICollection<ProductPrices> ProductPrices { get; set; }
        public virtual ICollection<ProductReviews> ReviewProducts { get; set; }
        public virtual ICollection<UserLikedProducts> UserLikedProducts { get; set; }
        public virtual ICollection<UserTrackedProducts> UserTrackedProducts { get; set; }
    }
}
