namespace Kit.Infrastructure.Options;

public sealed class DatabaseOptions
{
    public const string SectionName = "Database";

    /// <summary>
    /// MySQL 8.x is the default provider. The connection string is NEVER stored in
    /// appsettings: it is built from environment variables / user-secrets and is
    /// only allowed to be absent when the host supplies it at runtime.
    /// </summary>
    public string Provider { get; set; } = "MySql";

    public string? ConnectionString { get; set; }

    public string Server { get; set; } = "localhost";

    public int Port { get; set; } = 3306;

    public string Database { get; set; } = "kit_db";

    public string User { get; set; } = "kit_user";

    public string Password { get; set; } = string.Empty;

    public bool EnableSensitiveDataLogging { get; set; }

    public bool EnableRetryOnFailure { get; set; } = true;

    /// <summary>Number of transient-fault retries. 0 disables the resilience pipeline.</summary>
    public int MaxRetryCount { get; set; } = 5;

    public int CommandTimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Applies pending migrations on startup. Acceptable for DEV only - the API
    /// refuses to auto-migrate when the environment is Production.
    /// </summary>
    public bool AutoMigrate { get; set; }

    public string BuildConnectionString()
    {
        if (!string.IsNullOrWhiteSpace(ConnectionString))
        {
            return ConnectionString;
        }

        // Connection keywords are MySql.Data (Oracle provider). No password is ever
        // stored in appsettings: it arrives from env vars / user-secrets / compose.
        return $"Server={Server};Port={Port};Database={Database};User ID={User};Password={Password};" +
               "TreatTinyAsBoolean=true;SslMode=Preferred;Connection Timeout=30;";
    }
}

public sealed class RedisOptions
{
    public const string SectionName = "Redis";

    public bool Enabled { get; set; }

    public string? ConnectionString { get; set; } = "localhost:6379";

    public string? InstanceName { get; set; } = "kit:";
}

public sealed class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Issuer { get; set; } = "Kit.Api";

    public string Audience { get; set; } = "Kit.Web";

    public int AccessTokenMinutes { get; set; } = 60;

    public int RefreshTokenDays { get; set; } = 7;

    /// <summary>
    /// Signing key. MUST come from configuration/env/user-secrets. There is no
    /// default and no fallback: the API fails to start without it outside of
    /// Development, where the Development-only value is still required.
    /// </summary>
    public string? SigningKey { get; set; }
}

public sealed class SeedOptions
{
    public const string SectionName = "Seed";

    /// <summary>Minimal | Demo | Stress | None</summary>
    public string Mode { get; set; } = "Minimal";

    /// <summary>
    /// Hard safety switch. Development seeders refuse to run in Production even
    /// if Mode is Demo or Stress.
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>Fixed random seed so Demo/Stress data is byte-for-byte reproducible.</summary>
    public int RandomSeed { get; set; } = 20260101;

    /// <summary>Password used for every deterministic demo account. Sourced from env/user-secrets.</summary>
    public string? DemoUserPassword { get; set; }
}

public sealed class AiOptions
{
    public const string SectionName = "Ai";

    public bool Enabled { get; set; }

    public string Provider { get; set; } = "none";

    public string ChatModel { get; set; } = string.Empty;

    public string EmbeddingModel { get; set; } = string.Empty;

    /// <summary>API key comes from env/user-secrets. Never persisted.</summary>
    public string? ApiKey { get; set; }

    public int MaxToolCallsPerExecution { get; set; } = 8;

    public int MaxContextTokens { get; set; } = 32000;

    public bool RequireHumanApprovalForWrites { get; set; } = true;
}

public sealed class MessagingOptions
{
    public const string SectionName = "Messaging";

    public bool Enabled { get; set; }

    public string? BootstrapServers { get; set; } = "localhost:9092";

    public string TopicPrefix { get; set; } = "kit";

    public string ConsumerGroup { get; set; } = "kit-consumer";
}

public sealed class CORSOptions
{
    public const string SectionName = "Cors";

    public string[] AllowedOrigins { get; set; } = ["http://localhost:5173"];
}