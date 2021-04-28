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
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<Toppings> Toppings { get; set; }

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
      builder.Entity<APizza>().HasMany<Toppings>().WithOne();
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
        new Customer() { EntityId = 1, Name = "Daniel Henderson" },
        new Customer() { EntityId = 2, Name = "Fred Belotte" },
        new Customer() { EntityId = 3, Name = "Azhya Knox" }
      });
      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust() { EntityId = 1, Name = "Thin", Price = 3 },
        new Crust() { EntityId = 2, Name = "Original", Price = 5 },
        new Crust() { EntityId = 3, Name = "Brooklyn", Price = 7 },
        new Crust() { EntityId = 7, Name = "Stuffed", Price = 10},
      });
      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { EntityId = 1, Name = "Small", Price = 3 },
        new Size() { EntityId = 2, Name = "Medium", Price = 5 },
        new Size() { EntityId = 3, Name = "Large", Price = 7 },
        new Size() { EntityId = 7, Name = "X-Large", Price = 12 }
      });
      builder.Entity<Toppings>().HasData(new Toppings[]
      {
        new Toppings() { EntityId = 1, Name = "Bacon", Price = 1 },
        new Toppings() { EntityId = 2, Name = "Sausage", Price = 1 },
        new Toppings() { EntityId = 3, Name = "Chicken", Price = 1 },
        new Toppings() { EntityId = 4, Name = "Spinach", Price = 1 },
        new Toppings() { EntityId = 5, Name = "Peppers", Price = 1 },
        new Toppings() { EntityId = 6, Name = "Pepperoni", Price = 1 },
        new Toppings() { EntityId = 7, Name = "Ham", Price = 1 },
        new Toppings() { EntityId = 8, Name = "Pineapple", Price = 1 },
        new Toppings() { EntityId = 9, Name = "Mushrooms", Price = 1 },
        new Toppings() { EntityId = 10, Name = "Onion", Price = 1 }
      });
      builder.Entity<BuildYourOwn>().HasData(new BuildYourOwn[]
      {
        new BuildYourOwn() { EntityId = 1, SizeEntityId = 1, CrustEntityId = 1 }
      });
      builder.Entity<MeatLovers>().HasData(new MeatLovers[]
      {
        new MeatLovers() { EntityId = 2, SizeEntityId = 2, CrustEntityId = 2 }
      });
      builder.Entity<VeggiePizza>().HasData(new VeggiePizza[]
      {
        new VeggiePizza() { EntityId = 3, SizeEntityId = 3, CrustEntityId = 3 }
      });
    }
  }
}