using Clinica.Domain.Entities;

namespace Clinica.Infrastructure.Persistence.SeedProviders;

public class SpecialitiesSeedProvider
{
    public static readonly Speciality Surgery = new()
    {
        Id = Guid.NewGuid(),
        Name = "Cirurgie",
        Description = "Cirurgia este o ramură a medicinei care se ocupă cu tratamentul bolilor, leziunilor și malformațiilor prin intervenții chirurgicale."
    };

    public static readonly Speciality  Gynechology = new()
    {
        Id = Guid.NewGuid(),
        Name = "Ginecologie",
        Description = "Ginecologia este o ramură a medicinei care se ocupă cu studiul și tratamentul bolilor sistemului reproducător feminin."
    };

    public static readonly Speciality ReproductiveMedicine = new()
    {
        Id = Guid.NewGuid(),
        Name = "Medicină reproductivă",
        Description = "Medicina reproductivă este o ramură a medicinei care se ocupă cu studiul și tratamentul problemelor de fertilitate."
    };

    public static readonly Speciality Ecography = new()
    {
        Id = Guid.NewGuid(),
        Name = "Ecografie",
        Description = "Ecografia este o metodă de diagnostic medical care folosește ultrasunetele pentru a vizualiza structurile interne ale corpului."
    };
}