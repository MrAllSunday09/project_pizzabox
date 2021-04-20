using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using Microsoft.Extensions.Configuration;

namespace PizzaBox.Storing
{
    
  public class PizzaBoxContext : DbContext
  {

    private readonly IConfiguration _configuration;

    public DbSet<AStore> Stores { get; set; }

    public DbSet<APizza> Pizza { get; set; }

    public PizzaBoxContext()
    {

    }

    public PizzaBoxContext(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }

    protected override void OnModelCreating(ModelBuilder mbuilder)
    {
      mbuilder.Entity<AStore>().HasKey(e => e.EntityId);
      mbuilder.Entity<APizza>().HasKey(e => e.EntityId);
    }
  }
}