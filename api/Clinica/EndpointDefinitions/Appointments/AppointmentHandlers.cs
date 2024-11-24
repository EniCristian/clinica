using Clinica.Application.Appointments.Commands;
using Clinica.Application.Appointments.Queries;
using Clinica.Application.Common.Models;
using Clinica.Application.Specialities.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Appointments;

public static class AppointmentHandlers
{
    public static async Task<IResult> Create([FromServices] IMediator mediator, CreateAppointmentCommand createAppointmentCommand)
    {
        await mediator.Send(createAppointmentCommand);
        return Results.Ok();
    }

    public static async Task<IResult> GetAll([FromServices] IMediator mediator, int pageSize, int pageNumber, string? sortParameter, string? sortOrder)
    {
        var request = new PaginatedRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SortOrder = sortOrder,
            SortParameter = sortParameter
        };
        var appointments = await mediator.Send(new GetAllAppointmentsQuery(request));
        return Results.Ok(appointments);
    }
}