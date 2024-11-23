using Clinica.Domain.Common;

namespace Clinica.Domain.Entities;

public class Speciality : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public uint ConsultationDurationInMinutes { get; set; }
}