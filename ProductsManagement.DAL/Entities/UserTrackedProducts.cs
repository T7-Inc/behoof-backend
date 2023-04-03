namespace ProductsManagement.DAL.Entities
{
    public class UserTrackedProducts
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int TrackedproductsId { get; set; }
        public int? RulesetId { get; set; }

        public virtual RuleSet? RuleSet { get; set; }
        public virtual TrackedProducts TrackedProduct { get; set; } = null!;
    }
}
