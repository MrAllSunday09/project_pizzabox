using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizza;

namespace PizzaBox.Storing
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;

    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizza { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

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
      builder.Entity<AStore>().HasMany<Order>(s => s.Orders).WithOne(o => o.Store);
      builder.Entity<Dominos>().HasBaseType<AStore>();
      builder.Entity<PizzaHut>().HasBaseType<AStore>();

      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<APizza>().HasMany<Toppings>();
      builder.Entity<APizza>().HasMany<Order>().WithMany(o => o.Pizza);
      builder.Entity<BuildYourOwn>().HasBaseType<APizza>();
      builder.Entity<MeatLovers>().HasBaseType<APizza>();
      builder.Entity<VeggiePizza>().HasBaseType<APizza>();

      builder.Entity<Crust>().HasKey(e => e.EntityId);
      builder.Entity<Order>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasMany<APizza>().WithOne(p => p.Size);
      builder.Entity<Toppings>().HasKey(e => e.EntityId);

      builder.Entity<Customer>().HasKey(e => e.EntityId);
      builder.Entity<Customer>().HasMany<Order>().WithOne(o => o.Customer);

      builder.Entity<Dominos>().HasData(new Dominos[]
      {
        new Dominos() { EntityId = 1, Name = "Pizza Inn" }
      });
      builder.Entity<PizzaHut>().HasData(new PizzaHut[]
      {
        new PizzaHut() { EntityId = 2, Name = "Marco's " }
      });
      builder.Entity<Customer>().HasData(new Customer[]
      {
        new Customer() { EntityId = 1, Name = "Uncle Sam" }
      });
    }
  }
}