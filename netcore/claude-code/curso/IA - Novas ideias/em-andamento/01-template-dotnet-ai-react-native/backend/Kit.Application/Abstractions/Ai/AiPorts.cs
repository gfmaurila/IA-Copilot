namespace Kit.Application.Abstractions.Ai;

using Kit.Domain.Common;
using Kit.Domain.Modules.Ai;

/// <summary>
/// Provider-agnostic chat model port.
/// Vendor SDKs (OpenAI, Azure OpenAI, Anthropic, Bedrock, Ollama...) live in
/// Infrastructure and implement this interface. No controller or domain handler
/// is ever allowed to reference a vendor SDK type.
/// </summary>
public interface IChatModel
{
    string Provider { get; }

    string DefaultModel { get; }

    Task<ChatCompletionResult> CompleteAsync(ChatCompletionRequest request, CancellationToken cancellationToken = default);
}

public sealed record ChatMessage(string Role, string Content);

public sealed record ChatCompletionRequest(
    IReadOnlyList<ChatMessage> Messages,
    string Model,
    double Temperature = 0.2,
    int MaxTokens = 2048,
    string? ResponseSchemaJson = null,
    IReadOnlyList<ChatToolDefinition>? Tools = null);

public sealed record ChatToolDefinition(string Name, string Description, string InputSchemaJson);

public sealed record ChatCompletionResult(
    string Content,
    string Model,
    int PromptTokens,
    int CompletionTokens,
    TimeSpan Duration,
    IReadOnlyList<ChatToolCall> ToolCalls,
    string? FinishReason);

public sealed record ChatToolCall(string Id, string Name, string ArgumentsJson);

/// <summary>
/// Embeddings port. Kept separate from <see cref="IChatModel"/> so a project can
/// use a different vendor for embeddings than for chat.
/// </summary>
public interface IEmbeddingGenerator
{
    string Provider { get; }

    string Model { get; }

    Task<EmbeddingResult> GenerateAsync(IReadOnlyList<string> inputs, CancellationToken cancellationToken = default);
}

public sealed record EmbeddingVector(string PointId, double[] Values, int TokenCount);

public sealed record EmbeddingResult(
    IReadOnlyList<EmbeddingVector> Vectors,
    string Model,
    int TotalTokens,
    TimeSpan Duration);

/// <summary>
/// Vector store port. A concrete vector database (pgvector, Qdrant, Milvus,
/// MongoDB Atlas...) is an Infrastructure concern and is only added to Docker
/// when RAG is actually enabled.
/// </summary>
public interface IVectorStore
{
    Task UpsertAsync(Guid knowledgeBaseId, IReadOnlyList<EmbeddingVector> vectors, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RetrievedChunk>> SearchAsync(
        Guid knowledgeBaseId,
        double[] queryVector,
        int topK,
        double minimumScore,
        Guid? requiredOrganizationId,
        CancellationToken cancellationToken = default);

    Task DeleteByKnowledgeBaseAsync(Guid knowledgeBaseId, CancellationToken cancellationToken = default);
}

/// <summary>
/// Parses/validates the structured output produced by an LLM.
/// AI security rule: model output is untrusted input and MUST be validated against
/// a schema before it is allowed to reach the Application layer.
/// </summary>
public interface IStructuredOutputParser
{
    Result<T> Parse<T>(string rawJson, CancellationToken cancellationToken = default);
}

/// <summary>
/// A Tool as seen by the AI orchestration layer. Implementations must dispatch a
/// Command or a Query through MediatR - never touch a table, never call a
/// repository directly.
/// </summary>
public interface IAiTool
{
    string Name { get; }

    string Description { get; }

    /// <summary>IAM permission required by the CALLER for this tool to be executed.</summary>
    string RequiredPermission { get; }

    /// <summary>True when the tool only reads. Write tools are the ones that may need human approval.</summary>
    bool IsReadOnly { get; }

    string InputSchemaJson { get; }

    bool RequiresApproval { get; }

    Task<Result<string>> ExecuteAsync(string argumentsJson, Guid userId, Guid? organizationId, CancellationToken cancellationToken = default);
}