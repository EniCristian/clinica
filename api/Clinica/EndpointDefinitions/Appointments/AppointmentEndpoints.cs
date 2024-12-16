using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Appointments;

public static class AppointmentEndpoints
{
    public static void RegisterAppointmentEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("appointment");
        
        booksEndpoints.MapGet(AppointmentsHandlers.GetAll);
        booksEndpoints.MapPost(AppointmentsHandlers.Add);
    }
}