using Kit.Domain.Common;

namespace Kit.Domain.Modules.Ai;

/// <summary>
/// AgentExecution records one run of an agent. It is the unit that makes AI
/// observable (model, provider, latency, tokens, cost, retries, tool calls) and
/// the unit that Human-in-the-loop approvals attach to.
/// </summary>
public sealed class AgentExecution : AggregateRoot
{
    private readonly List<ApprovalRequest> _approvals = [];

    private AgentExecution()
    {
    }

    private AgentExecution(Guid id, Guid agentId, Guid userId, string correlationId, bool requiresHumanApproval)
    {
        Id = id;
        AgentId = agentId;
        UserId = userId;
        CorrelationId = correlationId;
        RequiresHumanApproval = requiresHumanApproval;
        Status = ExecutionStatus.Pending;
        StartedAtUtc = DateTime.UtcNow;
    }

    public Guid AgentId { get; private set; }

    public Guid UserId { get; private set; }

    public string CorrelationId { get; private set; } = string.Empty;

    public ExecutionStatus Status { get; private set; }

    public string? InputJson { get; private set; }

    public string? OutputJson { get; private set; }

    public string? ErrorMessage { get; private set; }

    public bool RequiresHumanApproval { get; private set; }

    public DateTime StartedAtUtc { get; private set; }

    public DateTime? CompletedAtUtc { get; private set; }

    public int RetryCount { get; private set; }

    public decimal EstimatedCostUsd { get; private set; }

    public int PromptTokens { get; private set; }

    public int CompletionTokens { get; private set; }

    public IReadOnlyCollection<ApprovalRequest> Approvals => _approvals.AsReadOnly();

    public static Result<AgentExecution> Create(Guid agentId, Guid userId, string correlationId, bool requiresHumanApproval)
    {
        if (agentId == Guid.Empty)
        {
            return Result.Failure<AgentExecution>(Error.Validation("execution.agent.required", "Agente é obrigatório."));
        }

        if (userId == Guid.Empty)
        {
            return Result.Failure<AgentExecution>(Error.Validation("execution.user.required", "Usuário executor é obrigatório."));
        }

        return Result.Success(new AgentExecution(Guid.NewGuid(), agentId, userId, correlationId, requiresHumanApproval));
    }

    public Result Start()
    {
        if (Status != ExecutionStatus.Pending)
        {
            return Result.Failure(Error.Conflict("execution.not-pending", "A execução não está pendente."));
        }

        Status = ExecutionStatus.Running;
        return Result.Success();
    }

    /// <summary>
    /// Requests human approval for a sensitive action. This is a HARD STATE: while
    /// an approval is pending the execution cannot move to Succeeded.
    /// </summary>
    public Result RequestApproval(string actionName, string payloadJson, string requestedByTool)
    {
        if (Status is ExecutionStatus.Succeeded or ExecutionStatus.Failed or ExecutionStatus.Cancelled)
        {
            return Result.Failure(Error.Conflict("execution.finished", "A execução já foi finalizada."));
        }

        if (_approvals.Any(a => a.ActionName == actionName && a.Status == ApprovalStatus.Pending))
        {
            return Result.Failure(Error.Conflict("approval.already.pending", "Já existe uma aprovação pendente para esta ação."));
        }

        var approval = ApprovalRequest.Create(Id, actionName, payloadJson, requestedByTool);
        _approvals.Add(approval);
        Status = ExecutionStatus.WaitingApproval;
        RaiseDomainEvent(new ApprovalRequestedEvent(Id, approval.Id, actionName));
        return Result.Success(approval);
    }

    public Result Approve(Guid approvalId, Guid reviewerUserId, string? comment)
    {
        var approval = _approvals.FirstOrDefault(a => a.Id == approvalId);
        if (approval is null)
        {
            return Result.Failure(Error.NotFound("approval.not-found", "Aprovação não encontrada nesta execução."));
        }

        var approved = approval.Approve(reviewerUserId, comment);
        if (approved.IsFailure)
        {
            return approved;
        }

        if (_approvals.All(a => a.Status != ApprovalStatus.Pending))
        {
            Status = ExecutionStatus.Running;
        }

        RaiseDomainEvent(new ApprovalDecidedEvent(Id, approvalId, approval.Status));
        return Result.Success();
    }

    public Result Reject(Guid approvalId, Guid reviewerUserId, string? comment)
    {
        var approval = _approvals.FirstOrDefault(a => a.Id == approvalId);
        if (approval is null)
        {
            return Result.Failure(Error.NotFound("approval.not-found", "Aprovação não encontrada nesta execução."));
        }

        var rejected = approval.Reject(reviewerUserId, comment);
        if (rejected.IsFailure)
        {
            return rejected;
        }

        RaiseDomainEvent(new ApprovalDecidedEvent(Id, approvalId, approval.Status));
        return Result.Success();
    }

