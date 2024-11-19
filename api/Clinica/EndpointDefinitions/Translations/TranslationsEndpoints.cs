using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Translations;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterTranslationsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var translations = endpointRouteBuilder.MapGroup("translations");

        translations.MapGet(TranslationsHandlers.GetTranslationsAsync);
    }
}