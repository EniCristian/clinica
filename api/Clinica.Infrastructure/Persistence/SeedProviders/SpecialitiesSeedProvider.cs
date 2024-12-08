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
    
    public static readonly Speciality Cardiology = new()
    {
        Id = Guid.NewGuid(),
        Name = "Cardiologie",
        Description = "Cardiologia este o ramură a medicinei care se ocupă cu studiul, diagnosticul și tratamentul bolilor inimii.",
        ConsultationDurationInMinutes = 45
    };
    
    public static readonly Speciality Neurology = new()
    {
        Id = Guid.NewGuid(),
        Name = "Neurologie",
        Description = "Neurologia este o ramură a medicinei care se ocupă cu studiul sistemului nervos și a bolilor care îl afectează.",
        ConsultationDurationInMinutes = 45
    };
    
    public static readonly Speciality Dermatology = new()
    {
        Id = Guid.NewGuid(),
        Name = "Dermatologie",
        Description = "Dermatologia este o ramură a medicinei care se ocupă cu studiul și tratamentul bolilor pielii.",
        ConsultationDurationInMinutes = 30
    };
    
    public static readonly Speciality Ophthalmology = new()
    {
        Id = Guid.NewGuid(),
        Name = "Oftalmologie",
        Description = "Oftalmologia este o ramură a medicinei care se ocupă cu studiul și tratamentul bolilor ochilor.",
        ConsultationDurationInMinutes = 45
    };
    
    public static readonly Speciality Otorhinolaryngology = new()
    {
        Id = Guid.NewGuid(),
        Name = "Otorinolaringologie",
        Description = "Otorinolaringologia este o ramură a medicinei care se ocupă cu studiul și tratamentul bolilor urechii, nasului și gâtului.",
        ConsultationDurationInMinutes = 45
    };
    
    public static readonly Speciality Urology = new()
    {
        Id = Guid.NewGuid(),
        Name = "Urologie",
        Description = "Urologia este o ramură a medicinei care se ocupă cu studiul și tratamentul bolilor sistemului urinar și al organelor genitale masculine.",
        ConsultationDurationInMinutes = 45
    };
}