using System.Reflection;
using Clinica.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Clinica.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ITranslationService, TranslationService>();
        return services;
    }
}