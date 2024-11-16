using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.ContactInformation;

public static class ContactInformationEndpoints
{
    public static void RegisterContactInformationEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("contact-information");

        booksEndpoints.MapGet(ContactInformationHandlers.GetContactInformationAsync);
    }
}