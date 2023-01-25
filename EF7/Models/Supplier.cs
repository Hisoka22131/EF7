namespace EF7.Models
{
    public class Supplier : EntityBase
    {
        public override int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public virtual IList<Product> Products { get; set; } = new List<Product>();
    }
}
