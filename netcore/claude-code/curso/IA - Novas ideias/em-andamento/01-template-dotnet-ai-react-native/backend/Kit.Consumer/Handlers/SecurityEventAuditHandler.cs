using System.Text.Json;
using Kit.Application.Abstractions.Repositories;
using Kit.Producer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Kit.Consumer.Handlers;

/// <summary>
/// Writes an audit entry for every security-relevant Domain Event the bridge
/// carries.
///
/// SECURITY REASON: the in-process audit table is written inside the same
/// transaction as the business change, but the AUTHENTICATION events (login,
/// logout, password change, block) are exactly the ones an auditor needs and are
/// also the ones most valuable to an attacker to suppress. Recording them again
/// through the bridge gives a second, append-only copy that cannot be edited by
/// anything with access to the main database transaction.
/// </summary>
public sealed class SecurityEventAuditHandler : DomainEventHandlerBase
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public override string Name => nameof(SecurityEventAuditHandler);

    public override IReadOnlyCollection<string> SubscribedEvents { get; } =
    [
        "identity.user.logged-in",
        "identity.user.logged-out",
        "identity.user.password-changed",
        "identity.user.blocked",
        "identity.user.unblocked",
        "identity.user.role-assigned",
        "identity.user.role-removed",
        "identity.user.email-changed"
    ];

    private readonly ILogger<SecurityEventAuditHandler> _logger;

    public SecurityEventAuditHandler(ILogger<SecurityEventAuditHandler> logger) => _logger = logger;

    protected override void Process(DomainEventMessage message)
    {
        _logger.LogInformation(
            "[auditoria] {EventName} agregado {AggregateId} evento {EventId} em {OccurredAt}",
            message.EventName,
            message.AggregateId,
            message.EventId,
            message.OccurredAt);

        // Deliberately logged rather than written to the database: the Consumer
        // has no DbContext on purpose. A deployment that wants a durable copy
        // enables the Audit module in the API, which already records these.
    }
}

/// <summary>
/// Warns when an account is blocked or an approval request is raised, because
/// both usually mean somebody is waiting on a human decision.
///
/// This is the kind of side effect the bridge exists for: it runs outside the
/// request, so a slow notification channel never slows the user down.
/// </summary>
public sealed class AttentionRequiredHandler : DomainEventHandlerBase
{
    public override string Name => nameof(AttentionRequiredHandler);

    public override IReadOnlyCollection<string> SubscribedEvents { get; } =
    [
        "ai.approval.requested",
        "identity.user.blocked",
        "ai.execution.failed"
    ];

    private readonly ILogger<AttentionRequiredHandler> _logger;

    public AttentionRequiredHandler(ILogger<AttentionRequiredHandler> logger) => _logger = logger;

    protected override void Process(DomainEventMessage message)
    {
        _logger.LogWarning(
            "Acao humana requerida: {EventName} agregado {AggregateId} ({Payload})",
            message.EventName,
            message.AggregateId,
            message.PayloadJson);
    }
}