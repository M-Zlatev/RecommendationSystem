namespace RS.Infrastructure.Persistence;

using System.Reflection;
using Microsoft.EntityFrameworkCore;

using Domain;
using RS.Domain.Entities.Apartment;

public class RecommendationSystemDbContext : DbContext
{
    public RecommendationSystemDbContext(DbContextOptions<RecommendationSystemDbContext> options)
    : base(options)
    {
    }

    public DbSet<Apartment> Apartments { get; set; }

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
