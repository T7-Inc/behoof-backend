namespace ProductsManagement.DAL.Entities
{
    public class ProductOffers
    {
        public int Id { get; set; }
        public int? Productid { get; set; }
        public string Shop { get; set; } = null!;
        public string Offerurl { get; set; } = null!;
        public double Price { get; set; }
        public bool Instock { get; set; }
        public double? Shippingcost { get; set; }

        public virtual TrackedProducts? Product { get; set; }
    }
}
