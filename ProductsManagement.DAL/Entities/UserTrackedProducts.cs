namespace ProductsManagement.DAL.Entities
{
    public class UserTrackedProducts
    {
        public string Userid { get; set; } = null!;
        public int Trackedproductsid { get; set; }
        public int? Rulesetid { get; set; }

        public virtual RuleSet? RuleSet { get; set; }
        public virtual TrackedProducts TrackedProduct { get; set; } = null!;
    }
}
