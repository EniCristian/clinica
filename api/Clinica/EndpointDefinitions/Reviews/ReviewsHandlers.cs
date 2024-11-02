using Clinica.Application.Queries.Reviews;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Reviews;

public static class ReviewsHandlers
{
    public static async  Task<IResult> GetReviews([FromServices] IMediator mediator)
    {
        var reviews = await mediator.Send(new ReviewsQuery());
        return Results.Ok(reviews);
    }
}