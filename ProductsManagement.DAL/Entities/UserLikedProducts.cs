namespace ProductsManagement.DAL.Entities
{
    public class UserLikedProducts
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int ProductId { get; set; }

        public virtual TrackedProducts? Product { get; set; }
    }
}
