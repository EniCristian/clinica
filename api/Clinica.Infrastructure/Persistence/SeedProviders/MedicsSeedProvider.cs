using Clinica.Domain.Entities;

namespace Clinica.Infrastructure.Persistence.SeedProviders;

public class MedicsSeedProviders
{
    public static readonly Medic ReproductiveMedic = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Serghei",
        LastName = "Zugravîi",
        ImageUrl = "doctor1.jpg",
        SepecialityId = SpecialitiesSeedProvider.ReproductiveMedicine.Id,
        Speciality = SpecialitiesSeedProvider.ReproductiveMedicine,
        ConsultationPrice = 200,
    };

    public static readonly Medic EcographyMedic = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Cornelia",
        LastName = "Istrate",
        ImageUrl = "doctor2.jpg",
        SepecialityId = SpecialitiesSeedProvider.Ecography.Id,
        Speciality = SpecialitiesSeedProvider.Ecography,
        ConsultationPrice = 150,
    };

    public static readonly Medic GynecologyMedic = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Elina",
        LastName = "Danilova",
        ImageUrl = "doctor3.jpg",
        SepecialityId = SpecialitiesSeedProvider.Gynechology.Id,
        Speciality = SpecialitiesSeedProvider.Gynechology,
        ConsultationPrice = 250,
    };

    public static readonly Medic GynecologyMedic2 = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Elena",
        LastName = "Popova",
        ImageUrl = "doctor4.jpg",
        SepecialityId = SpecialitiesSeedProvider.Gynechology.Id,
        Speciality = SpecialitiesSeedProvider.Gynechology,
        ConsultationPrice = 250,
    };

    public static readonly Medic SurgeryMedic = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Sergiu",
        LastName = "Bujor",
        ImageUrl = "doctor5.jpg",
        SepecialityId = SpecialitiesSeedProvider.Surgery.Id,
        Speciality = SpecialitiesSeedProvider.Surgery,
        ConsultationPrice = 300,
    };

}