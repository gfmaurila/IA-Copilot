namespace Kit.CrossCutting.Time;

/// <summary>
/// Per-request correlation/trace id. Set by the API middleware and consumed by
/// Serilog, audit entries and AI runs so a single user action can be followed
/// across the whole Modular Monolith.
/// </summary>
public interface ICorrelationIdAccessor
{
    string? CorrelationId { get; }

    void Set(string correlationId);

    IDisposable BeginScope(string correlationId);
}

public sealed class CorrelationIdAccessor : ICorrelationIdAccessor
{
    private readonly AsyncLocal<string?> _holder = new();

    public string? CorrelationId => _holder.Value;

    public void Set(string correlationId) => _holder.Value = correlationId;

    public IDisposable BeginScope(string correlationId)
    {
        var previous = _holder.Value;
        _holder.Value = correlationId;
        return new Scope(() => _holder.Value = previous);
    }

    private sealed class Scope(Action onDispose) : IDisposable
    {
        private Action? _onDispose = onDispose;

        public void Dispose()
        {
            var action = Interlocked.Exchange(ref _onDispose, null);
            action?.Invoke();
        }
    }
}

/// <summary>
/// Ambient per-request context, used to avoid threading the correlation id
/// through every Application signature.
/// </summary>
public interface IRequestContextAccessor
{
    RequestContext? Current { get; set; }
}

public sealed record RequestContext(string CorrelationId, Guid? UserId, Guid? OrganizationId, string? IpAddress);

public sealed class RequestContextAccessor : IRequestContextAccessor
{
    private readonly AsyncLocal<RequestContext?> _holder = new();

    public RequestContext? Current
    {
        get => _holder.Value;
        set => _holder.Value = value;
    }
}