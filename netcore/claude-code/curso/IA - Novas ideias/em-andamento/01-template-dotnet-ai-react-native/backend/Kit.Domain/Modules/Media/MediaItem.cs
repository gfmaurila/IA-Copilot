using Kit.Domain.Common;

namespace Kit.Domain.Modules.Media;

public enum MediaKind
{
    Image = 1,
    Video = 2,
    Audio = 3,
    Document = 4,
    Other = 5
}

public enum MediaStatus
{
    Pending = 1,
    Ready = 2,
    Failed = 3
}

/// <summary>
/// Media owns FILE METADATA, storage keys and file-level authorization only.
/// It must never carry content publishing rules - that belongs to Content.
/// </summary>
public sealed class MediaItem : AggregateRoot
{
    private MediaItem()
    {
    }

    private MediaItem(Guid id, string fileName, string storageKey, string contentType, long sizeInBytes, MediaKind kind, Guid uploadedByUserId)
    {
        Id = id;
        FileName = fileName;
        StorageKey = storageKey;
        ContentType = contentType;
        SizeInBytes = sizeInBytes;
        Kind = kind;
        UploadedByUserId = uploadedByUserId;
        Status = MediaStatus.Pending;
    }

    public string FileName { get; private set; } = string.Empty;

    /// <summary>Logical key inside the storage volume - never a public URL.</summary>
    public string StorageKey { get; private set; } = string.Empty;

    public string ContentType { get; private set; } = string.Empty;

    public long SizeInBytes { get; private set; }

    public MediaKind Kind { get; private set; }

    public MediaStatus Status { get; private set; }

    public Guid UploadedByUserId { get; private set; }

    public Guid? OrganizationId { get; private set; }

    public string? AltText { get; private set; }

    public int? Width { get; private set; }

    public int? Height { get; private set; }

    public DateTime? UploadedAtUtc { get; private set; }

    public static Result<MediaItem> Create(
        string fileName,
        string storageKey,
        string contentType,
        long sizeInBytes,
        Guid uploadedByUserId)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return Result.Failure<MediaItem>(Error.Validation("media.fileName.required", "Nome do arquivo é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(storageKey))
        {
            return Result.Failure<MediaItem>(Error.Validation("media.storageKey.required", "Chave de armazenamento é obrigatória."));
        }

        if (sizeInBytes <= 0)
        {
            return Result.Failure<MediaItem>(Error.Validation("media.size.invalid", "Tamanho do arquivo deve ser maior que zero."));
        }

        return Result.Success(new MediaItem(
            Guid.NewGuid(),
            fileName.Trim(),
            storageKey.Trim(),
            contentType?.Trim() ?? "application/octet-stream",
            sizeInBytes,
            ResolveKind(contentType),
            uploadedByUserId));
    }

    public Result MarkAsReady(int? width = null, int? height = null)
    {
        if (Status == MediaStatus.Ready)
        {
            return Result.Failure(Error.Conflict("media.already.ready", "A mídia já está pronta."));
        }

        Status = MediaStatus.Ready;
        UploadedAtUtc = DateTime.UtcNow;
        Width = width;
        Height = height;
        return Result.Success();
    }

    public Result MarkAsFailed(string reason)
    {
        if (Status == MediaStatus.Ready)
        {
            return Result.Failure(Error.Conflict("media.already.ready", "Não é possível falhar uma mídia pronta."));
        }

        Status = MediaStatus.Failed;
        return Result.Success();
    }

    public Result UpdateAltText(string? altText)
    {
        AltText = altText?.Trim();
        return Result.Success();
    }

    public void SetSeededOrganization(Guid organizationId) => OrganizationId = organizationId;

    public static MediaItem CreateSeeded(
        string fileName,
        string storageKey,
        string contentType,
        long sizeInBytes,
        Guid uploadedByUserId,
        Guid? organizationId,
        MediaStatus status,
        string? altText = null,
        int? width = null,
        int? height = null)
    {
        var item = new MediaItem(Guid.NewGuid(), fileName, storageKey, contentType, sizeInBytes, ResolveKind(contentType), uploadedByUserId)
        {
            OrganizationId = organizationId,
            AltText = altText
        };

        if (status == MediaStatus.Ready)
        {
            item.Status = MediaStatus.Ready;
            item.UploadedAtUtc = DateTime.UtcNow;
            item.Width = width;
            item.Height = height;
        }

        return item;
    }

    private static MediaKind ResolveKind(string? contentType) => contentType?.ToLowerInvariant() switch
    {
        null or "" => MediaKind.Other,
        var ct when ct.StartsWith("image/", StringComparison.Ordinal) => MediaKind.Image,
        var ct when ct.StartsWith("video/", StringComparison.Ordinal) => MediaKind.Video,
        var ct when ct.StartsWith("audio/", StringComparison.Ordinal) => MediaKind.Audio,
        _ => MediaKind.Document
    };
}