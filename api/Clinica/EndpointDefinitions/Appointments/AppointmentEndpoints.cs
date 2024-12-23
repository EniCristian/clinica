using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Appointments;

public static class AppointmentEndpoints
{
    public static void RegisterAppointmentEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("appointments");
        
        booksEndpoints.MapGet("paginated",AppointmentsHandlers.GetAll);
        booksEndpoints.MapGet("{id}", AppointmentsHandlers.GetById);
        booksEndpoints.MapPost(AppointmentsHandlers.Add);
    }
}