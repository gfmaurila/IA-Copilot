using Kit.Domain.Common;
using MediatR;

namespace Kit.Application.Abstractions.Messaging;

/// <summary>
/// Write intent. Commands are the ONLY way state changes in this platform -
/// there is no second path from an endpoint straight to a repository.
///
/// The marker is separate from the MediatR contract on purpose: the Unit of
/// Work pipeline behavior must apply to EVERY command, including the ones with a
/// typed response, which it could not do if it depended on the response shape.
/// </summary>
public interface ICommandMarker;

public interface ICommand : IRequest<Result>, ICommandMarker;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, ICommandMarker;

/// <summary>
/// Marker for every read intent. Queries never mutate state.
/// </summary>
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;