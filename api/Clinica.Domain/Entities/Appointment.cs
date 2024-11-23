using Clinica.Domain.Common;

namespace Clinica.Domain.Entities;

public class Appointment: BaseEntity
{
    public Guid MedicId { get; set; }
    public virtual Medic Medic { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime Date { get; set; }
    public string? Message { get; set; }
    public DateTime Created { get; set; }
}

public enum AppointmentStatus
{
    Created = 10,

    Approved = 20,

    Finished = 40,

    Cancelled = 50,
}