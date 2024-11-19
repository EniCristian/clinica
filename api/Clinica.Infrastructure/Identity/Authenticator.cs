using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Interfaces.Dtos;
using Clinica.Common.Exceptions;
using Clinica.Common.Resources;
using Clinica.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paltinul.Business.Dtos.Authentication;
using Paltinul.DataAccess.Entities.Users;

namespace Clinica.Infrastructure.Identity;

public class Authenticator(UserManager<ApplicationUser> userManager) : IAuthenticator
{
    public async Task<Tokens> Authenticate(SignInDto signInDto)
    {
        var user = await GetUser(signInDto.Email);

        if (user == null)
        {
            throw new BadRequestException(Auth.CREDENTIALS_ERROR);
        }

        var correctPassword = await userManager.CheckPasswordAsync(user, signInDto.Password);
        var confirmedEmail = await userManager.IsEmailConfirmedAsync(user);

        if (!correctPassword || !confirmedEmail)
        {
            throw new BadRequestException(Auth.CREDENTIALS_ERROR);
        }

        return await GenerateToken(user);
    }

    public async Task<ApplicationUser?> GetUser(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<ApplicationUser?> GetUser(Guid id)
    {
        return await userManager.FindByIdAsync(id.ToString());
    }

    public async Task<Tokens> RefreshToken(Tokens authTokenDto)
    {
        var username = tokenHelper.GetUsernameFromExpiredAuthToken(authTokenDto.AuthToken);

        if (string.IsNullOrEmpty(username))
        {
            throw new BadRequestException(General.ERROR);
        }

        var user = await GetUser(username);

        if (user == null)
        {
            throw new BadRequestException(General.ERROR);
        }

        if (!await IsUserRefreshTokenValid(user, authTokenDto.RefreshToken))
        {
            throw new BadRequestException(General.ERROR);
        }

        return await GenerateToken(user);
    }

    public async  Task ForgotPasswordAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user != null)
        {
            var token = await this.tokenGenerator.GetResetPasswordToken(user);
            await SendResetPasswordEmail(user, token);
        }
        else
        {
            throw new BadRequestException(string.Format(DbLoggerCategory.Model.Validation.USER_NOT_FOUND_TEMPLATE, email));
        }
    }

    public async Task ChangePassword(Guid currentUserId, ChangePasswordDto changePassword)
    {
        var user = await userManager.FindByIdAsync(currentUserId.ToString());

        if (user != null)
        {
            var result =
                await userManager.ChangePasswordAsync(user, changePassword.Password,
                    changePassword.NewPassword);

            if (!result.Succeeded)
            {
                throw new BadRequestException(result.Errors.Select(p => p.Description).First());
            }

            await ActivateUser(user);
        }
        else
        {
            throw new UserNotFoundException();
        }
    }

    public async Task ResendUserConfirmationEmail(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user != null)
        {
            var userRoles = await userManager.GetRolesAsync(user);

            if (userRoles.Contains(Role.Specialist) || userRoles.Contains(Role.Medic))
            {
                await ResendConfirmationEmailToSpecialist(user);
            }
            else if (userRoles.Contains(Role.Patient) && !user.EmailConfirmed)
            {
                var token = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                await SendConfirmationEmail(user, token);
            }
            else
            {
                throw new BadRequestException(General.CONFIRMATION_EMAIL_RESEND_ERROR);
            }

            await UpdateConfirmationEmailFields(user);
        }
        else
        {
            throw new UserNotFoundException();
        }
    }

    private async Task<bool> IsUserRefreshTokenValid(ApplicationUser user, string refreshToken)
    {
        var token = await this.tokenService.Find(user, TokenType.RefreshToken);

        return token != null && token.Value == refreshToken;
    }

}