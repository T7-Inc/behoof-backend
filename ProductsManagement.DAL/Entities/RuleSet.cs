namespace ProductsManagement.DAL.Entities
{
    public class RuleSet
    {
        public RuleSet()
        {
            UserTrackedProducts = new HashSet<UserTrackedProducts>();
        }

        public int Id { get; set; }
        public double? Minvalue { get; set; }
        public double? Maxvalue { get; set; }
        public bool? Outstock { get; set; }
        public bool? Instock { get; set; }

        public ICollection<UserTrackedProducts> UserTrackedProducts { get; set; }
    }
}
