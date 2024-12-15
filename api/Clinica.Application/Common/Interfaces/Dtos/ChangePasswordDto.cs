namespace Clinica.Application.Common.Interfaces.Dtos
{
    public class ChangePasswordDto
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}