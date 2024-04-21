namespace Clinica.EndpointDefinitions.Translations;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterBookStoreEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("api/translations");

        booksEndpoints.MapGet("", TranslationsHandlers.GetTranslationsAsync);
    }
}