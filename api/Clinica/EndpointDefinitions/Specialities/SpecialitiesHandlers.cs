using Clinica.Application.Common.Models;
using Clinica.Application.Specialities.Commands.CreateSpeciality;
using Clinica.Application.Specialities.Commands.EditSpeciality;
using Clinica.Application.Specialities.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Specialities;

public static class SpecialitiesHandlers
{
    public static  async Task<IResult> GetSpecialitiesHandler( [FromServices] IMediator mediator)
    {
        var specialities = await mediator.Send(new GetSpecialitiesQuery());
        return Results.Ok(specialities);
    } 
    public static  async Task<IResult> GetSpecialitiesPaginatedHandler( [FromServices] IMediator mediator, int pageSize, int pageNumber, string? sortParameter,string? sortOrder)
    {
        var request = new PaginatedRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SortOrder = sortOrder,
            SortParameter = sortParameter
        };
        var specialities = await mediator.Send(new GetSpecialitiesPaginatedQuery(request));
        return Results.Ok(specialities);
    }
        
    public static async Task<IResult> Add([FromServices] IMediator mediator, CreateSpecialityCommand command)
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