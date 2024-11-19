using Clinica.Application.Common.Interfaces;
using Clinica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Infrastructure.Identity;

public class TokenService(IApplicationDbContext context) : ITokenService
{
    public async Task<Token> Add(ApplicationUser user, string value, TokenType type, CancellationToken cancellationToken = default)
    {
        var oldToken = await context.Tokens.FirstOrDefaultAsync(t => t.User == user && t.Type == type, cancellationToken);
        if (oldToken != null)
        {
            context.Tokens.Remove(oldToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        var expiration = DateTime.UtcNow.AddHours(24);

        var newToken = new Token { User = user, Value = value, Type = type, Expiration = expiration };
        await context.Tokens.AddAsync(newToken, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newToken;
    }

    public async Task<Token?> Find(ApplicationUser user, TokenType type, CancellationToken cancellationToken = default)
    {
        var token = await context.Tokens.FirstOrDefaultAsync(t => t.User == user && t.Type == type, cancellationToken);
        if (token == null)
        {
            return null;
        }

        if (DateTime.UtcNow.CompareTo(token.Expiration) >= 0)
        {
            context.Tokens.Remove(token);
            await context.SaveChangesAsync(cancellationToken);

            return null;
        }

        return token;
    }
}