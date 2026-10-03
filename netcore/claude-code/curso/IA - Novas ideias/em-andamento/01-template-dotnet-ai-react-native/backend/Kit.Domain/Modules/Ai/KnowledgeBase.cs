using Kit.Domain.Common;

namespace Kit.Domain.Modules.Ai;

/// <summary>
/// KnowledgeBase is the tenant-scoped container for RAG. The scope fields
/// (OrganizationId + AllowedRoles) are what prevent one tenant's knowledge from
/// ever being mixed into another tenant's retrieval results.
/// </summary>
public sealed class KnowledgeBase : AggregateRoot
{
    private readonly List<KnowledgeDocument> _documents = [];

    private KnowledgeBase()
    {
    }

    private KnowledgeBase(Guid id, string name, string description, Guid? organizationId, string embeddingModel)
    {
        Id = id;
        Name = name;
        Description = description;
        OrganizationId = organizationId;
        EmbeddingModel = embeddingModel;
        Status = KnowledgeBaseStatus.Pending;
        CreatedByUserId = null;
    }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    /// <summary>NULL only in a single-tenant deployment. When set, it is mandatory on every query.</summary>
    public Guid? OrganizationId { get; private set; }

    public string EmbeddingModel { get; private set; } = string.Empty;

    public KnowledgeBaseStatus Status { get; private set; }

    public Guid? CreatedByUserId { get; private set; }

    public IReadOnlyCollection<KnowledgeDocument> Documents => _documents.AsReadOnly();

