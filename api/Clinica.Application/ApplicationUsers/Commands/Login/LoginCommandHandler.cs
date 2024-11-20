using Clinica.Application.Common.Interfaces;
using Clinica.Common.Exceptions;
using Clinica.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.ApplicationUsers.Commands.Login;

public class LoginCommand : IRequest<Tokens>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool RememberMe { get; set; }
}

public class LoginCommandHandler(
    IApplicationUsersRepository applicationUsersRepository,
    IJWTManagerRepository jwtManagerRepository,
    IApplicationDbContext dbContext) : IRequestHandler<LoginCommand, Tokens>
{
    public async Task<Tokens> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await applicationUsersRepository.GetUser(command.Email);
        if (user == null)
        {
            throw new NotAuthorizedException($"User {command.Email} not found");
        }
        var isValidPassword = await applicationUsersRepository.IsValidUserAsync(command.Email, command.Password);
        if (!isValidPassword)
        {
            throw new NotAuthorizedException("Invalid password");
        }
        var tokens = jwtManagerRepository.GenerateToken(user);
        var existingToken = await dbContext.Tokens.FirstOrDefaultAsync(t => t.Username == user.Email, cancellationToken: cancellationToken);
        if (existingToken != null)
        {
            dbContext.Tokens.Remove(existingToken);
        }
        dbContext.Tokens.Add(new Token
        {
            Id = Guid.NewGuid(),
            Expiration =  DateTime.UtcNow.AddHours(24),
            Username = user.Email,
            RefreshToken = tokens.RefreshToken
        });

        await dbContext.SaveChangesAsync(cancellationToken);

        return tokens;
    }
}