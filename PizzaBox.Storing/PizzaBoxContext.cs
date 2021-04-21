using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace PizzaBox.Storing
{
    
  public class PizzaBoxContext : DbContext
  {

    private readonly IConfiguration _configuration;

    // public DbSet<AStore> Stores { get; set; }

    // public DbSet<APizza> Pizza { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }

    protected override void OnModelCreating(ModelBuilder mbuilder)
    {
      // mbuilder.Entity<AStore>().HasKey(e => e.EntityId);
      // mbuilder.Entity<APizza>().HasKey(e => e.EntityId);
      // mbuilder.Entity<Crust>().HasKey(e => e.EntityId);
      mbuilder.Entity<Customer>().HasKey(e => e.EntityId);
      // mbuilder.Entity<Order>().HasKey(e => e.EntityId);
      // mbuilder.Entity<Size>().HasKey(e => e.EntityId);
      // mbuilder.Entity<Toppings>().HasKey(e => e.EntityId);
    }
  }
}