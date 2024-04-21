using Clinica.EndpointDefinitions.Translations;

namespace Clinica.EndpointDefinitions.Medics;

public static class MedicsEndpointRouteBuilderExtensions
{
    public static void RegisterMedicsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("api/medics");

        booksEndpoints.MapGet("", MedicsHandlers.GetMedicsAsync);
    }
}