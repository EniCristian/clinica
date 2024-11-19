using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Models;
using MediatR;

namespace Clinica.Application.ApplicationUsers.Commands.DeleteUser;

public class DeleteUserRequest : IRequest<Result>
{
    public string Email { get; set; }
}

public class DeleteUserCommand(IApplicationUsersRepository applicationUsersRepository) : IRequestHandler<DeleteUserRequest, Result>
{
    public async Task<Result> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await applicationUsersRepository.GetUser(request.Email);
            if (user == null) return Result.Failure(["User not found"]);
            await applicationUsersRepository.DeleteUser(request.Email);
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Failure(["Failed to delete user"]);
        }
    }
}