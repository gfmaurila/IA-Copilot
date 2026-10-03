using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Kit.CrossCutting.FeatureFlags;

/// <summary>
/// Module switches (prompts.md §26).
///
/// SECURITY RULE: a disabled module must be absent from the composition root, not
/// merely hidden. Turning a flag off can never widen access, and there is no code
/// path where a flag bypasses an authorization check.
/// </summary>
public sealed class FeatureFlagsOptions
{
    public const string SectionName = "FeatureFlags";

    public bool Identity { get; set; } = true;

    public bool Audit { get; set; } = true;

    public bool Notifications { get; set; } = true;

    public bool Content { get; set; } = false;

    public bool Media { get; set; } = false;

    public bool Navigation { get; set; } = false;

    public bool Ai { get; set; } = false;

    public bool Rag { get; set; } = false;

    public bool MultiTenant { get; set; } = false;
}

public interface IFeatureFlagReader
{
    bool IsEnabled(string module);

    IReadOnlyList<string> EnabledModules();
}

public sealed class FeatureFlagReader(IOptionsMonitor<FeatureFlagsOptions> options) : IFeatureFlagReader
{
    private static readonly IReadOnlyList<string> KnownModules =
    [
        nameof(FeatureFlagsOptions.Identity),
        nameof(FeatureFlagsOptions.Audit),
        nameof(FeatureFlagsOptions.Notifications),
        nameof(FeatureFlagsOptions.Content),
        nameof(FeatureFlagsOptions.Media),
        nameof(FeatureFlagsOptions.Navigation),
        nameof(FeatureFlagsOptions.Ai),
        nameof(FeatureFlagsOptions.Rag),
        nameof(FeatureFlagsOptions.MultiTenant)
    ];

    public bool IsEnabled(string module)
    {
        var value = options.CurrentValue;
        return module switch
        {
            nameof(FeatureFlagsOptions.Identity) => value.Identity,
            nameof(FeatureFlagsOptions.Audit) => value.Audit,
            nameof(FeatureFlagsOptions.Notifications) => value.Notifications,
            nameof(FeatureFlagsOptions.Content) => value.Content,
            nameof(FeatureFlagsOptions.Media) => value.Media,
            nameof(FeatureFlagsOptions.Navigation) => value.Navigation,
            nameof(FeatureFlagsOptions.Ai) => value.Ai,
            nameof(FeatureFlagsOptions.Rag) => value.Rag,
            nameof(FeatureFlagsOptions.MultiTenant) => value.MultiTenant,
            _ => false
        };
    }

    public IReadOnlyList<string> EnabledModules() => KnownModules.Where(IsEnabled).ToList();
}