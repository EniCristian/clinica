using Clinica.Application.Common.Mapping;
using Clinica.Application.Medics;
using Clinica.Application.Reviews;
using Clinica.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Clinica.Application.Appointments;

public class AppointmentDto : IMapFrom<Appointment>
{
    public Guid Id { get; set; }

    public MedicDto Medic { get; set; }
    public PatientDto Patient { get; set; }

    public DateTime Date { get; set; }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public AppointmentStatus Status { get; set; }

}