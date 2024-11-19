using Clinica.Application.Common.Interfaces;
using Clinica.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Infrastructure.Identity;

public class ApplicationUsersRepository(UserManager<ApplicationUser> userManager) : IApplicationUsersRepository
{
    public async Task<ApplicationUser?> UpdateUser(ApplicationUser updatedUser)
    {
        var user = await userManager.FindByIdAsync(updatedUser.Id);
        if (user != null)
        {
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.DateOfBirth = updatedUser.DateOfBirth;
            user.ProfilePicture = updatedUser.ProfilePicture;
            await userManager.UpdateAsync(user);
            return user;
        }

        return null;
    }

    public async Task<bool> DeleteUser(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user != null)
        {
            await userManager.DeleteAsync(user);
            return true;
        }

        return false;
    }

    public async Task<ApplicationUser?> GetUser(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<ApplicationUser?> GetUser(Guid id)
    {
        return await userManager.FindByIdAsync(id.ToString());
    }
}