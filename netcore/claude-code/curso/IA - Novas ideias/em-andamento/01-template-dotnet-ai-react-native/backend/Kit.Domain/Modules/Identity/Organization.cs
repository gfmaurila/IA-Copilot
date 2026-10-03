using Kit.Domain.Common;

namespace Kit.Domain.Modules.Identity;

public sealed class Organization : AggregateRoot
{
    private readonly List<Team> _teams = [];

    private Organization()
    {
    }

    private Organization(Guid id, string name, string slug, string? description, OrganizationStatus status)
    {
        Id = id;
        Name = name;
        Slug = slug;
        Description = description;
        Status = status;
    }

    public string Name { get; private set; } = string.Empty;

    public string Slug { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public OrganizationStatus Status { get; private set; }

    public bool IsDefault { get; private set; }

    public IReadOnlyCollection<Team> Teams => _teams.AsReadOnly();

    public static Result<Organization> Create(string name, string? slug = null, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Organization>(Error.Validation("organization.name.required", "Nome da organização é obrigatório."));
        }

        var slugResult = Common.Slug.Create(slug ?? name);
        if (slugResult.IsFailure)
        {
            return Result.Failure<Organization>(slugResult.Error);
        }

        var organization = new Organization(
            Guid.NewGuid(),
            name.Trim(),
            slugResult.Value.Value,
            description?.Trim(),
            OrganizationStatus.Active);

        organization.RaiseDomainEvent(new OrganizationCreatedEvent(organization.Id, organization.Name));
        return Result.Success(organization);
    }

    public Result AddTeam(string name, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure(Error.Validation("team.name.required", "Nome do time é obrigatório."));
        }

        if (_teams.Any(t => string.Equals(t.Name, name.Trim(), StringComparison.OrdinalIgnoreCase)))
        {
            return Result.Failure(Error.Conflict("team.name.duplicated", $"Já existe um time chamado '{name}'."));
        }

        var team = Team.Create(Id, name, description);
        _teams.Add(team.Value);
        RaiseDomainEvent(new TeamAddedEvent(Id, team.Value.Id, team.Value.Name));
        return Result.Success();
    }

    public Result ChangeStatus(OrganizationStatus status)
    {
        if (Status == status)
        {
            return Result.Failure(Error.Conflict("organization.status.unchanged", "A organização já está neste status."));
        }

        Status = status;
        RaiseDomainEvent(new OrganizationStatusChangedEvent(Id, status));
        return Result.Success();
    }

    public Result UpdateProfile(string? name, string? description)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            Name = name.Trim();
        }

        Description = description?.Trim();
        return Result.Success();
    }

    /// <summary>
    /// Marks this Organization as the default tenant target.
    /// Seeders only: exactly one Organization may be the default, and the rule is
    /// enforced by the seeder, never by an endpoint.
    /// </summary>
    public void MarkAsDefault() => IsDefault = true;
}

public sealed record OrganizationCreatedEvent(Guid OrganizationId, string Name) : DomainEventBase(OrganizationId)
{
    public override string EventName => "identity.organization.created";
}

public sealed record OrganizationStatusChangedEvent(Guid OrganizationId, OrganizationStatus Status) : DomainEventBase(OrganizationId)
{
    public override string EventName => "identity.organization.status-changed";
}

public sealed record TeamAddedEvent(Guid OrganizationId, Guid TeamId, string TeamName) : DomainEventBase(OrganizationId)
{
    public override string EventName => "identity.team.added";
}