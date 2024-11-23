using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Services;
using Clinica.Domain.Entities;
using MediatR;

namespace Clinica.Application.Appointments.Commands;

public record CreateAppointmentCommand : IRequest
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime Date { get; set; }
    public string? Message { get; set; }
}

public class CreateAppointmentCommandHandler(IApplicationDbContext context, IDateTimeService dateTimeService) : IRequestHandler<CreateAppointmentCommand>
{
    public async Task Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Appointment
        {
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Date = request.Date.ToUniversalTime(),
            Message = request.Message,
            Created = dateTimeService.NowUtc
        };

        context.Appointments.Add(entity);

        await context.SaveChangesAsync(cancellationToken);
    }
}