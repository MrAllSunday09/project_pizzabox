using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizza;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Storing
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;

    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Size> Sizes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<Dominos>().HasBaseType<AStore>();
      builder.Entity<PizzaHut>().HasBaseType<AStore>();

      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<BuildYourOwn>().HasBaseType<APizza>();
      builder.Entity<MeatLovers>().HasBaseType<APizza>();
      builder.Entity<VeggiePizza>().HasBaseType<APizza>();

      builder.Entity<Crust>().HasKey(e => e.EntityId);
      builder.Entity<Order>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasKey(e => e.EntityId);
      builder.Entity<Toppings>().HasKey(e => e.EntityId);

      builder.Entity<Customer>().HasKey(e => e.EntityId);

      // builder.Entity<Size>().HasMany<APizza>().WithOne(); // orm is creating the has
      // builder.Entity<APizza>().HasOne<Size>().WithMany();

      builder.Entity<AStore>().HasMany<Order>(s => s.Orders).WithOne(o => o.Store);
      builder.Entity<Customer>().HasMany<Order>().WithOne(o => o.Customers);
      builder.Entity<APizza>().HasMany<Order>().WithOne(o => o.Pizza);
      builder.Entity<Order>().HasOne<AStore>(o => o.Store).WithMany(s => s.Orders);

      OnDataSeeding(builder);
    }

      private void OnDataSeeding(ModelBuilder builder)
      {
        builder.Entity<Dominos>().HasData(new Dominos[]
      {
        new Dominos() { EntityId = 1, Name = "Chitown Main Street" }
      });

      builder.Entity<PizzaHut>().HasData(new PizzaHut[]
      {
        new PizzaHut() { EntityId = 2, Name = "Big Apple" }
      });

      builder.Entity<Customer>().HasData(new Customer[]
      {
        new Customer() { EntityId = 1, Name = "Uncle John" }
      });
      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { EntityId = 1, Name = "Medium" }
      });
      builder.Entity<BuildYourOwn>().HasData(new Size[]
      {
        new Size() { EntityId = 1, Name = "Medium" }
      });
      builder.Entity<MeatLovers>().HasData(new Size[]
      {
        new Size() { EntityId = 1, Name = "Medium" }
      });
      builder.Entity<VeggiePizza>().HasData(new Size[]
      {
        new Size() { EntityId = 1, Name = "Medium" }
      });
    }
  }
}