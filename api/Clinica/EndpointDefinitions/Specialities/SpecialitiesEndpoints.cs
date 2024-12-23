using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Specialities;

public static class SpecialitiesEndpointRouteBuilderExtensions
{
    public static void RegisterSpecialitiesEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("specialities");

        booksEndpoints.MapGet(SpecialitiesHandlers.GetAllSpecialities);
        booksEndpoints.MapGet("{id}", SpecialitiesHandlers.GetSpecialityById);
        booksEndpoints.MapGet("paginated", SpecialitiesHandlers.GetSpecialitiesPaginatedHandler);
        booksEndpoints.MapPost(SpecialitiesHandlers.Add);
        booksEndpoints.MapPut(SpecialitiesHandlers.Edit);
        booksEndpoints.MapGet("active-medics", SpecialitiesHandlers.GetSpecialitiesWithActiveMedics);
    }
}