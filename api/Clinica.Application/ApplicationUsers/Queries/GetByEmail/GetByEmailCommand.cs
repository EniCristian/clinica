using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Common.Exceptions;
using MediatR;

namespace Clinica.Application.ApplicationUsers.Queries.GetByEmail;

public class GetByEmailRequest : IRequest<GetByEmailResponseDto>
{
    public string Email { get; set; }
}

public class GetByEmailCommand : IRequestHandler<GetByEmailRequest, GetByEmailResponseDto>
{
    private readonly IApplicationUsersRepository _applicationUsersRepository;
    //private readonly IBlobService _blobService; 
    private readonly IMapper _mapper;

    public GetByEmailCommand(
        IApplicationUsersRepository applicationUsersRepository,
        //IBlobService blobService,
        IMapper mapper)
    {
        _applicationUsersRepository = applicationUsersRepository;
        //_blobService = blobService;
        _mapper = mapper;
    }

    public async Task<GetByEmailResponseDto> Handle(GetByEmailRequest request, CancellationToken cancellationToken)
    {
        var user = await _applicationUsersRepository.GetUser(request.Email);
        if (user == null)
        {
            throw new NotFoundException($"User with this email{request.Email} does not exist.");
        }

        var response = _mapper.Map<GetByEmailResponseDto>(user);
        //response.ProfilePicture = _blobService.GetFileAsync(user.ProfilePicture, "TemplateBackend", user.PictureFolderName.ToString()).Result;

        return response;
    }
}
