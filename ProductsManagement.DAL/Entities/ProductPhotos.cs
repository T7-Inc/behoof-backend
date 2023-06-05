namespace ProductsManagement.DAL.Entities
{
    public class ProductPhotos
    {
        public int Id { get; set; }
        public int TrackedProductsId { get; set; }
        public string PhotoUrl { get; set; } = null!;

        public virtual TrackedProducts? TrackedProduct { get; set; }
    }
}
