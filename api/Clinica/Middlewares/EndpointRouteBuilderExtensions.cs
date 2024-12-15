using System.Diagnostics.CodeAnalysis;

namespace Clinica.Middlewares;

public static class EndpointRouteBuilderExtensions
{
    public static RouteGroupBuilder MapGet(this RouteGroupBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
    {
        builder.MapGet(pattern, handler);

        return builder;
    }

    public static RouteGroupBuilder MapPost(this RouteGroupBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
    {

        builder.MapPost(pattern, handler);

        return builder;
    }

    public static RouteGroupBuilder MapPut(this RouteGroupBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern="")
    {

        builder.MapPut(pattern, handler);

        return builder;
    }

    public static RouteGroupBuilder MapDelete(this RouteGroupBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern)
    {
        builder.MapDelete(pattern, handler);

        return builder;
    }
}
