namespace RS.Infrastructure;

#region Usings
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

using Application.Data;
using Domain;
using Domain.Core.Utilities;
using Domain.Core;
#endregion

public class RecommendationSystemDbContext : DbContext, IDbContext
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

    #region IDbContext implementations

    /// <inheritdoc />
    public new DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity
        => base.Set<TEntity>();

    public Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Maybe<TEntity>> GetBydIdAsync<TEntity>(Guid id) where TEntity : Entity
    {
        throw new NotImplementedException();
    }

    public void Insert<TEntity>(TEntity entity) where TEntity : Entity
    {
        throw new NotImplementedException();
    }

    public void InsertRange<TEntity>(IReadOnlyCollection<TEntity> entities) where TEntity : Entity
    {
        throw new NotImplementedException();
    }

    void IDbContext.Remove<TEntity>(TEntity entity)
    {
        throw new NotImplementedException();
    }

    #endregion
}
