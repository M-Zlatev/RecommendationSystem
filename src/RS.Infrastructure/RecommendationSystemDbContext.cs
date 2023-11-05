namespace RS.Infrastructure;

#region Usings
using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Domain;
using Microsoft.Extensions.Configuration;
#endregion

public class RecommendationSystemDbContext : DbContext
{
    public RecommendationSystemDbContext(DbContextOptions<RecommendationSystemDbContext> options)
    : base(options)
    {
    }

    public DbSet<Apartment> Apartaments { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Floor> Floors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Applies configurations from RS.Infrastructure.Configurations via reflection.
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
