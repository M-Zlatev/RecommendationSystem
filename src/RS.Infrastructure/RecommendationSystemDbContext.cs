namespace RS.Infrastructure;

#region Usings
using Microsoft.EntityFrameworkCore;

using Domain;
#endregion

public class RecommendationSystemDbContext : DbContext
{
    public RecommendationSystemDbContext(DbContextOptions<RecommendationSystemDbContext> options)
    : base(options)
    {
    }

    public DbSet<Apartament> Apartaments { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Floor> Floors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
