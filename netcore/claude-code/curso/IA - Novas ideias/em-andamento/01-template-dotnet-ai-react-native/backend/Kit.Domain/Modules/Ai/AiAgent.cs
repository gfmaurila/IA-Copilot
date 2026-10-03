using Kit.Domain.Common;

namespace Kit.Domain.Modules.Ai;

public enum AgentStatus
{
    Draft = 1,
    Active = 2,
    Disabled = 3
}

public enum ExecutionStatus
{
    Pending = 1,
    Running = 2,
    WaitingApproval = 3,
    Succeeded = 4,
    Failed = 5,
    Cancelled = 6
}

public enum ApprovalStatus
{
    Pending = 1,
    Approved = 2,
    Rejected = 3,
    Expired = 4
}

public enum KnowledgeBaseStatus
{
    Pending = 1,
    Ready = 2,
    Failed = 3
}

public enum DocumentIngestionStatus
{
    Pending = 1,
    Parsed = 2,
    Chunked = 3,
    Embedded = 4,
    Failed = 5
}

/// <summary>
/// Agent is a configured, reviewable unit of AI behavior. It does NOT execute
/// anything by itself: it declares which Tools it may call and which permission
/// each Tool requires, so the authorization decision stays enforceable even when
/// the caller is an LLM.
/// </summary>
public sealed class AiAgent : AggregateRoot
{
    private AiAgent()
    {
    }

    private AiAgent(Guid id, string name, string description, AgentStatus status, Guid? organizationId)
    {
        Id = id;
        Name = name;
        Description = description;
        Status = status;
        OrganizationId = organizationId;
    }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public AgentStatus Status { get; private set; }

    public Guid? OrganizationId { get; private set; }

    /// <summary>Temperature, sampled from configuration. Kept as a string to avoid a provider type.</summary>
    public string ModelSettingsJson { get; private set; } = "{}";

    /// <summary>
    /// Hard allowlist. An agent can never call a Tool that is not listed.
    /// Backing store is always a List: the collection expression `[]` would be
    /// materialized as an array and every AllowTool/AttachPrompt call would be
    /// silently discarded.
    /// </summary>
    public IReadOnlyCollection<string> ToolNames { get; private set; } = new List<string>();

    public IReadOnlyCollection<string> PromptNames { get; private set; } = new List<string>();

    public bool RequiresHumanApproval { get; private set; }

    private List<string> ToolList => ToolNames as List<string> ?? [.. ToolNames];

    private List<string> PromptList => PromptNames as List<string> ?? [.. PromptNames];

    public static Result<AiAgent> Create(string name, string description, Guid? organizationId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<AiAgent>(Error.Validation("agent.name.required", "Nome do agente é obrigatório."));
        }

        var agent = new AiAgent(Guid.NewGuid(), name.Trim(), description?.Trim() ?? string.Empty, AgentStatus.Draft, organizationId);

        return Result.Success(agent);
    }

    public Result AllowTool(string toolName)
    {
        if (string.IsNullOrWhiteSpace(toolName))
        {
            return Result.Failure(Error.Validation("agent.tool.required", "Nome da tool é obrigatório."));
        }

        if (ToolNames.Contains(toolName.Trim(), StringComparer.OrdinalIgnoreCase))
        {
            return Result.Failure(Error.Conflict("agent.tool.duplicated", "A tool já está na allowlist do agente."));
        }

        ToolList.Add(toolName.Trim());
        return Result.Success();
    }

    public Result RevokeTool(string toolName)
    {
        var removed = ToolList.Remove(toolName.Trim());
        return removed
            ? Result.Success()
            : Result.Failure(Error.NotFound("agent.tool.not-found", "A tool não está na allowlist do agente."));
    }

    public Result AttachPrompt(string promptName)
    {
        if (string.IsNullOrWhiteSpace(promptName))
        {
            return Result.Failure(Error.Validation("agent.prompt.required", "Nome do prompt é obrigatório."));
        }

        if (PromptNames.Contains(promptName.Trim(), StringComparer.OrdinalIgnoreCase))
        {
            return Result.Failure(Error.Conflict("agent.prompt.duplicated", "O prompt já está anexado ao agente."));
        }

        PromptList.Add(promptName.Trim());
        return Result.Success();
    }

    /// <summary>
    /// Marks every action of this agent as Human-in-the-loop. Enabling this is the
    /// ONLY way a sensitive AI action can be allowed to run without immediate
    /// execution - there is no implicit bypass.
    /// </summary>
    public Result RequireHumanApproval(bool required)
    {
        RequiresHumanApproval = required;
        return Result.Success();
    }

    public Result Activate()
    {
        if (Status == AgentStatus.Active)
        {
            return Result.Failure(Error.Conflict("agent.already.active", "O agente já está ativo."));
        }

        if (ToolNames.Count == 0)
        {
            return Result.Failure(Error.Conflict("agent.no-tools", "Um agente precisa de ao menos uma tool autorizada antes de ser ativado."));
        }

        Status = AgentStatus.Active;
        RaiseDomainEvent(new AgentActivatedEvent(Id, Name));
        return Result.Success();
    }

    public Result Disable()
    {
        if (Status == AgentStatus.Disabled)
        {
            return Result.Failure(Error.Conflict("agent.already.disabled", "O agente já está desabilitado."));
        }

        Status = AgentStatus.Disabled;
        return Result.Success();
    }

    public void AddSeededTool(string toolName)
    {
        if (!ToolNames.Contains(toolName, StringComparer.OrdinalIgnoreCase))
        {
            ToolList.Add(toolName);
        }
    }

    public void AddSeededPrompt(string promptName)
    {
        if (!PromptNames.Contains(promptName, StringComparer.OrdinalIgnoreCase))
        {
            PromptList.Add(promptName);
        }
    }

    public void SetSeededModelSettings(string json) => ModelSettingsJson = json;
}