    public Result Succeed(string outputJson, int promptTokens, int completionTokens, decimal estimatedCostUsd, TimeSpan duration)
    {
        if (Status == ExecutionStatus.WaitingApproval)
        {
            return Result.Failure(Error.Conflict("execution.awaiting-approval", "A execução possui ações aguardando aprovação humana."));
        }

        if (_approvals.Any(a => a.Status == ApprovalStatus.Rejected))
        {
            return Result.Failure(Error.Conflict("execution.rejected-action", "Uma ação do agente foi rejeitada."));
        }

        Status = ExecutionStatus.Succeeded;
        OutputJson = outputJson;
        PromptTokens = promptTokens;
        CompletionTokens = completionTokens;
        EstimatedCostUsd = estimatedCostUsd;
        CompletedAtUtc = StartedAtUtc.Add(duration);
        return Result.Success();
    }

    public Result Fail(string errorMessage)
    {
        Status = ExecutionStatus.Failed;
        ErrorMessage = errorMessage;
        CompletedAtUtc = DateTime.UtcNow;
        RaiseDomainEvent(new ExecutionFailedEvent(Id, errorMessage));
        return Result.Success();
    }

    public Result Cancel(string reason)
    {
        if (Status is ExecutionStatus.Succeeded or ExecutionStatus.Failed)
        {
            return Result.Failure(Error.Conflict("execution.finished", "A execução já foi finalizada."));
        }

        Status = ExecutionStatus.Cancelled;
        ErrorMessage = reason;
        CompletedAtUtc = DateTime.UtcNow;
        return Result.Success();
    }

    public Result RegisterRetry()
    {
        if (RetryCount >= 5)
        {
            return Result.Failure(Error.Conflict("execution.retry.limit", "Limite de retries excedido."));
        }

        RetryCount++;
        return Result.Success();
    }

    public static AgentExecution CreateSeeded(
        Guid agentId,
        Guid userId,
        ExecutionStatus status,
        string correlationId,
        DateTime startedAtUtc,
        DateTime? completedAtUtc,
        string? inputJson,
        string? outputJson,
        string? errorMessage,
        bool requiresHumanApproval,
        int promptTokens = 0,
        int completionTokens = 0,
        decimal estimatedCostUsd = 0m,
        int retryCount = 0)
        => new(Guid.NewGuid(), agentId, userId, correlationId, requiresHumanApproval)
        {
            Status = status,
            StartedAtUtc = startedAtUtc,
            CompletedAtUtc = completedAtUtc,
            InputJson = inputJson,
            OutputJson = outputJson,
            ErrorMessage = errorMessage,
            PromptTokens = promptTokens,
            CompletionTokens = completionTokens,
            EstimatedCostUsd = estimatedCostUsd,
            RetryCount = retryCount
        };

    public void AddSeededApproval(ApprovalRequest approval)
    {
        _approvals.Add(approval);
        if (approval.Status == ApprovalStatus.Pending)
        {
            Status = ExecutionStatus.WaitingApproval;
        }
    }
}

/// <summary>
/// ApprovalRequest is a Human-in-the-loop gate attached to an execution.
/// </summary>
public sealed class ApprovalRequest : Entity
{
    private ApprovalRequest()
    {
    }

    public Guid ExecutionId { get; private set; }

    public string ActionName { get; private set; } = string.Empty;

    /// <summary>The Command payload the agent wants to run. Shown to the human reviewer verbatim.</summary>
    public string PayloadJson { get; private set; } = "{}";

    public string RequestedByTool { get; private set; } = string.Empty;

    public ApprovalStatus Status { get; private set; }

    public Guid? ReviewerUserId { get; private set; }

    public string? ReviewerComment { get; private set; }

    public DateTime RequestedAtUtc { get; private set; }

    public DateTime? DecidedAtUtc { get; private set; }

    public DateTime ExpiresAtUtc { get; private set; }

    internal static ApprovalRequest Create(Guid executionId, string actionName, string payloadJson, string requestedByTool)
        => new()
        {
            Id = Guid.NewGuid(),
            ExecutionId = executionId,
            ActionName = actionName,
            PayloadJson = payloadJson,
            RequestedByTool = requestedByTool,
            Status = ApprovalStatus.Pending,
            RequestedAtUtc = DateTime.UtcNow,
            ExpiresAtUtc = DateTime.UtcNow.AddHours(24)
        };

    public static ApprovalRequest CreateSeeded(
        Guid executionId,
        string actionName,
        string payloadJson,
        string requestedByTool,
        ApprovalStatus status,
        Guid? reviewerUserId,
        string? comment,
        DateTime requestedAtUtc,
        DateTime expiresAtUtc)
        => new()
        {
            Id = Guid.NewGuid(),
            ExecutionId = executionId,
            ActionName = actionName,
            PayloadJson = payloadJson,
            RequestedByTool = requestedByTool,
            Status = status,
            ReviewerUserId = reviewerUserId,
            ReviewerComment = comment,
            RequestedAtUtc = requestedAtUtc,
            ExpiresAtUtc = expiresAtUtc,
            DecidedAtUtc = status == ApprovalStatus.Pending ? null : requestedAtUtc.AddMinutes(15)
        };

