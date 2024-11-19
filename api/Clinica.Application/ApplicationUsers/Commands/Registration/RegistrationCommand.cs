using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Models;
using Clinica.Domain.Entities;
using MediatR;

namespace Clinica.Application.ApplicationUsers.Commands.Registration;

public class RegistrationRequest : IRequest<Result>
{
    public RegistrationDto RegistrationDto { get; set; }
}

public class RegistrationCommand : IRequestHandler<RegistrationRequest, Result>
{
    private readonly IAuthenticator _authenticator;

    //private readonly IBlobService _blobService;
    private readonly IMapper _mapper;

    public RegistrationCommand(
        IAuthenticator authenticator,
        //IBlobService blobService,
        IMapper mapper
    )
    {
        _authenticator = authenticator;
        //_blobService = blobService;
        _mapper = mapper;
    }

    public async Task<Result> Handle(RegistrationRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _authenticator.GetUser(request.RegistrationDto.Email);

        if (existingUser != null)
        {
            return Result.Failure(["User with this email already exists."]);
        }

        var newUser = _mapper.Map<ApplicationUser>(request.RegistrationDto);
        //newUser.PictureFolderName = Guid.NewGuid();

        //if (!string.IsNullOrEmpty(request.RegistrationDto?.ProfilePicture))
        //{
        //    Guid filename = Guid.NewGuid();
        //    newUser.ProfilePicture = filename.ToString();
        //    await _blobService.UploadProfilePictureAsync(request.RegistrationDto.ProfilePicture, newUser.ProfilePicture, newUser.PictureFolderName.ToString());
        //}

        // var result = await _authenticator.Register(newUser);
        // return result != Guid.Empty
        //     ? Result.Success()
        //     : Result.Failure(["Failed to register user."]);
        throw new NotImplementedException();
    }
}