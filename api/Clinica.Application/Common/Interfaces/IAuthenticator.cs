using Clinica.Application.Common.Interfaces.Dtos;
using Clinica.Domain.Entities;
using Paltinul.Business.Dtos.Authentication;

namespace Clinica.Application.Common.Interfaces
{
    public interface IAuthenticator
    {

        Task<Tokens> Authenticate(SignInDto signInDto);

        Task<ApplicationUser?> GetUser(string email);

        Task<ApplicationUser?> GetUser(Guid id);

        Task<Tokens> RefreshToken(Tokens authTokenDto);

        Task ForgotPasswordAsync(string email);

        Task ChangePassword(Guid currentUserId, ChangePasswordDto changePassword);

        Task ResendUserConfirmationEmail(Guid userId);
    }
}