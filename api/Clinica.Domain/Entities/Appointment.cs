using Clinica.Domain.Common;

namespace Clinica.Domain.Entities;

public class Appointment: BaseEntity
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime Date { get; set; }
    public string? Message { get; set; }
    public DateTime Created { get; set; }
}