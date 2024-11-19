using Clinica.Application.Common.Models;
using Clinica.Domain.Entities;

namespace Clinica.Application.Common.Interfaces;

public interface IApplicationUsersRepository
{
    Task<ApplicationUser?> UpdateUser(ApplicationUser updatedUser);
    Task<bool> DeleteUser(string username);
    Task<ApplicationUser?> GetUser(string username);
}
