using Kit.Application.Abstractions.Messaging;
using Kit.Application.Abstractions.Repositories;
using Kit.Application.Abstractions.Security;
using Kit.Domain.Abstractions;
using Kit.Domain.Common;
using Kit.Domain.Modules.Identity;
using MediatR;

namespace Kit.Application.Modules.Identity.Auth;

public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserPermissionReader _permissionReader;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;
    private readonly IClock _clock;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IUserPermissionReader permissionReader,
        IPasswordHasher passwordHasher,
        ITokenService tokenService,
        IClock clock)
    {
        _userRepository = userRepository;
        _permissionReader = permissionReader;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
        _clock = clock;
    }

    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure)
        {
            return Result.Failure<LoginResponse>(emailResult.Error);
        }

        var user = await FindByEmailAsync(emailResult.Value.Value, cancellationToken);
        if (user is null)
        {
            // Deliberately generic: never reveal whether the e-mail exists.
            return Result.Failure<LoginResponse>(Error.Unauthorized("auth.invalid-credentials", "Credenciais inválidas."));
        }

        if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
        {
            return Result.Failure<LoginResponse>(Error.Unauthorized("auth.invalid-credentials", "Credenciais inválidas."));
        }

        if (user.Status == UserStatus.Blocked)
        {
            return Result.Failure<LoginResponse>(Error.Forbidden("auth.user.blocked", "Usuário bloqueado."));
        }

        if (user.Status == UserStatus.Inactive)
        {
            return Result.Failure<LoginResponse>(Error.Forbidden("auth.user.inactive", "Usuário inativo."));
        }

        var roles = await _permissionReader.GetRolesAsync(user.Id, cancellationToken);
        var permissions = await _permissionReader.GetPermissionsAsync(user.Id, cancellationToken);

        var tokenPair = _tokenService.IssueAccessToken(user, roles, permissions);
        var refreshToken = _tokenService.CreateRefreshToken();

        var sessionResult = user.RegisterSession(
            _tokenService.HashToken(refreshToken),
            null,
            null,
            tokenPair.RefreshTokenExpiresAtUtc);

        if (sessionResult.IsFailure)
        {
            return Result.Failure<LoginResponse>(sessionResult.Error);
        }

        _userRepository.Update(user);

        var profile = new UserProfileResponse(
            user.Id,
            user.OrganizationId,
            user.FirstName,
            user.LastName,
            user.FullName,
            user.Email.Value,
            user.JobTitle,
            roles,
            permissions);

        return Result.Success(new LoginResponse(
            tokenPair.AccessToken,
            tokenPair.RefreshToken,
            tokenPair.AccessTokenExpiresAtUtc,
            tokenPair.RefreshTokenExpiresAtUtc,
            profile));
    }

    private async Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken)
        => await _userRepository.FindByEmailAsync(email, cancellationToken);
}