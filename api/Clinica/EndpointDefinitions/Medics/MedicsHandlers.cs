using Clinica.Application.Queries.Medics;
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
}