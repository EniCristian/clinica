namespace Clinica.Application.ApplicationUsers.Commands.Registration;
public class RegistrationResponseDto
{
    public Guid UserId { get; set; }
    public List<string> Errors { get; set; }
}
