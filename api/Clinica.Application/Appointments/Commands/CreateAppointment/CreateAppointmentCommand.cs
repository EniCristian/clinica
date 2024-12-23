using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Services;
using Clinica.Common.Exceptions;
using Clinica.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Appointments.Commands.CreateAppointment;

public record CreateAppointmentCommand : IRequest
{
    public Guid MedicId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime Date { get; set; }
    public string? Message { get; set; }
}

public class CreateAppointmentCommandHandler(IApplicationDbContext context, IDateTimeService dateTimeService)
    : IRequestHandler<CreateAppointmentCommand>
{
    public async Task Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var specialist = await context.Medics.FirstOrDefaultAsync(x => x.Id == request.MedicId, cancellationToken);
        if (specialist == null)
        {
            throw new NotFoundException(nameof(Medic), request.MedicId);
        }

        var entity = new Appointment
        {
            MedicId = request.MedicId,
            Date = request.Date.ToUniversalTime(),
            Message = request.Message,
            Created = dateTimeService.NowUtc,
            Patient = new Patient
            {
                FullName = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            }
        };

        context.Appointments.Add(entity);

        await context.SaveChangesAsync(cancellationToken);
    }
}