namespace Clinica.Domain.Entities;
public class UserRefreshTokens
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string RefreshToken { get; set; }
    public bool IsActive { get; set; } = true;
}
