namespace RS.Domain.Seedwork;

using Events;

/// <summary>
/// Represents the aggregate root.
/// </summary>
public abstract class AggregateRoot<TId> : Entity<TId> 
    where TId : ValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
    /// </summary>
    /// <param name="id">The aggregate root identifier.</param>
    protected AggregateRoot(TId id)
        : base(id)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    protected AggregateRoot()
    {
    }
}
