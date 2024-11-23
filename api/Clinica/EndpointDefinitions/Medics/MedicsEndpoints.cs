using Clinica.EndpointDefinitions.Translations;
using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Medics;

public static class MedicsEndpointRouteBuilderExtensions
{
    public static void RegisterMedicsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("medics");

        booksEndpoints.MapGet(MedicsHandlers.GetMedicsAsync);
        booksEndpoints.MapGet(MedicsHandlers.GetMedicsPaginatedAsync, "/paginated");
    }
}