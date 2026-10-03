using Kit.Domain.Common;

namespace Kit.Domain.Modules.Audit;

public enum AuditAction
{
    Create = 1,
    Update = 2,
    Delete = 3,
    Login = 4,
    Logout = 5,
    Publish = 6,
    Execute = 7,
    Approve = 8,
    Reject = 9,
    Access = 10,
    Denied = 11
}

public enum AuditOutcome
{
    Success = 1,
    Failure = 2,
    Denied = 3,
    PendingApproval = 4
}

/// <summary>
/// AuditEntry is an immutable append-only record of a security-relevant action.
/// It is intentionally NOT an Aggregate Root with editable state: once written it
/// can only be appended to, which is what makes the trail trustworthy.
/// </summary>
public sealed class AuditEntry : Entity
{
    private AuditEntry()
    {
    }

    private AuditEntry(
        Guid id,
        string module,
        string resource,
        string resourceId,
        AuditAction action,
        AuditOutcome outcome,
        Guid? actorId,
        string? actorEmail,
        Guid? organizationId,
        string? correlationId,
        string? ipAddress,
        string detailsJson,
        DateTime occurredAtUtc)
    {
        Id = id;
        Module = module;
        Resource = resource;
        ResourceId = resourceId;
        Action = action;
        Outcome = outcome;
        ActorId = actorId;
        ActorEmail = actorEmail;
        OrganizationId = organizationId;
        CorrelationId = correlationId;
        IpAddress = ipAddress;
        DetailsJson = detailsJson;
        OccurredAtUtc = occurredAtUtc;
    }

    public string Module { get; private set; } = string.Empty;

    public string Resource { get; private set; } = string.Empty;

    public string ResourceId { get; private set; } = string.Empty;

    public AuditAction Action { get; private set; }

    public AuditOutcome Outcome { get; private set; }

    public Guid? ActorId { get; private set; }

    public string? ActorEmail { get; private set; }

    public Guid? OrganizationId { get; private set; }

    public string? CorrelationId { get; private set; }

    public string? IpAddress { get; private set; }

    /// <summary>
    /// Serialized payload. MUST NOT contain secrets or raw PII beyond what the
    /// audit policy explicitly allows.
    /// </summary>
    public string DetailsJson { get; private set; } = "{}";

    public DateTime OccurredAtUtc { get; private set; }

    public static Result<AuditEntry> Create(
        string module,
        string resource,
        string resourceId,
        AuditAction action,
        AuditOutcome outcome,
        Guid? actorId,
        string? actorEmail,
        Guid? organizationId,
        string? correlationId,
        string? ipAddress,
        string? detailsJson,
        DateTime occurredAtUtc)
    {
        if (string.IsNullOrWhiteSpace(module))
        {
            return Result.Failure<AuditEntry>(Error.Validation("audit.module.required", "Módulo é obrigatório no registro de auditoria."));
        }

        if (string.IsNullOrWhiteSpace(resource))
        {
            return Result.Failure<AuditEntry>(Error.Validation("audit.resource.required", "Recurso é obrigatório no registro de auditoria."));
        }

        return Result.Success(new AuditEntry(
            Guid.NewGuid(),
            module.Trim(),
            resource.Trim(),
            resourceId ?? string.Empty,
            action,
            outcome,
            actorId,
            actorEmail,
            organizationId,
            correlationId,
            ipAddress,
            detailsJson ?? "{}",
            occurredAtUtc));
    }

    /// <summary>Only for seeders, so Demo data can place entries in the past.</summary>
    public static AuditEntry CreateSeeded(
        string module,
        string resource,
        string resourceId,
        AuditAction action,
        AuditOutcome outcome,
        Guid? actorId,
        string? actorEmail,
        Guid? organizationId,
        string? correlationId,
        DateTime occurredAtUtc)
        => new(
            Guid.NewGuid(),
            module,
            resource,
            resourceId,
            action,
            outcome,
            actorId,
            actorEmail,
            organizationId,
            correlationId,
            "127.0.0.1",
            "{}",
            occurredAtUtc);
}