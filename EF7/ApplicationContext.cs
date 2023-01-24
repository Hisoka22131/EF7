using EF7;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class ApplicationContext : DbContext
{
    public DbSet<Supplier> Supplier { get; set; } = null!;
    public DbSet<Customer> Customer { get; set; } = null!;
    public DbSet<Order> Order { get; set; } = null!;
    public DbSet<Product> Product { get; set; } = null!;
    public DbSet<OrderItem> OrderItem { get; set; } = null!;

    public ApplicationContext()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
        //Order.ToList();
        //Customer.ToList();
        //OrderItem.ToList();
        //Product.ToList();
        //Supplier.ToList();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        dbContextOptionsBuilder.UseSqlServer(@"Server=.\;Database=SalesDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Order>()
            .HasOne(q => q.Customer)
            .WithMany(q => q.Orders)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<OrderItem>()
            .HasOne(q => q.Order)
            .WithMany(q => q.OrderItems)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<OrderItem>()
            .HasOne(q => q.Product)
            .WithMany(q => q.OrderItems)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Product>()
            .HasOne(q => q.Supplier)
            .WithMany(q => q.Products)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

