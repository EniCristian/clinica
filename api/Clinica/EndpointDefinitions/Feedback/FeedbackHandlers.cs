using Clinica.Application.ContactInformations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Feedback;

public class FeedbackHandlers
{
    public static async  Task<IResult> Post([FromServices] IMediator mediator)
    {
        var information = await mediator.Send(new ContactInformationQuery());
        return Results.Ok(information);
    }
}