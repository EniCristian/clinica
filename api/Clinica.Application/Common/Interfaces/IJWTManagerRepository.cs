using System.Security.Claims;
using Clinica.Domain.Entities;

namespace Clinica.Application.Common.Interfaces;
public interface IJWTManagerRepository
{
    Tokens GenerateToken(UserDetails user);
    Tokens GenerateRefreshToken(UserDetails user);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}

public record UserDetails()
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public  string? ProfilePicture { get; set; }
    public required IEnumerable<string> Roles { get; set; }
}
