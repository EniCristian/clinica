using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Services;
using Clinica.Common.Exceptions;
using Clinica.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.ApplicationUsers.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<Tokens>
{
    public Tokens OldToken { get; set; }
}

public class RefreshTokenCommandHandler(
    IApplicationUsersRepository applicationUsersRepository,
    IApplicationDbContext applicationDbContext,
    IJWTManagerRepository jWtManagerRepository,
    IDateTimeService dateTimeService) : IRequestHandler<RefreshTokenCommand, Tokens>
{
    public async Task<Tokens> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var principal = jWtManagerRepository.GetPrincipalFromExpiredToken(command.OldToken.AccessToken);
        var username = principal.Identity?.Name!;
        var user = await applicationUsersRepository.GetUser(username);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        var savedToken = await applicationDbContext.Tokens.FirstOrDefaultAsync(t => t.Username == username && t.RefreshToken == command.OldToken.RefreshToken && t.Expiration > dateTimeService.NowUtc, cancellationToken: cancellationToken);
        if (savedToken == null)
        {
            throw new NotAuthorizedException("Invalid token");
        }

        var newJwtToken = jWtManagerRepository.GenerateRefreshToken(user);
        savedToken.RefreshToken = newJwtToken.RefreshToken;
        applicationDbContext.Tokens.Update(savedToken);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
        return newJwtToken;
    }
}