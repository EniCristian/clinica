using Clinica.Domain.Entities;

namespace Clinica.Infrastructure.Persistence.SeedProviders;

public class SpecialitiesSeedProvider
{
    public static readonly Speciality Surgery = new()
    {
        Id = Guid.NewGuid(),
        Name = "Cirurgie",
        ImageUrl = "assets/images/department1.jpg",
        Description = "Cirurgia este o ramură a medicinei care se ocupă cu tratamentul bolilor, leziunilor și malformațiilor prin intervenții chirurgicale.",
        ConsultationDurationInMinutes = 30
    };

    public static readonly Speciality  Gynechology = new()
    {
        Id = Guid.NewGuid(),
        Name = "Ginecologie",
        ImageUrl = "assets/images/department2.jpg",
        Description = "Ginecologia este o ramură a medicinei care se ocupă cu studiul și tratamentul bolilor sistemului reproducător feminin.",
        ConsultationDurationInMinutes = 45
    };

    public static readonly Speciality ReproductiveMedicine = new()
    {
        Id = Guid.NewGuid(),
        Name = "Medicină reproductivă",
        ImageUrl = "assets/images/department3.jpg",
        Description = "Medicina reproductivă este o ramură a medicinei care se ocupă cu studiul și tratamentul problemelor de fertilitate.",
        ConsultationDurationInMinutes = 60
    };

    public static readonly Speciality Ecography = new()
    {
        Id = Guid.NewGuid(),
        Name = "Ecografie",
        Description = "Ecografia este o metodă de diagnostic medical care folosește ultrasunetele pentru a vizualiza structurile interne ale corpului.",
        ConsultationDurationInMinutes = 30
    };
}