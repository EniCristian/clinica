using Clinica.Application.Common.Models;
using Clinica.Application.Specialities.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Specialities;

public static class SpecialitiesHandlers
{
    public static  async Task<IResult> GetSpecialitiesHandler( [FromServices] IMediator mediator, int pageSize, int pageNumber, string? sortParameter,string? sortOrder)
    {
        var request = new PaginatedRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SortOrder = sortOrder,
            SortParameter = sortParameter
        };
        var specialities = await mediator.Send(new GetSpecialitiesQuery(request));
        return Results.Ok(specialities);
    }
}