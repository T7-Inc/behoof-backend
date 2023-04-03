namespace ProductsManagement.DAL.Entities
{
    public class ProductPhotos
    {
        public int Id { get; set; }
        public int? Trackedproductsid { get; set; }
        public string Photourl { get; set; } = null!;

        public virtual TrackedProducts? TrackedProduct { get; set; }
    }
}
