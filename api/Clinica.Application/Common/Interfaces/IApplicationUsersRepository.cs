using Clinica.Application.Common.Models;
using Clinica.Domain.Entities;

namespace Clinica.Application.Common.Interfaces;

public interface IApplicationUsersRepository
{
    Task<bool> DeleteUser(string email);
    Task<UserDetails?> GetUser(string email);
    Task UpdateUser(UserDetails updatedUser);
    Task<bool> IsValidUserAsync(string email, string password);
}
