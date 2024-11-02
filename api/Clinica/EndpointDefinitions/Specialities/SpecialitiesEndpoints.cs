using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Specialities;

public static class SpecialitiesEndpointRouteBuilderExtensions
{
    public static void RegisterSpecialitiesEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("api/specialities");

        booksEndpoints.MapGet(SpecialitiesHandlers.GetSpecialitiesHandler);
    }
}