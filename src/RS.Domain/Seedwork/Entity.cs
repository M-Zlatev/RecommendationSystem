namespace RS.Domain.Seedwork;

using Events;

/// <summary>
/// Represents the base class that all entities derive from.
/// </summary>
public abstract class Entity : IEquatable<Entity>, IHasDomainEvents
{

    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    /// <param name="id">The entity identifier.</param>
    protected Entity(Guid id)
        :this()
    {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    protected Entity()
    {
    }

    /// <summary>
    /// Gets or sets the entity identifier.
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Gets the domain events. This collection is readonly.
    /// </summary>
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public static bool operator ==(Entity left, Entity right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return Equals(left, right);
    }

    public static bool operator !=(Entity left, Entity right) => !(left == right);


    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        return Equals((object?)other);
    }

    public override bool Equals(object obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Entity other)
        {
            return false;
        }

        return Id == other.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();

    /// <summary>
    /// Adds the specified <see cref="IDomainEvent"/> to the <see cref="Entity"/>.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Clears all the domain events from the <see cref="Entity"/>.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}
