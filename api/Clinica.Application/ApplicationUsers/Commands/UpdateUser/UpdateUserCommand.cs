using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Models;
using MediatR;

namespace Clinica.Application.ApplicationUsers.Commands.UpdateUser;
public class UpdateUserRequest: IRequest<Result>
{
    public UpdateUserDto UpdateUserDto { get; set; }
}

public class UpdateUserHandler(IApplicationUsersRepository applicationUsersRepository) : IRequestHandler<UpdateUserRequest, Result>
{
    public async Task<Result> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await applicationUsersRepository.GetUser(request.UpdateUserDto.Email);
            user.FirstName = request.UpdateUserDto.FirstName;
            user.LastName = request.UpdateUserDto.LastName;
            user.ProfilePicture = request.UpdateUserDto.ProfilePicture;
            user.Email = request.UpdateUserDto.Email;

            await applicationUsersRepository.UpdateUser(user);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure([ex.Message]);
        }

    }
}
