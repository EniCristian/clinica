using Clinica.Domain.Entities;

namespace Clinica.Infrastructure.Persistence.SeedProviders;

public static class AppointmentsSeedProvider
{
    public static IEnumerable<Appointment> Appointments = new List<Appointment>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            MedicId = MedicsSeedProviders.ReproductiveMedic.Id,
            Medic = MedicsSeedProviders.ReproductiveMedic,
            PhoneNumber = "068452182",
            Name = "Natalia Popescu",
            Email = "natalia.popescu@gmail.com",
            Created = new DateTime(2022, 1, 1, 8, 0, 0),
            Date = new DateTime(2022, 1, 3, 8, 0, 0),
            Message = "Am probleme cu sarcina, ma puteti ajuta?",
        },
        new()
        {
            Id = Guid.NewGuid(),
            MedicId = MedicsSeedProviders.EcographyMedic.Id,
            Medic = MedicsSeedProviders.EcographyMedic,
            PhoneNumber = "069422152",
            Name = "Ion Popescu",
            Email = "ion.popescu@mail.ru",
            Created = new DateTime(2022, 2, 1, 8, 0, 0),
            Date = new DateTime(2022, 2, 3, 8, 0, 0),
            Message = "As dori sa fac o ecografie, ma puteti ajuta?",
        },
        new()
        {
            Id = Guid.NewGuid(),
            MedicId = MedicsSeedProviders.SurgeryMedic.Id,
            Medic = MedicsSeedProviders.SurgeryMedic,
            PhoneNumber = "079581257",
            Name = "Vasile Dumitrescu",
            Email = "vasile.dumitrescu70@mail.ru",
            Created = new DateTime(2022, 3, 1, 8, 0, 0),
            Date = new DateTime(2022, 3, 3, 8, 0, 0),
            Message = "Am nevoie de o operatie, ma puteti ajuta?",
        },
        new()
        {
            Id = Guid.NewGuid(),
            MedicId = MedicsSeedProviders.SurgeryMedic.Id,
            Medic = MedicsSeedProviders.SurgeryMedic,
            PhoneNumber = "079854111",
            Name = "Ionel Vasilescu",
            Email = "ionl.vasilescu@gmail.com",
            Created = new DateTime(2022, 4, 1, 8, 0, 0),
            Date = new DateTime(2022, 4, 3, 8, 0, 0),
            Message = "Am nevoie de o operatie, ma puteti ajuta?",
        },
        new()
        {
            Id = Guid.NewGuid(),
            MedicId = MedicsSeedProviders.GynecologyMedic.Id,
            Medic = MedicsSeedProviders.GynecologyMedic,
            PhoneNumber = "078548887",
            Name = "Ioana Dragomir",
            Email = "ioanadrgmr@gmail.com",
            Created = new DateTime(2022, 5, 1, 8, 0, 0),
            Date = new DateTime(2022, 5, 3, 8, 0, 0),
        }
    };
}