using Kit.Domain.Common;

namespace Kit.Domain.Modules.Notifications;

public enum NotificationChannel
{
    InApp = 1,
    Email = 2,
    Push = 3,
    Webhook = 4
}

public enum NotificationStatus
{
    Pending = 1,
    Sent = 2,
    Failed = 3,
    Read = 4
}

/// <summary>
/// Notification is a Module Notification (domain fact) that the Notifications
/// module turns into an in-app record. It is raised as a Domain Event, never
/// inserted directly by a controller.
/// </summary>
public sealed class Notification : AggregateRoot
{
    private Notification()
    {
    }

    private Notification(
        Guid id,
        Guid? recipientUserId,
        NotificationChannel channel,
        string title,
        string body,
        string? actionUrl,
        NotificationStatus status,
        DateTime createdAtUtc)
    {
        Id = id;
        RecipientUserId = recipientUserId;
        Channel = channel;
        Title = title;
        Body = body;
        ActionUrl = actionUrl;
        Status = status;
        CreatedAtUtc = createdAtUtc;
    }

    public Guid? RecipientUserId { get; private set; }

    public NotificationChannel Channel { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string Body { get; private set; } = string.Empty;

    public string? ActionUrl { get; private set; }

    public NotificationStatus Status { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    public DateTime? SentAtUtc { get; private set; }

    public DateTime? ReadAtUtc { get; private set; }

    public string? FailureReason { get; private set; }

    public static Result<Notification> Create(
        Guid? recipientUserId,
        NotificationChannel channel,
        string title,
        string body,
        string? actionUrl = null)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<Notification>(Error.Validation("notification.title.required", "Título é obrigatório."));
        }

        return Result.Success(new Notification(
            Guid.NewGuid(),
            recipientUserId,
            channel,
            title.Trim(),
            body?.Trim() ?? string.Empty,
            actionUrl,
            NotificationStatus.Pending,
            DateTime.UtcNow));
    }

    public Result MarkAsSent()
    {
        if (Status != NotificationStatus.Pending)
        {
            return Result.Failure(Error.Conflict("notification.not-pending", "A notificação não está pendente."));
        }

        Status = NotificationStatus.Sent;
        SentAtUtc = DateTime.UtcNow;
        return Result.Success();
    }

    public Result MarkAsFailed(string reason)
    {
        if (Status == NotificationStatus.Sent)
        {
            return Result.Failure(Error.Conflict("notification.already.sent", "A notificação já foi enviada."));
        }

        Status = NotificationStatus.Failed;
        FailureReason = reason;
        return Result.Success();
    }

    public Result MarkAsRead()
    {
        if (ReadAtUtc is not null)
        {
            return Result.Failure(Error.Conflict("notification.already.read", "A notificação já foi lida."));
        }

        ReadAtUtc = DateTime.UtcNow;
        if (Status == NotificationStatus.Sent)
        {
            Status = NotificationStatus.Read;
        }

        return Result.Success();
    }

    public static Notification CreateSeeded(
        Guid? recipientUserId,
        NotificationChannel channel,
        string title,
        string body,
        NotificationStatus status,
        DateTime createdAtUtc,
        string? actionUrl = null)
    {
        var notification = new Notification(
            Guid.NewGuid(),
            recipientUserId,
            channel,
            title,
            body,
            actionUrl,
            status,
            createdAtUtc);

        if (status == NotificationStatus.Sent || status == NotificationStatus.Read)
        {
            notification.SentAtUtc = createdAtUtc;
        }

        if (status == NotificationStatus.Read)
        {
            notification.ReadAtUtc = createdAtUtc.AddMinutes(5);
        }

        return notification;
    }
}