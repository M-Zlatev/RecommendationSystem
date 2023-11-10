namespace RS.Infrastructure;

#region Usings
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Data.SqlClient;

using Application.Data;
using Domain;
using Domain.Seedwork;
using Domain.Seedwork.Utilities;
#endregion

public class RecommendationSystemDbContext : DbContext, IDbContext, IUnitOfWork
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

    public new DbSet<TEntity> DbSet<TEntity>()
        where TEntity : Entity
        => base.Set<TEntity>();

    public async Task<Maybe<TEntity>> GetBydIdAsync<TEntity>(Guid id)
        where TEntity : Entity
        => id == Guid.Empty ?
            Maybe<TEntity>.None :
            Maybe<TEntity>.From(await DbSet<TEntity>().FirstOrDefaultAsync(e => e.Id == id));

    public void Insert<TEntity>(TEntity entity)
        where TEntity : Entity
        => DbSet<TEntity>().Add(entity);

    public void InsertRange<TEntity>(IReadOnlyCollection<TEntity> entities)
        where TEntity : Entity
        => DbSet<TEntity>().AddRange(entities);

    public new void Remove<TEntity>(TEntity entity)
        where TEntity : Entity
        => DbSet<TEntity>().Remove(entity);


    public Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters, CancellationToken cancellationToken = default)
        => Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
         => Database.BeginTransactionAsync(cancellationToken);


    #endregion
}
