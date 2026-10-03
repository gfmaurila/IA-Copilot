using Kit.Domain.Common;

namespace Kit.Domain.Modules.Content;

/// <summary>
/// ContentItem is an instance of a ContentType. Its payload is a JSON document
/// validated against the ContentType schema - that is the whole point of a
/// Headless Content Platform. Publication is an explicit state transition with
/// its own Domain Event, never a boolean flip in a controller.
/// </summary>
public sealed class ContentItem : AggregateRoot
{
    private readonly List<ContentVersion> _versions = [];

    private ContentItem()
    {
    }

    private ContentItem(Guid id, Guid contentTypeId, string title, string slug, Guid? organizationId)
    {
        Id = id;
        ContentTypeId = contentTypeId;
        Title = title;
        Slug = slug;
        OrganizationId = organizationId;
        Status = ContentStatus.Draft;
    }

    public Guid ContentTypeId { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string Slug { get; private set; } = string.Empty;

    public string? Summary { get; private set; }

    public Guid? TaxonomyId { get; private set; }

    public Guid? OrganizationId { get; private set; }

    public ContentStatus Status { get; private set; }

    public string PayloadJson { get; private set; } = "{}";

    public DateTime? PublishedAtUtc { get; private set; }

    public Guid? PublishedByUserId { get; private set; }

    public IReadOnlyCollection<ContentVersion> Versions => _versions.AsReadOnly();

    public bool IsPublished => Status == ContentStatus.Published;

    public static Result<ContentItem> Create(Guid contentTypeId, string title, string? slug, Guid? organizationId = null)
    {
        if (contentTypeId == Guid.Empty)
        {
            return Result.Failure<ContentItem>(Error.Validation("content.type.required", "Tipo de conteúdo é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<ContentItem>(Error.Validation("content.title.required", "Título é obrigatório."));
        }

        var slugResult = Common.Slug.Create(slug ?? title);
        if (slugResult.IsFailure)
        {
            return Result.Failure<ContentItem>(slugResult.Error);
        }

        var item = new ContentItem(Guid.NewGuid(), contentTypeId, title.Trim(), slugResult.Value.Value, organizationId);
        item.RaiseDomainEvent(new ContentItemCreatedEvent(item.Id, item.ContentTypeId));
        return Result.Success(item);
    }

    /// <summary>
    /// Updates the payload. A new version snapshot is taken on every update so
    /// history is never lost, and the item returns to Draft.
    /// </summary>
    public Result Update(string? title, string? summary, string payloadJson, Guid? taxonomyId)
    {
        if (string.IsNullOrWhiteSpace(payloadJson))
        {
            return Result.Failure(Error.Validation("content.payload.required", "Payload do conteúdo é obrigatório."));
        }

        SnapshotVersion();
        Title = title?.Trim() ?? Title;
        Summary = summary?.Trim();
        TaxonomyId = taxonomyId;
        PayloadJson = payloadJson;

        if (Status == ContentStatus.Published)
        {
            Status = ContentStatus.Draft;
            RaiseDomainEvent(new ContentItemUnpublishedEvent(Id));
        }

        RaiseDomainEvent(new ContentItemUpdatedEvent(Id));
        return Result.Success();
    }

    public Result Publish(Guid userId, DateTime utcNow)
    {
        if (Status == ContentStatus.Published)
        {
            return Result.Failure(Error.Conflict("content.already.published", "O conteúdo já está publicado."));
        }

        Status = ContentStatus.Published;
        PublishedAtUtc = utcNow;
        PublishedByUserId = userId;
        RaiseDomainEvent(new ContentItemPublishedEvent(Id, userId, utcNow));
        return Result.Success();
    }

    public Result Unpublish(Guid userId)
    {
        if (Status != ContentStatus.Published)
        {
            return Result.Failure(Error.Conflict("content.not.published", "O conteúdo não está publicado."));
        }

        Status = ContentStatus.Draft;
        PublishedAtUtc = null;
        PublishedByUserId = null;
        RaiseDomainEvent(new ContentItemUnpublishedEvent(Id));
        return Result.Success();
    }

    public static ContentItem CreateSeeded(
        Guid contentTypeId,
        string title,
        string slug,
        string payloadJson,
        ContentStatus status,
        Guid? organizationId,
        Guid? publishedByUserId,
        DateTime? publishedAtUtc)
    {
        var item = new ContentItem(Guid.NewGuid(), contentTypeId, title, slug, organizationId)
        {
            PayloadJson = payloadJson
        };

        if (status == ContentStatus.Published)
        {
            item.Status = ContentStatus.Published;
            item.PublishedAtUtc = publishedAtUtc;
            item.PublishedByUserId = publishedByUserId;
        }

        return item;
    }

    public void AddSeededVersion(ContentVersion version) => _versions.Add(version);

    public void SetSeededTaxonomy(Guid taxonomyId) => TaxonomyId = taxonomyId;

    private void SnapshotVersion()
    {
        _versions.Add(ContentVersion.Create(Id, _versions.Count + 1, Title, PayloadJson, DateTime.UtcNow));
    }
}

/// <summary>
/// ContentVersion is an immutable snapshot of a ContentItem payload.
/// </summary>
public sealed class ContentVersion : Entity
{
    private ContentVersion()
    {
    }

    public Guid ContentItemId { get; private set; }

    public int VersionNumber { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string PayloadJson { get; private set; } = "{}";

    public DateTime CreatedAtUtc { get; private set; }

    internal static ContentVersion Create(Guid contentItemId, int versionNumber, string title, string payloadJson, DateTime createdAtUtc)
        => new()
        {
            Id = Guid.NewGuid(),
            ContentItemId = contentItemId,
            VersionNumber = versionNumber,
            Title = title,
            PayloadJson = payloadJson,
            CreatedAtUtc = createdAtUtc
        };

    public static ContentVersion CreateSeeded(Guid contentItemId, int versionNumber, string title, string payloadJson, DateTime createdAtUtc)
        => Create(contentItemId, versionNumber, title, payloadJson, createdAtUtc);
}

/// <summary>
/// Taxonomy groups content items (categories, tags). It stays a small explicit
/// entity instead of being folded into a generic key/value store.
/// </summary>
public sealed class Taxonomy : AggregateRoot
{
    private readonly List<string> _terms = [];

    private Taxonomy()
    {
    }

    private Taxonomy(Guid id, string name, string slug, bool isHierarchical)
    {
        Id = id;
        Name = name;
        Slug = slug;
        IsHierarchical = isHierarchical;
    }

    public string Name { get; private set; } = string.Empty;

    public string Slug { get; private set; } = string.Empty;

    public bool IsHierarchical { get; private set; }

    public IReadOnlyCollection<string> Terms => _terms.AsReadOnly();

    public static Result<Taxonomy> Create(string name, string? slug = null, bool isHierarchical = false)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Taxonomy>(Error.Validation("taxonomy.name.required", "Nome da taxonomia é obrigatório."));
        }

        var slugResult = Common.Slug.Create(slug ?? name);
        if (slugResult.IsFailure)
        {
            return Result.Failure<Taxonomy>(slugResult.Error);
        }

        return Result.Success(new Taxonomy(Guid.NewGuid(), name.Trim(), slugResult.Value.Value, isHierarchical));
    }

    public Result AddTerm(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return Result.Failure(Error.Validation("taxonomy.term.required", "Termo é obrigatório."));
        }

        if (_terms.Contains(term.Trim(), StringComparer.OrdinalIgnoreCase))
        {
            return Result.Failure(Error.Conflict("taxonomy.term.duplicated", $"Termo '{term}' já existe."));
        }

        _terms.Add(term.Trim());
        return Result.Success();
    }

    public void AddSeededTerm(string term) => _terms.Add(term);
}

public sealed record ContentItemCreatedEvent(Guid ContentItemId, Guid ContentTypeId) : DomainEventBase(ContentItemId)
{
    public override string EventName => "content.item.created";
}

public sealed record ContentItemUpdatedEvent(Guid ContentItemId) : DomainEventBase(ContentItemId)
{
    public override string EventName => "content.item.updated";
}

public sealed record ContentItemPublishedEvent(Guid ContentItemId, Guid PublishedByUserId, DateTime PublishedAtUtc) : DomainEventBase(ContentItemId)
{
    public override string EventName => "content.item.published";
}

public sealed record ContentItemUnpublishedEvent(Guid ContentItemId) : DomainEventBase(ContentItemId)
{
    public override string EventName => "content.item.unpublished";
}