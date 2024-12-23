using Clinica.Application.Common.Mapping;
using Clinica.Domain.Entities;

namespace Clinica.Application.Medics;

public class MedicDto : IMapFrom<Medic>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public SpecialityDto Speciality { get; set; }
    public decimal ConsultationPrice { get; set; }
}

public class SpecialityDto : IMapFrom<Speciality>
{
    public Guid Id { get; set; }
    public string? ImageUrl { get; set; }
    public required string Name { get; set; }

    public string Description { get; set; }

    public uint ConsultationDurationInMinutes { get; set; }
}