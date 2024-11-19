using Clinica.Domain.Entities;

namespace Clinica.Application.Common.Interfaces;

public interface ITokenService
{
    Task<Token> Add(ApplicationUser user, string value, TokenType type, CancellationToken cancellationToken= default);

    Task<Token?> Find(ApplicationUser user, TokenType type, CancellationToken cancellationToken= default);
}