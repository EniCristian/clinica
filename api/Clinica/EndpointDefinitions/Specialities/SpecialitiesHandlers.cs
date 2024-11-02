using Clinica.Application.Specialities.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Specialities;

public static class SpecialitiesHandlers
{
    public static  async Task<IResult> GetSpecialitiesHandler( [FromServices] IMediator mediator)
    {
        var medics = await mediator.Send(new GetSpecialitiesQuery());
        return Results.Ok(medics);
    }
}