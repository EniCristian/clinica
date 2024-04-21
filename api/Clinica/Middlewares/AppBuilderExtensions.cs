using Clinica.Application.Services;

namespace Clinica.Middlewares;

public static class AppBuilderExtensions
{
    public static void UseExceptionHandling(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<ExceptionHandler>();
    }

    public static void UseLocalization(this IApplicationBuilder applicationBuilder)
    {
        RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(TranslationConstants.SupportedCultures[0])
            .AddSupportedCultures(TranslationConstants.SupportedCultures)
            .AddSupportedUICultures(TranslationConstants.SupportedCultures);
        applicationBuilder.UseRequestLocalization(localizationOptions);
    }
}