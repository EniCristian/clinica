using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Translations;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterTranslationsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("translations");

        booksEndpoints.MapGet(TranslationsHandlers.GetTranslationsAsync);
    }
}