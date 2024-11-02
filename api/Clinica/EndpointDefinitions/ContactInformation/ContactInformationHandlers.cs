using Clinica.Application.ContactInformations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.ContactInformation;

public static class ContactInformationHandlers
{
    public static async  Task<IResult> GetContactInformationAsync([FromServices] IMediator mediator)
    {
        var information = await mediator.Send(new ContactInformationQuery());
        return Results.Ok(information);
    }
}