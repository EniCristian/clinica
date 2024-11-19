namespace Paltinul.Business.Dtos.Authentication
{
    public class ChangePasswordDto
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}