namespace ProductsManagement.DAL.Entities
{
    public class ProductOffers
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double? ShippingCost { get; set; }
        public string Shop { get; set; } = null!;
        public string OfferUrl { get; set; } = null!;
        public double Price { get; set; }
        public bool Instock { get; set; }

        public virtual TrackedProducts? Product { get; set; }
    }
}
