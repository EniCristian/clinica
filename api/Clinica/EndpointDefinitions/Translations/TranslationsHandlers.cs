using System.Globalization;
using Clinica.Application.Queries;
using Clinica.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.EndpointDefinitions.Translations;

public static class TranslationsHandlers
{
    //TODO: Move this to a configuration file
    private const string DefaultCulture = "ro-RO";
    public static async Task<IResult> GetTranslationsAsync([FromHeader(Name = "Accept-Language")] string? locale, [FromServices] IMediator mediator)
    {
        CultureInfo cultureInfo;
        if (!string.IsNullOrWhiteSpace(locale))
        {
            locale = locale.Split(',').FirstOrDefault();
        }
        locale ??= DefaultCulture;
        try
        {
            cultureInfo = new CultureInfo(locale);
        }
        catch (Exception)
        {
            cultureInfo = new CultureInfo(TranslationConstants.DefaultCulture);
        }

        var translations = await mediator.Send(new TranslationsQuery(cultureInfo));
        return Results.Ok(translations);
    }
}