using Clinica.Application.Medics;
using Clinica.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Clinica.Application.Appointments;

public class AppointmentDto
{
    public Guid Id { get; set; }

    public MedicDto Medic { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public AppointmentStatus Status { get; set; }

}