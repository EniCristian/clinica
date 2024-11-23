using Clinica.Domain.Common;

namespace Clinica.Domain.Entities;

public class Medic: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public Guid SepecialityId { get; set; }
    public virtual Speciality Speciality { get; set; }
    public virtual IEnumerable<Appointment> Appointments { get; set; }

    public decimal ConsultationPrice { get; set; }
}