/// <summary>
/// AiToolDefinition is the registry entry a Tool must be published under before
/// any agent is allowed to call it. The required permission is stored here, which
/// means the authorization check lives next to the capability, not in a prompt.
/// </summary>
public sealed class AiToolDefinition : AggregateRoot
{
    private AiToolDefinition()
    {
    }

    private AiToolDefinition(Guid id, string name, string description, string requiredPermission, bool isReadOnly, string inputSchemaJson)
    {
        Id = id;
        Name = name;
        Description = description;
        RequiredPermission = requiredPermission;
        IsReadOnly = isReadOnly;
        InputSchemaJson = inputSchemaJson;
        Status = AgentStatus.Active;
    }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    /// <summary>IAM permission the CALLER must hold, e.g. "content.read".</summary>
    public string RequiredPermission { get; private set; } = string.Empty;

    public bool IsReadOnly { get; private set; }

    public string InputSchemaJson { get; private set; } = "{}";

    public AgentStatus Status { get; private set; }

    /// <summary>False means calling this Tool always requires an explicit human approval.</summary>
    public bool RequiresApproval { get; private set; }

    public static Result<AiToolDefinition> Create(
        string name,
        string description,
        string requiredPermission,
        bool isReadOnly,
        string inputSchemaJson)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<AiToolDefinition>(Error.Validation("tool.name.required", "Nome da tool é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(requiredPermission))
        {
            return Result.Failure<AiToolDefinition>(Error.Validation("tool.permission.required", "Toda tool precisa de uma permissão de IAM associada."));
        }

        if (!Identity.Permissions.Exists(requiredPermission))
        {
            return Result.Failure<AiToolDefinition>(
                Error.Validation("tool.permission.unknown", $"A permissão '{requiredPermission}' não existe no catálogo de permissões."));
        }

        return Result.Success(new AiToolDefinition(
            Guid.NewGuid(),
            name.Trim(),
            description?.Trim() ?? string.Empty,
            requiredPermission.Trim(),
            isReadOnly,
            inputSchemaJson ?? "{}"));
    }

    public Result RequireApproval(bool required)
    {
        RequiresApproval = required;
        return Result.Success();
    }

    public Result ChangeStatus(AgentStatus status)
    {
        Status = status;
        return Result.Success();
    }

    public static AiToolDefinition CreateSeeded(
        string name,
        string description,
        string requiredPermission,
        bool isReadOnly,
        string inputSchemaJson,
        bool requiresApproval)
        => new(Guid.NewGuid(), name, description, requiredPermission, isReadOnly, inputSchemaJson)
        {
            RequiresApproval = requiresApproval
        };
}

/// <summary>
/// Prompt is a versioned prompt template managed in the platform instead of
/// being hardcoded in code. <see cref="TemplateVersion"/> is bumped on every change so an
/// execution can always point at the exact prompt that produced it.
/// </summary>
public sealed class AiPrompt : AggregateRoot
{
    private AiPrompt()
    {
    }

    private AiPrompt(Guid id, string name, string template, string description, Guid? organizationId)
    {
        Id = id;
        Name = name;
        Template = template;
        Description = description;
        OrganizationId = organizationId;
        TemplateVersion = 1;
    }

    public string Name { get; private set; } = string.Empty;

    public string Template { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public int TemplateVersion { get; private set; }

    public bool IsActive { get; private set; } = true;

    public Guid? OrganizationId { get; private set; }

    public static Result<AiPrompt> Create(string name, string template, string description, Guid? organizationId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<AiPrompt>(Error.Validation("prompt.name.required", "Nome do prompt é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(template))
        {
            return Result.Failure<AiPrompt>(Error.Validation("prompt.template.required", "Template do prompt é obrigatório."));
        }

        return Result.Success(new AiPrompt(Guid.NewGuid(), name.Trim(), template, description?.Trim() ?? string.Empty, organizationId));
    }

    public Result UpdateTemplate(string template)
    {
        if (string.IsNullOrWhiteSpace(template))
        {
            return Result.Failure(Error.Validation("prompt.template.required", "Template do prompt é obrigatório."));
        }

        Template = template;
        TemplateVersion++;
        return Result.Success();
    }

    public Result Activate()
    {
        IsActive = true;
        return Result.Success();
    }

    public Result Deactivate()
    {
        IsActive = false;
        return Result.Success();
    }

    public static AiPrompt CreateSeeded(string name, string template, string description, int version, bool isActive, Guid? organizationId)
        => new(Guid.NewGuid(), name, template, description, organizationId) { TemplateVersion = version, IsActive = isActive };
}

public sealed record AgentActivatedEvent(Guid AgentId, string AgentName) : DomainEventBase(AgentId)
{
    public override string EventName => "ai.agent.activated";
}