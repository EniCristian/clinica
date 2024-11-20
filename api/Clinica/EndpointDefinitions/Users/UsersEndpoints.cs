using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Users;

public static class UsersEndpoints
{
    public static void RegisterUsersEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var usersEndpoints = endpointRouteBuilder.MapGroup("users").RequireAuthorization();

        usersEndpoints.MapPost(UsersHandlers.LoginUser, "login");
        usersEndpoints.MapPost(UsersHandlers.RefreshToken, "refresh-token");
        usersEndpoints.MapPost(UsersHandlers.RegisterUser, "register");
        usersEndpoints.MapDelete(UsersHandlers.DeleteUser, "delete-by-email/{email}");
        usersEndpoints.MapPut(UsersHandlers.UpdateUser, "update");
        usersEndpoints.MapGet(UsersHandlers.GetByEmail, "get-by-email/{email}");
    }
}