    internal Result Approve(Guid reviewerUserId, string? comment)
    {
        if (Status != ApprovalStatus.Pending)
        {
            return Result.Failure(Error.Conflict("approval.not-pending", "A aprovação já foi decidida."));
        }

        Status = ApprovalStatus.Approved;
        ReviewerUserId = reviewerUserId;
        ReviewerComment = comment;
        DecidedAtUtc = DateTime.UtcNow;
        return Result.Success();
    }

    internal Result Reject(Guid reviewerUserId, string? comment)
    {
        if (Status != ApprovalStatus.Pending)
        {
            return Result.Failure(Error.Conflict("approval.not-pending", "A aprovação já foi decidida."));
        }

        Status = ApprovalStatus.Rejected;
        ReviewerUserId = reviewerUserId;
        ReviewerComment = comment;
        DecidedAtUtc = DateTime.UtcNow;
        return Result.Success();
    }
}

/// <summary>
/// AiRun records a single LLM call for observability and evaluation. It never
/// stores prompts containing secrets and never stores raw PII beyond what the
/// redaction policy allows.
/// </summary>
public sealed class AiRun : AggregateRoot
{
    private AiRun()
    {
    }

    private AiRun(
        Guid id,
        string provider,
        string model,
        string operation,
        Guid? executionId,
        string correlationId,
        int promptTokens,
        int completionTokens,
        TimeSpan duration,
        decimal estimatedCostUsd,
        bool success,
        string? errorMessage,
        DateTime startedAtUtc)
    {
        Id = id;
        Provider = provider;
        Model = model;
        Operation = operation;
        ExecutionId = executionId;
        CorrelationId = correlationId;
        PromptTokens = promptTokens;
        CompletionTokens = completionTokens;
        Duration = duration;
        EstimatedCostUsd = estimatedCostUsd;
        Success = success;
        ErrorMessage = errorMessage;
        StartedAtUtc = startedAtUtc;
    }

    public string Provider { get; private set; } = string.Empty;

    public string Model { get; private set; } = string.Empty;

    /// <summary>chat, embedding, rerank, tool-call...</summary>
    public string Operation { get; private set; } = string.Empty;

    public Guid? ExecutionId { get; private set; }

    public string CorrelationId { get; private set; } = string.Empty;

    public int PromptTokens { get; private set; }

    public int CompletionTokens { get; private set; }

    public TimeSpan Duration { get; private set; }

    public decimal EstimatedCostUsd { get; private set; }

    public bool Success { get; private set; }

    public string? ErrorMessage { get; private set; }

    public DateTime StartedAtUtc { get; private set; }

    public int Attempt { get; private set; } = 1;

    public string? ToolName { get; private set; }

    public static Result<AiRun> Create(
        string provider,
        string model,
        string operation,
        Guid? executionId,
        string correlationId,
        int promptTokens,
        int completionTokens,
        TimeSpan duration,
        decimal estimatedCostUsd,
        bool success,
        string? errorMessage,
        DateTime startedAtUtc)
    {
        if (string.IsNullOrWhiteSpace(provider))
        {
            return Result.Failure<AiRun>(Error.Validation("ai-run.provider.required", "Provider é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(model))
        {
            return Result.Failure<AiRun>(Error.Validation("ai-run.model.required", "Modelo é obrigatório."));
        }

        return Result.Success(new AiRun(
            Guid.NewGuid(),
            provider.Trim(),
            model.Trim(),
            operation?.Trim() ?? "chat",
            executionId,
            correlationId,
            promptTokens,
            completionTokens,
            duration,
            estimatedCostUsd,
            success,
            errorMessage,
            startedAtUtc));
    }

    public Result RegisterToolCall(string toolName)
    {
        ToolName = toolName;
        return Result.Success();
    }

    public Result RegisterRetryAttempt()
    {
        Attempt++;
        return Result.Success();
    }

    public static AiRun CreateSeeded(
        string provider,
        string model,
        string operation,
        Guid? executionId,
        string correlationId,
        int promptTokens,
        int completionTokens,
        TimeSpan duration,
        decimal estimatedCostUsd,
        bool success,
        string? errorMessage,
        DateTime startedAtUtc,
        int attempt,
        string? toolName)
        => new(Guid.NewGuid(), provider, model, operation, executionId, correlationId, promptTokens, completionTokens, duration, estimatedCostUsd, success, errorMessage, startedAtUtc)
        {
            Attempt = attempt,
            ToolName = toolName
        };
}

public sealed record ApprovalRequestedEvent(Guid ExecutionId, Guid ApprovalId, string ActionName) : DomainEventBase(ExecutionId)
{
    public override string EventName => "ai.approval.requested";
}

public sealed record ApprovalDecidedEvent(Guid ExecutionId, Guid ApprovalId, ApprovalStatus Status) : DomainEventBase(ExecutionId)
{
    public override string EventName => "ai.approval.decided";
}

public sealed record ExecutionFailedEvent(Guid ExecutionId, string ErrorMessage) : DomainEventBase(ExecutionId)
{
    public override string EventName => "ai.execution.failed";
}