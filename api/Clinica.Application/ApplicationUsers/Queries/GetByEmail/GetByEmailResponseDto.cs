namespace Clinica.Application.ApplicationUsers.Queries.GetByEmail;
public class GetByEmailResponseDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }

    public DateOnly DateOfBirth { get; set; }
    public string? ProfilePicture { get; set; }

}
