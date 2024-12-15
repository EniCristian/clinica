using Clinica.Application.Appointments.Commands;
using Clinica.Application.Appointments.Commands.CreateAppointment;
using Clinica.Application.Appointments.Queries;
using Clinica.Application.Common.Models;
using Clinica.Application.Specialities.Commands.CreateSpeciality;
using Clinica.Application.Specialities.Commands.EditSpeciality;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Appointments;

public static class AppointmentsHandlers
{
    public static async Task<IResult> GetAll([FromServices] IMediator mediator, int pageSize, int pageNumber, string? sortParameter, string? sortOrder)
    {
        var request = new PaginatedRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SortOrder = sortOrder,
            SortParameter = sortParameter
        };
        var appointments = await mediator.Send(new GetSpecialitiesAppointmentsQuery(request));
        return Results.Ok(appointments);
    }
        
    public static async Task<IResult> Add([FromServices] IMediator mediator, CreateAppointmentCommand command)
    {
        await mediator.Send(command);
        return Results.Ok();
    }
    
    public static async Task<IResult> Edit([FromServices] IMediator mediator, EditSpecialityCommand command)
    {
        await mediator.Send(command);
        return Results.Ok();
    }
}