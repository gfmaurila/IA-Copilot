using System.Text.RegularExpressions;

namespace Kit.Domain.Common;

/// <summary>
/// Shared primitive value objects used across modules.
/// These are intentionally free of module semantics: a rule that only makes
/// sense for one module belongs in that module.
/// </summary>
public sealed partial class Email : ValueObject
{
    private Email(string value) => Value = value;

    public string Value { get; }

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.CultureInvariant)]
    private static partial Regex EmailPattern();

    public static Result<Email> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<Email>(Error.Validation("email.required", "E-mail é obrigatório."));
        }

        var normalized = value.Trim().ToLowerInvariant();

        if (!EmailPattern().IsMatch(normalized))
        {
            return Result.Failure<Email>(Error.Validation("email.invalid", $"E-mail inválido: {value}"));
        }

        return Result.Success(new Email(normalized));
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}

public sealed partial class Slug : ValueObject
{
    private Slug(string value) => Value = value;

    public string Value { get; }

    [GeneratedRegex("^[a-z0-9]+(?:-[a-z0-9]+)*$", RegexOptions.CultureInvariant)]
    private static partial Regex SlugPattern();

    public static Result<Slug> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<Slug>(Error.Validation("slug.required", "Slug é obrigatório."));
        }

        var normalized = value.Trim().ToLowerInvariant();

        if (!SlugPattern().IsMatch(normalized))
        {
            return Result.Failure<Slug>(Error.Validation("slug.invalid", $"Slug inválido: {value}"));
        }

        return Result.Success(new Slug(normalized));
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}