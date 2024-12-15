using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Common.Exceptions;
using Clinica.Domain.Entities;
using MediatR;

namespace Clinica.Application.Appointments.Queries;

public record AppointmentByIdQuery(Guid Id) : IRequest<AppointmentDto>;

internal class AppointmentByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<AppointmentByIdQuery, AppointmentDto>
{
    public async Task<AppointmentDto> Handle(AppointmentByIdQuery request, CancellationToken cancellationToken)
    {
        var appointment = await context.Appointments.FindAsync(request.Id, cancellationToken);
        if (appointment == null)
        {
            throw new NotFoundException(nameof(Appointment), request.Id);
        }

        return mapper.Map<AppointmentDto>(appointment);
    }
}
