namespace ProductsManagement.DAL.Entities
{
    public class UserLikedProducts
    {
        public string Userid { get; set; } = null!;
        public int? Productid { get; set; }

        public virtual TrackedProducts? Product { get; set; }
    }
}