    public static Result<KnowledgeBase> Create(string name, string description, Guid? organizationId, string embeddingModel, Guid createdByUserId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<KnowledgeBase>(Error.Validation("knowledge-base.name.required", "Nome da base de conhecimento é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(embeddingModel))
        {
            return Result.Failure<KnowledgeBase>(Error.Validation("knowledge-base.embeddingModel.required", "Modelo de embedding é obrigatório."));
        }

        return Result.Success(new KnowledgeBase(Guid.NewGuid(), name.Trim(), description?.Trim() ?? string.Empty, organizationId, embeddingModel.Trim())
        {
            CreatedByUserId = createdByUserId
        });
    }

    public Result MarkAsReady() => ChangeStatus(KnowledgeBaseStatus.Ready);

    public Result MarkAsFailed() => ChangeStatus(KnowledgeBaseStatus.Failed);

    public Result AttachDocument(KnowledgeDocument document)
    {
        ArgumentNullException.ThrowIfNull(document);

        if (_documents.Any(d => d.Id == document.Id))
        {
            return Result.Failure(Error.Conflict("knowledge-base.document.duplicated", "O documento já pertence a esta base."));
        }

        _documents.Add(document);
        return Result.Success();
    }

    public void AddSeededDocument(KnowledgeDocument document) => _documents.Add(document);

    public void SetSeededCreatedBy(Guid userId) => CreatedByUserId = userId;

    private Result ChangeStatus(KnowledgeBaseStatus status)
    {
        if (Status == status)
        {
            return Result.Failure(Error.Conflict("knowledge-base.status.unchanged", "A base de conhecimento já está neste status."));
        }

        Status = status;
        return Result.Success();
    }
}

/// <summary>
/// KnowledgeDocument tracks one source document through the RAG pipeline:
/// Parsing -> Chunking -> Embeddings -> Vector Store.
/// It carries its own authorization scope, so retrieval must filter on it.
/// </summary>
public sealed class KnowledgeDocument : Entity
{
    private readonly List<DocumentChunk> _chunks = [];

    private KnowledgeDocument()
    {
    }

    private KnowledgeDocument(Guid id, Guid knowledgeBaseId, string fileName, string contentType, string storageKey, long sizeInBytes, Guid uploadedByUserId)
    {
        Id = id;
        KnowledgeBaseId = knowledgeBaseId;
        FileName = fileName;
        ContentType = contentType;
        StorageKey = storageKey;
        SizeInBytes = sizeInBytes;
        UploadedByUserId = uploadedByUserId;
        Status = DocumentIngestionStatus.Pending;
    }

    public Guid KnowledgeBaseId { get; private set; }

    public string FileName { get; private set; } = string.Empty;

    public string ContentType { get; private set; } = string.Empty;

    public string StorageKey { get; private set; } = string.Empty;

    public long SizeInBytes { get; private set; }

    public Guid UploadedByUserId { get; private set; }

    public DocumentIngestionStatus Status { get; private set; }

    public string? ErrorMessage { get; private set; }

    public int ChunkCount { get; private set; }

    public DateTime? IngestedAtUtc { get; private set; }

    public IReadOnlyCollection<DocumentChunk> Chunks => _chunks.AsReadOnly();

    public static Result<KnowledgeDocument> Create(Guid knowledgeBaseId, string fileName, string contentType, string storageKey, long sizeInBytes, Guid uploadedByUserId)
    {
        if (knowledgeBaseId == Guid.Empty)
        {
            return Result.Failure<KnowledgeDocument>(Error.Validation("document.knowledge-base.required", "Base de conhecimento é obrigatória."));
        }

        if (string.IsNullOrWhiteSpace(fileName))
        {
            return Result.Failure<KnowledgeDocument>(Error.Validation("document.fileName.required", "Nome do documento é obrigatório."));
        }

        if (sizeInBytes <= 0)
        {
            return Result.Failure<KnowledgeDocument>(Error.Validation("document.size.invalid", "Tamanho do documento deve ser maior que zero."));
        }

        return Result.Success(new KnowledgeDocument(Guid.NewGuid(), knowledgeBaseId, fileName, contentType ?? "text/plain", storageKey, sizeInBytes, uploadedByUserId));
    }

    public Result Advance(DocumentIngestionStatus next)
    {
        if (Status == DocumentIngestionStatus.Failed)
        {
            return Result.Failure(Error.Conflict("document.failed", "O documento falhou na ingestão e precisa ser reprocessado."));
        }

        Status = next;
        if (next == DocumentIngestionStatus.Embedded)
        {
            IngestedAtUtc = DateTime.UtcNow;
        }

        return Result.Success();
    }

    public Result RegisterChunks(int count)
    {
        if (count < 0)
        {
            return Result.Failure(Error.Validation("document.chunk-count.invalid", "Quantidade de chunks deve ser maior ou igual a zero."));
        }

        ChunkCount = count;
        return Result.Success();
    }

    public Result FailIngestion(string errorMessage)
    {
        Status = DocumentIngestionStatus.Failed;
        ErrorMessage = errorMessage;
        return Result.Success();
    }

    public static KnowledgeDocument CreateSeeded(
        Guid knowledgeBaseId,
        string fileName,
        string contentType,
        string storageKey,
        long sizeInBytes,
        Guid uploadedByUserId,
        DocumentIngestionStatus status,
        int chunkCount,
        string? errorMessage = null)
    {
        var document = new KnowledgeDocument(Guid.NewGuid(), knowledgeBaseId, fileName, contentType, storageKey, sizeInBytes, uploadedByUserId)
        {
            Status = status,
            ChunkCount = chunkCount,
            ErrorMessage = errorMessage
        };

        if (status == DocumentIngestionStatus.Embedded)
        {
            document.IngestedAtUtc = DateTime.UtcNow;
        }

        return document;
    }

    public void AddSeededChunk(DocumentChunk chunk) => _chunks.Add(chunk);
}

/// <summary>
/// DocumentChunk is the unit that actually gets embedded and stored in the vector
/// database. It holds the pointer to the vector, never the vector itself.
/// </summary>
public sealed class DocumentChunk : Entity
{
    private DocumentChunk()
    {
    }

    public Guid DocumentId { get; private set; }

    public int Position { get; private set; }

    public string Text { get; private set; } = string.Empty;

    public string? VectorPointId { get; private set; }

    public int TokenCount { get; private set; }

    public static DocumentChunk Create(Guid documentId, int position, string text, int tokenCount, string? vectorPointId)
        => new()
        {
            Id = Guid.NewGuid(),
            DocumentId = documentId,
            Position = position,
            Text = text,
            TokenCount = tokenCount,
            VectorPointId = vectorPointId
        };

    public static DocumentChunk CreateSeeded(Guid documentId, int position, string text, int tokenCount, string? vectorPointId)
        => Create(documentId, position, text, tokenCount, vectorPointId);
}

/// <summary>
/// RetrievedChunk is the RAG output handed back to the LLM. The scope fields are
/// carried explicitly so an audit can prove which tenant's data was used.
/// </summary>
public sealed record RetrievedChunk(
    Guid DocumentId,
    Guid KnowledgeBaseId,
    Guid? OrganizationId,
    string Text,
    double Score,
    int Position);