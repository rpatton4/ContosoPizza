using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data;

public class ContosoPizzaContext : DbContext {
  private string DbPath = "/Users/robertpatton/Repositories/Learning/sqlite_dbs/contoso_pizza.db";
  
  public DbSet<Customer> Customers { get; set; } = null!;

  public DbSet<Order> Orders { get; set; } = null!;

  public DbSet<Product> Products { get; set; } = null!;

  public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    optionsBuilder.UseSqlite($"Data Source={DbPath}");
  }
}