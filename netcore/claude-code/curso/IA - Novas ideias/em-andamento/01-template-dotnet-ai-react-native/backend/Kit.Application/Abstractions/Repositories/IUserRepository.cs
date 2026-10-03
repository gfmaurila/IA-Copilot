using Kit.Application.Abstractions.Repositories;
using Kit.Domain.Abstractions;
using Kit.Domain.Modules.Identity;

namespace Kit.Application.Abstractions.Repositories;

/// <summary>
/// User read/aggregate repository PORT. Declared in Application and implemented in
/// Infrastructure, so handlers never depend on EF Core.
/// </summary>
public interface IUserRepository : IRepository<User>
{
    Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(string email, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<User>> ListByOrganizationAsync(Guid organizationId, CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);
}