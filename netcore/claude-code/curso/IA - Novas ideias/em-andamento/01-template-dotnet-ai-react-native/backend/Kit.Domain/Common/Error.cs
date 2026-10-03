namespace Kit.Domain.Common;

/// <summary>
/// A domain error. Errors are values, not exceptions: business failures must
/// be returned, not thrown, so callers are forced to handle them.
/// </summary>
public sealed record Error(string Code, string Message, ErrorType Type = ErrorType.Failure)
{
    public static Error None => new(string.Empty, string.Empty, ErrorType.None);

    public static Error Failure(string code, string message) => new(code, message);

    public static Error Validation(string code, string message) => new(code, message, ErrorType.Validation);

    public static Error NotFound(string code, string message) => new(code, message, ErrorType.NotFound);

    public static Error Conflict(string code, string message) => new(code, message, ErrorType.Conflict);

    public static Error Forbidden(string code, string message) => new(code, message, ErrorType.Forbidden);

    public static Error Unauthorized(string code, string message) => new(code, message, ErrorType.Unauthorized);
}

public enum ErrorType
{
    None = 0,
    Failure = 1,
    Validation = 2,
    NotFound = 3,
    Conflict = 4,
    Forbidden = 5,
    Unauthorized = 6
}