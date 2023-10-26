namespace RS.Infrastructure;

#region Usings
using Microsoft.EntityFrameworkCore;

using Domain;
using Microsoft.EntityFrameworkCore.Design;
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

    public class RecommendationSystemDbContextFactory : IDesignTimeDbContextFactory<RecommendationSystemDbContext>
    {
        public RecommendationSystemDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecommendationSystemDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.;Database=RecommendationSystem;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");

            return new RecommendationSystemDbContext(optionsBuilder.Options);
        }
    }
}
