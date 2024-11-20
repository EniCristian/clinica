using Clinica.Application.Common.Models;
using MediatR;

namespace Clinica.Application.ApplicationUsers.Commands.Registration;

public class RegistrationCommand : IRequest<Result>
{
    public RegistrationDto RegistrationDto { get; set; }
}

public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, Result>
{

    public async Task<Result> Handle(RegistrationCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}