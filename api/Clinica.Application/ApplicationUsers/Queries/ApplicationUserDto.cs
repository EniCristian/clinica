namespace Clinica.Application.ApplicationUsers.Queries;
public class ApplicationUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? ProfilePicture { get; set; }
}
