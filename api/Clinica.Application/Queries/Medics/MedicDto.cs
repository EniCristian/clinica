using Clinica.Application.Common.Mapping;
using Clinica.Domain.Entities;

namespace Clinica.Application.Queries.Medics;

public class MedicDto : IMapFrom<Medic>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public SpecialityDto Speciality { get; set; }
}

public class SpecialityDto : IMapFrom<Speciality>
{
    public string Name { get; set; }

    public string Description { get; set; }
}