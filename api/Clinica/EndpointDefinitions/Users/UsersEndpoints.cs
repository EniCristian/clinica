using Clinica.Infrastructure.Identity;

namespace Clinica.EndpointDefinitions.Users;

public static class UsersEndpoints
{
    public static void RegisterUsersEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapIdentityApi<ApplicationUser>();
    }
}