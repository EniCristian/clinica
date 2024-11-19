using System.Security.Claims;
using Clinica.Domain.Entities;

namespace Clinica.Application.Common.Interfaces;
public interface IJWTManagerRepository
{
    Tokens GenerateToken(string userName);
    Tokens GenerateRefreshToken(string userName);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
