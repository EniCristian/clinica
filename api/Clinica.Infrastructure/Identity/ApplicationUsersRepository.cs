using Clinica.Application.Common.Interfaces;
using Clinica.Common.Exceptions;
using Clinica.Domain.Constants;
using Clinica.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Clinica.Infrastructure.Identity;

public class ApplicationUsersRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IApplicationDbContext context) : IApplicationUsersRepository
{
    public async Task UpdateUser(UserDetails updatedUser)
    {
        var user = await userManager.FindByIdAsync(updatedUser.Id);
        if (user != null)
        {
            user.Email = updatedUser.Email;
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
            if (roles.Any(r => r == Roles.Medic))
            {
                var medic = context.Medics.FirstOrDefault(m => m.Id == Guid.Parse(user.Id));
                if (medic == null)
                {
                    throw new NotFoundException($"Medic with id {user.Id} not found");
                }

                return new UserDetails
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FirstName = medic.FirstName,
                    LastName = medic.LastName,
                    Email = user.Email,
                    Roles = roles,
                };
            }

            if (roles.Any(r => r == Roles.Administrator))
            {
                return new UserDetails
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = user.Email,
                    Roles = roles,
                };
            }
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