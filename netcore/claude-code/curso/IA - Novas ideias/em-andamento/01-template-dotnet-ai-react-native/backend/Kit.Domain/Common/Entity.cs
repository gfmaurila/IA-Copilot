namespace Kit.Domain.Common;

/// <summary>
/// Base class for every Domain Entity.
/// Identity is provided by <see cref="Id"/>; equality is identity-based, never
/// property-based, so two entities with the same data but different Ids are
/// different entities.
/// </summary>
public abstract class Entity
{
    protected Entity()
    {
    }

    protected Entity(Guid id) => Id = id;

    public Guid Id { get; protected set; }

    public DateTime CreatedAt { get; internal set; }

    public DateTime? UpdatedAt { get; internal set; }

    private long _version;

    /// <summary>
    /// Optimistic concurrency token, mapped by Infrastructure. Required to
    /// detect concurrent writes instead of silently overwriting them.
    /// </summary>
    public long Version => _version;

    internal void SetTimestamps(DateTime now)
    {
        if (CreatedAt == default)
        {
            CreatedAt = now;
        }
        else
        {
            UpdatedAt = now;
        }
    }

    internal void IncrementVersion() => _version++;

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (GetType() != other.GetType())
        {
            return false;
        }

        return Id != Guid.Empty && Id == other.Id;
    }

    public override int GetHashCode() => HashCode.Combine(GetType().Name, Id);

    public static bool operator ==(Entity? left, Entity? right) => Equals(left, right);

    public static bool operator !=(Entity? left, Entity? right) => !Equals(left, right);
}