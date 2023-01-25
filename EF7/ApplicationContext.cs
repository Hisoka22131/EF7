using EF7.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class ApplicationContext : DbContext
{
    private static string connectionString = @"Server=.\;Database=SalesDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";
    public DbSet<Supplier> Supplier { get; set; } = null!;
    public DbSet<Customer> Customer { get; set; } = null!;
    public DbSet<Order> Order { get; set; } = null!;
    public DbSet<Product> Product { get; set; } = null!;
    public DbSet<OrderItem> OrderItem { get; set; } = null!;

    public ApplicationContext()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    /// <summary>
    /// Коннект к БД
    /// </summary>
    /// <param name="dbContextOptionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        // Используем если в дальнейшем будем выгружать данные через явную загрузку(Придётся много кода писать)
        //dbContextOptionsBuilder.UseSqlServer(connectionString);
        dbContextOptionsBuilder.UseLazyLoadingProxies()
        .UseSqlServer(connectionString);
    }

    /// <summary>
    /// Настройка контекста
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настраиваем запрет на каскадное удаление
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

        // Настраиваем автоматическую безотложную загрузку данных(Придется постоянно прописывать сюда навигации, поэтому сейчас использую Lazy, т к БД не большая и больших запросов не будет)
        //modelBuilder.Entity<Customer>().Navigation(q => q.Orders).AutoInclude();
        //modelBuilder.Entity<Order>().Navigation(q => q.Customer).AutoInclude();
        //modelBuilder.Entity<OrderItem>().Navigation(q => q.Product).AutoInclude();
        //modelBuilder.Entity<OrderItem>().Navigation(q => q.Order).AutoInclude();
        //modelBuilder.Entity<Product>().Navigation(q => q.OrderItems).AutoInclude();
        //modelBuilder.Entity<Supplier>().Navigation(q => q.Products).AutoInclude();
    }
}

