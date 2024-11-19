using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Interfaces.Dtos;
using Clinica.Domain.Entities;
using MediatR;

namespace Clinica.Application.ApplicationUsers.Commands.Login;

public class LoginCommand : IRequest<Tokens>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}

public class LoginCommandHandler(
    IAuthenticator applicationUsersRepository,
    IJWTManagerRepository jwtManagerRepository) : IRequestHandler<LoginCommand, Tokens>
{
    public async Task<Tokens> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var token = await applicationUsersRepository.Authenticate(new SignInDto()
        {
            Email = command.Username,
            Password = command.Password
        });

        return token;
    }
}