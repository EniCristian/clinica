using Clinica.Application.ApplicationUsers.Queries;

namespace Clinica.Application.ApplicationUsers.Commands.UpdateUser;
public class UpdateUserDto: ApplicationUserDto
{
    public string Password { get; set; }
}
