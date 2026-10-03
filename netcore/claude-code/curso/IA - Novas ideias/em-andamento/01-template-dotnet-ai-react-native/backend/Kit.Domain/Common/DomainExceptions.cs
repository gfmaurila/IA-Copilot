namespace Kit.Domain.Common;

/// <summary>
/// Base class for Domain Notifications - the non-blocking validations an
/// aggregate reports after it was successfully created. Invalid data never
/// prevents persistence; it must be surfaced to the user afterwards.
/// </summary>
public interface IDomainNotification
{
    string Code { get; }

    string Message { get; }
}

/// <summary>
/// Base class for Domain Validations - the blocking validations that reject an
/// operation outright. They are expressed as assertions inside the aggregate so
/// the invariant cannot be violated from any entry point.
/// </summary>
public interface IDomainValidation
{
    string Code { get; }

    string Message { get; }
}

/// <summary>
/// Raised when a blocking Domain Validation fails. This is a programming/domain
/// contract violation, not an expected business outcome - business failures use
/// <see cref="Result"/> instead.
/// </summary>
public class DomainValidationException : Exception
{
    public DomainValidationException(IDomainValidation validation)
        : base($"{validation.Code}: {validation.Message}")
    {
        Validation = validation;
    }

    public IDomainValidation Validation { get; }
}

/// <summary>
/// Raised when an aggregate is asked to perform an operation its current state
/// does not allow (invalid state transition).
/// </summary>
public class DomainRuleException : Exception
{
    public DomainRuleException(string code, string message)
        : base($"{code}: {message}")
    {
        Code = code;
    }

    public string Code { get; }
}