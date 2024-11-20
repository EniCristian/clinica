using Clinica.Application.ApplicationUsers.Commands.DeleteUser;
using Clinica.Application.ApplicationUsers.Commands.Login;
using Clinica.Application.ApplicationUsers.Commands.RefreshToken;
using Clinica.Application.ApplicationUsers.Commands.Registration;
using Clinica.Application.ApplicationUsers.Commands.UpdateUser;
using Clinica.Application.ApplicationUsers.Queries.GetByEmail;
using Clinica.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Users;

public static class UsersHandlers
{
    [AllowAnonymous]
    public static async Task<IResult> LoginUser([FromBody] LoginCommand command, ISender sender)
    {
        var response = await sender.Send(command);
        return Results.Ok(response);
    }

    [AllowAnonymous]
    public static async Task<IResult> RefreshToken([FromBody] Tokens token, ISender sender)
    {
        var refreshTokenRequest = new RefreshTokenCommand()
        {
            OldToken = token
        };
        var response = await sender.Send(refreshTokenRequest);
        return Results.Ok(response);
    }

    [AllowAnonymous]
    public static async Task<IResult> RegisterUser([FromBody] RegistrationDto registrationDto, ISender sender)
    {
        var request = new RegistrationCommand
        {
            RegistrationDto = registrationDto
        };

        var response = await sender.Send(request);
        return Results.Ok(response);
    }


    public static async Task<IResult> DeleteUser(string email, ISender sender)
    {
        var request = new DeleteUserRequest
        {
            Email = email
        };
        var response = await sender.Send(request);
        return Results.Ok(response);
    }

    public static async Task<IResult> GetByEmail(string email, ISender sender)
    {
        var request = new GetByEmailRequest
        {
            Email = email
        };
        var response = await sender.Send(request);
        return Results.Ok(response);
    }

    public static async Task<IResult> UpdateUser(UpdateUserDto dto, ISender sender)
    {
        var request = new UpdateUserRequest
        {
            UpdateUserDto = dto
        };

        var response = await sender.Send(request);
        return Results.Ok(response);
    }
}