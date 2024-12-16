using Clinica.Application.Common.Models;
using Clinica.Application.Medics;
using Clinica.Application.Medics.Commands.CreateMedic;
using Clinica.Application.Medics.Commands.UpdateMedic;
using Clinica.Application.Specialities.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Medics;

public static class MedicsHandlers
{
    public static  async Task<IResult> GetMedicsAsync( [FromServices] IMediator mediator)
    {
        var medics = await mediator.Send(new MedicsQuery());
        return Results.Ok(medics);
    }

    public static  async Task<IResult> GetMedicsPaginatedAsync( [FromServices] IMediator mediator, int pageSize, int pageNumber, string? sortParameter,string? sortOrder)
    {
        var request = new PaginatedRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SortOrder = sortOrder,
            SortParameter = sortParameter
        };
        var specialities = await mediator.Send(new MedicsPaginatedQuery(request));
        return Results.Ok(specialities);
    }
    
    public static async Task<IResult> Add([FromServices] IMediator mediator, CreateMedicCommand command)
    {
        await mediator.Send(command);
        return Results.Ok();
    }
    
    public static async Task<IResult> Edit([FromServices] IMediator mediator, UpdateMedicCommand command)
    {
        await mediator.Send(command);
        return Results.Ok();
    }
    
    public static async Task<IResult> GetMedicById([FromServices] IMediator mediator, Guid id)
    {
        var medic = await mediator.Send(new GetMedicByIdQuery(id));
        return Results.Ok(medic);
    }
}