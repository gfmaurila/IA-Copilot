using Kit.Domain.Common;

namespace Kit.Domain.Modules.Identity;

/// <summary>
/// Session + RefreshToken + ApiKey live inside the User Aggregate because their
/// whole lifecycle is owned by the User. This is what makes it impossible to
/// issue a refresh token for a blocked user from outside the aggregate.
/// </summary>
public sealed class Session : Entity
{
    private readonly List<RefreshToken> _refreshTokens = [];

    private Session()
    {
    }

    private Session(Guid id, Guid userId, string tokenHash, string? ipAddress, string? userAgent, DateTime startedAtUtc, DateTime expiresAtUtc)
    {
        Id = id;
        UserId = userId;
        TokenHash = tokenHash;
        IpAddress = ipAddress;
        UserAgent = userAgent;
        StartedAtUtc = startedAtUtc;
        ExpiresAtUtc = expiresAtUtc;
        Status = SessionStatus.Active;
        Expires();
    }

    public Guid UserId { get; private set; }

    public string TokenHash { get; private set; } = string.Empty;

    public string? IpAddress { get; private set; }

    public string? UserAgent { get; private set; }

    public DateTime StartedAtUtc { get; private set; }

    public DateTime ExpiresAtUtc { get; private set; }

    public DateTime? EndedAtUtc { get; private set; }

    public SessionStatus Status { get; private set; }

    public string? EndReason { get; private set; }

    public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

    public bool IsActive(DateTime utcNow) => Status == SessionStatus.Active && ExpiresAtUtc > utcNow;

    internal static Session Start(Guid userId, string tokenHash, string? ipAddress, string? userAgent, DateTime expiresAtUtc)
    {
        var session = new Session(
            Guid.NewGuid(),
            userId,
            tokenHash,
            ipAddress,
            userAgent,
            DateTime.UtcNow,
            expiresAtUtc);

        return session;
    }

    /// <summary>
    /// Internal factory used exclusively by the seeders so Demo data can contain
    /// already-expired and already-revoked sessions on purpose.
    /// </summary>
    public static Session CreateSeeded(
        Guid userId,
        string tokenHash,
        DateTime startedAtUtc,
        DateTime expiresAtUtc,
        SessionStatus status,
        string? ipAddress = null,
        string? userAgent = null,
        string? endReason = null)
    {
        var session = new Session(
            Guid.NewGuid(),
            userId,
            tokenHash,
            ipAddress,
            userAgent,
            startedAtUtc,
            expiresAtUtc)
        {
            Status = status
        };

        if (status != SessionStatus.Active)
        {
            session.EndedAtUtc = expiresAtUtc;
            session.EndReason = endReason ?? status.ToString().ToLowerInvariant();
        }

        return session;
    }

    internal Result Revoke(string reason)
    {
        if (Status == SessionStatus.Revoked)
        {
            return Result.Failure(Error.Conflict("session.already.revoked", "A sessão já está revogada."));
        }

        Status = SessionStatus.Revoked;
        EndedAtUtc = DateTime.UtcNow;
        EndReason = reason;
        return Result.Success();
    }

    internal Result IssueRefreshToken(string tokenHash, DateTime expiresAtUtc)
    {
        if (Status != SessionStatus.Active)
        {
            return Result.Failure(Error.Forbidden("session.not-active", "Somente sessões ativas podem emitir refresh tokens."));
        }

        if (ExpiresAtUtc <= DateTime.UtcNow)
        {
            return Result.Failure(Error.Forbidden("session.expired", "A sessão expirou."));
        }

        var token = RefreshToken.Create(Id, tokenHash, expiresAtUtc);
        _refreshTokens.Add(token);
        return Result.Success(token);
    }

    public void AddSeededRefreshToken(RefreshToken token) => _refreshTokens.Add(token);

    private void Expires()
    {
        if (ExpiresAtUtc <= DateTime.UtcNow)
        {
            Status = SessionStatus.Expired;
        }
    }
}

public sealed class RefreshToken : Entity
{
    private RefreshToken()
    {
    }

    private RefreshToken(Guid id, Guid sessionId, string tokenHash, DateTime expiresAtUtc)
    {
        Id = id;
        SessionId = sessionId;
        TokenHash = tokenHash;
        ExpiresAtUtc = expiresAtUtc;
        Status = SessionStatus.Active;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public Guid SessionId { get; private set; }

    /// <summary>Only the hash is stored. A leaked database cannot be replayed.</summary>
    public string TokenHash { get; private set; } = string.Empty;

    public DateTime CreatedAtUtc { get; private set; }

    public DateTime ExpiresAtUtc { get; private set; }

    public DateTime? RevokedAtUtc { get; private set; }

    public SessionStatus Status { get; private set; }

    public bool IsValid(DateTime utcNow) => Status == SessionStatus.Active && ExpiresAtUtc > utcNow && RevokedAtUtc is null;

    internal static RefreshToken Create(Guid sessionId, string tokenHash, DateTime expiresAtUtc) =>
        new(Guid.NewGuid(), sessionId, tokenHash, expiresAtUtc);

    public static RefreshToken CreateSeeded(Guid sessionId, string tokenHash, DateTime createdAtUtc, DateTime expiresAtUtc, SessionStatus status)
    {
        var token = new RefreshToken(Guid.NewGuid(), sessionId, tokenHash, expiresAtUtc) { Status = status };
        token.CreatedAtUtc = createdAtUtc;

        if (status != SessionStatus.Active)
        {
            token.RevokedAtUtc = expiresAtUtc;
        }

        return token;
    }

    internal Result Revoke()
    {
        if (Status != SessionStatus.Active)
        {
            return Result.Failure(Error.Conflict("refresh-token.not-active", "Refresh token não está ativo."));
        }

        Status = SessionStatus.Revoked;
        RevokedAtUtc = DateTime.UtcNow;
        return Result.Success();
    }
}

/// <summary>
/// ApiKey authenticates machine-to-machine calls. It belongs to the User
/// Aggregate so it is revoked together with the owner. The full key is shown
/// exactly once; only its hash is persisted.
/// </summary>
public sealed class ApiKey : Entity
{
    private ApiKey()
    {
    }

    public Guid UserId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Prefix { get; private set; } = string.Empty;

    public string KeyHash { get; private set; } = string.Empty;

    public DateTime ExpiresAtUtc { get; private set; }

    public DateTime? LastUsedAtUtc { get; private set; }

    public DateTime? RevokedAtUtc { get; private set; }

    public bool IsActive(DateTime utcNow) => RevokedAtUtc is null && ExpiresAtUtc > utcNow;

    public static Result<ApiKey> Create(Guid userId, string name, string prefix, string keyHash, DateTime expiresAtUtc)
    {
        if (userId == Guid.Empty)
        {
            return Result.Failure<ApiKey>(Error.Validation("api-key.user.required", "ApiKey deve pertencer a um usuário."));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<ApiKey>(Error.Validation("api-key.name.required", "Nome da ApiKey é obrigatório."));
        }

        return Result.Success(new ApiKey
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Name = name.Trim(),
            Prefix = prefix,
            KeyHash = keyHash,
            ExpiresAtUtc = expiresAtUtc
        });
    }

    internal Result Revoke()
    {
        if (RevokedAtUtc is not null)
        {
            return Result.Failure(Error.Conflict("api-key.already.revoked", "ApiKey já está revogada."));
        }

        RevokedAtUtc = DateTime.UtcNow;
        return Result.Success();
    }

    internal void MarkUsed(DateTime utcNow) => LastUsedAtUtc = utcNow;
}