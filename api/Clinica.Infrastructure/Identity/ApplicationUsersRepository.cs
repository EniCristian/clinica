using Clinica.Application.Common.Interfaces;
using Clinica.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Clinica.Infrastructure.Identity;

public class ApplicationUsersRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : IApplicationUsersRepository
{
    public async Task UpdateUser(UserDetails updatedUser)
    {
        var user = await userManager.FindByIdAsync(updatedUser.Id);
        if (user != null)
        {
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.ProfilePicture = updatedUser.ProfilePicture;
            await userManager.UpdateAsync(user);
        }

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

    public async Task<UserDetails?> GetUser(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user != null)
        {
            var roles = await userManager.GetRolesAsync(user);
            return new UserDetails
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = roles,
            };
        }

        return null;
    }

    public async Task<bool> IsValidUserAsync(string email, string password)
    {
        var user = await userManager.FindByNameAsync(email);
        if (user == null)
        {
            return false;
        }

        return await userManager.CheckPasswordAsync(user, password);
    }

    public async Task<ApplicationUser?> GetUser(Guid id)
    {
        return await userManager.FindByIdAsync(id.ToString());
    }
}