using Clinica.Application.Appointments.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Appointments;

public static class AppointmentHandlers
{
    public static async Task<IResult> Post([FromServices] IMediator mediator, CreateAppointmentCommand createAppointmentCommand)
    {
        await mediator.Send(createAppointmentCommand);
        return Results.Ok();
    }
}