using FluentValidation;
using Kit.Application.Abstractions.Messaging;

namespace Kit.Application.Modules.Identity.Auth;

public sealed record LoginCommand(string Email, string Password) : ICommand<LoginResponse>;

public sealed record LoginResponse(
    string AccessToken,
    string RefreshToken,
    DateTime AccessTokenExpiresAtUtc,
    DateTime RefreshTokenExpiresAtUtc,
    UserProfileResponse Profile);

public sealed record UserProfileResponse(
    Guid Id,
    Guid OrganizationId,
    string FirstName,
    string LastName,
    string FullName,
    string Email,
    string? JobTitle,
    IReadOnlyCollection<string> Roles,
    IReadOnlyCollection<string> Permissions);

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-mail é obrigatório.")
            .EmailAddress().WithMessage("E-mail inválido.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha é obrigatória.")
            .MinimumLength(8).WithMessage("A senha deve ter ao menos 8 caracteres.");
    }
}