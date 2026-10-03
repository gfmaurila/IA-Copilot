using Kit.Domain.Common;

namespace Kit.Domain.Modules.Identity;

/// <summary>
/// Team is an Entity inside the Organization Aggregate. It is always reached
/// through the Organization, never directly through a repository.
/// </summary>
public sealed class Team : Entity
{
    private Team()
    {
    }

    private Team(Guid id, Guid organizationId, string name, string? description)
    {
        Id = id;
        OrganizationId = organizationId;
        Name = name;
        Description = description;
    }

    public Guid OrganizationId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public TeamStatus Status { get; private set; } = TeamStatus.Active;

    internal static Result<Team> Create(Guid organizationId, string name, string? description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Team>(Error.Validation("team.name.required", "Nome do time é obrigatório."));
        }

        if (organizationId == Guid.Empty)
        {
            return Result.Failure<Team>(Error.Validation("team.organization.required", "Time deve pertencer a uma organização."));
        }

        return Result.Success(new Team(Guid.NewGuid(), organizationId, name.Trim(), description?.Trim()));
    }

    internal Result Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure(Error.Validation("team.name.required", "Nome do time é obrigatório."));
        }

        Name = name.Trim();
        return Result.Success();
    }

    internal Result ChangeStatus(TeamStatus status)
    {
        if (Status == status)
        {
            return Result.Failure(Error.Conflict("team.status.unchanged", "O time já está neste status."));
        }

        Status = status;
        return Result.Success();
    }
}