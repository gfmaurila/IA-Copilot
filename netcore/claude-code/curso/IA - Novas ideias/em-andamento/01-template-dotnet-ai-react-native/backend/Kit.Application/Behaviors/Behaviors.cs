using FluentValidation;
using Kit.Application.Abstractions.Messaging;
using Kit.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Kit.Application.Behaviors;

/// <summary>
/// Runs every registered FluentValidation validator for the message before it
/// reaches a handler. Invalid input never enters the Application layer.
/// </summary>
public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        var results = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = results
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToArray();

        if (failures.Length == 0)
        {
            return await next();
        }

        var error = new Error(
            "validation.failed",
            string.Join("; ", failures.Select(f => $"{f.PropertyName}: {f.ErrorMessage}")),
            ErrorType.Validation);

        return ResultFactory.Failure<TResponse>(error);
    }
}

/// <summary>
/// Logs every Command and Query with its duration and outcome. Message payloads
/// are NOT logged by default: they may contain PII or secrets.
/// </summary>
public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = typeof(TRequest).Name;
        _logger.LogInformation("Handling {MessageName}", name);

        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            var response = await next();
            stopwatch.Stop();
            _logger.LogInformation("Handled {MessageName} in {ElapsedMs}ms", name, stopwatch.ElapsedMilliseconds);
            return response;
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _logger.LogError(ex, "Unhandled exception while handling {MessageName} after {ElapsedMs}ms", name, stopwatch.ElapsedMilliseconds);
            throw;
        }
    }
}

/// <summary>
/// Wraps every Command in a single Unit of Work so a use case either commits
/// completely or not at all.
/// The Unit of Work implementation is responsible for collecting the Domain
/// Events raised by the tracked Aggregate Roots and publishing them ONLY after a
/// successful commit - this behavior never publishes events itself.
/// </summary>
public sealed class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommandMarker
{
    private readonly Domain.Abstractions.IUnitOfWork _unitOfWork;
    private readonly ILogger<UnitOfWorkBehavior<TRequest, TResponse>> _logger;

    public UnitOfWorkBehavior(
        Domain.Abstractions.IUnitOfWork unitOfWork,
        ILogger<UnitOfWorkBehavior<TRequest, TResponse>> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();

        if (response is Result result && result.IsFailure)
        {
            // Nothing was saved, but the handler may already have staged entities
            // in the Change Tracker. Drop them so a later command in the same
            // scope can never commit the work of a failed one.
            _unitOfWork.DiscardChanges();
            _logger.LogInformation(
                "Unit of Work rolled back for {MessageName}: {ErrorCode}",
                typeof(TRequest).Name,
                result.Error.Code);
            return response;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return response;
    }
}

/// <summary>
/// Bridges the untyped <see cref="Result"/> hierarchy back into the strongly
/// typed MediatR response of a behavior.
/// </summary>
internal static class ResultFactory
{
    public static TOut Failure<TOut>(Error error)
    {
        var responseType = typeof(TOut);

        if (responseType == typeof(Result))
        {
            return (TOut)(object)Result.Failure(error);
        }

        if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Result<>))
        {
            var valueType = responseType.GetGenericArguments()[0];
            var failureMethod = typeof(Result)
                .GetMethod(nameof(Result.Failure), 1, [typeof(Error)])!
                .MakeGenericMethod(valueType);

            return (TOut)failureMethod.Invoke(null, [error])!;
        }

        throw new InvalidOperationException($"Não foi possível converter uma falha para '{responseType.Name}'.");
    }
}