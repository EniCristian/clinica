using Microsoft.AspNetCore.Identity;

namespace Clinica.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? ProfilePicture { get; set; }
    public Guid PictureFolderName { get; set; }
}
