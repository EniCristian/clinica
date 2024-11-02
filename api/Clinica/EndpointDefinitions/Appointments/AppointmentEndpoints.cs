using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Appointments;

public static class AppointmentEndpoints
{
    public static void RegisterAppointmentEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("api/appointment");

        booksEndpoints.MapPost(AppointmentHandlers.Post);
    }
}