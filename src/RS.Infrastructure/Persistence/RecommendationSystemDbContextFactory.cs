namespace RS.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class RecommendationSystemDbContextFactory : IDesignTimeDbContextFactory<RecommendationSystemDbContext>
{
    public RecommendationSystemDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RecommendationSystemDbContext>();
        optionsBuilder.UseSqlServer(@"Server=.;Database=RecommendationSystem;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");

        return new RecommendationSystemDbContext(optionsBuilder.Options);
    }
}
