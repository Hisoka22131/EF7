using EF7;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Supplier> Supplier { get; set; } = null!;
    public DbSet<Customer> Customer { get; set; } = null!;
    public DbSet<Order> Order { get; set; } = null!;
    public DbSet<Product> Product { get; set; } = null!;
    public DbSet<OrderItem> OrderItem { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        dbContextOptionsBuilder.UseSqlServer(@"Server=.\;Database=SalesDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
    }
}

