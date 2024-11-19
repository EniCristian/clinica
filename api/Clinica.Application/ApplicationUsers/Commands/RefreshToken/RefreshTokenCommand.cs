using Clinica.Application.Common.Interfaces;
using Clinica.Domain.Entities;
using MediatR;

namespace Clinica.Application.ApplicationUsers.Commands.RefreshToken;
public class RefreshTokenCommand: IRequest<Tokens>
{
}

public class RefreshTokenCommandHandler(
    IAuthenticator applicationUsersRepository,
    IApplicationDbContext applicationDbContext,
    IJWTManagerRepository jWtManagerRepository) : IRequestHandler<RefreshTokenCommand, Tokens>
{
    public async Task<Tokens> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var token = jWtManagerRepository.GetPrincipalFromExpiredToken(command.OldToken.AccessToken);
        var principal = jWtManagerRepository.GetPrincipalFromExpiredToken(command.OldToken.AccessToken);
        var username = principal.Identity?.Name;

        var savedRefreshToken = applicationUsersRepository.RefreshToken(username, command.OldToken.RefreshToken);

        if (savedRefreshToken.RefreshToken != command.OldToken.RefreshToken)
        {
            throw new ArgumentException("Invalid refresh token.");
        }

        var newJwtToken = jWtManagerRepository.GenerateRefreshToken(username);

        if (newJwtToken == null)
        {
            throw new ArgumentException("Failed to generate jwt token.");
        }

        UserRefreshTokens obj = new UserRefreshTokens
        {
            RefreshToken = newJwtToken.RefreshToken,
            Email = username
        };

        await applicationUsersRepository.DeleteUserRefreshTokens(username, command.OldToken.RefreshToken);
        applicationUsersRepository.AddUserRefreshTokens(obj);

        return newJwtToken;
    }
}
