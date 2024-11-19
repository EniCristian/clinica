using Clinica.Domain.Entities;
using Clinica.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Paltinul.DataAccess.Entities.Users;

namespace Clinica.Infrastructure.Persistence;

public class ApplicationDbContextInitializer(
    ILogger<ApplicationDbContextInitializer> logger,
    ApplicationDbContext context,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
{
    public async Task InitialiseAsync()
    {
        try
        {
            if (context.Database.IsSqlServer())
            {
                await context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        await SeedUsers();
        SeedContactInformation();
        SeedSpecialists();
        AddPatients();

        await context.SaveChangesAsync();
    }

    private void AddPatients()
    {
        if (!context.Patients.Any())
        {
            var femalePatient = new Patient()
            {
                FirstName = "Maria",
                LastName = "Didenco",
                ImageUrl = "patient1.jpg",
                Job = "Profesoara",
                PatientReviews = new List<PatientReview>()
                {
                    new()
                    {
                        Message = "Am fost foarte mulțumită de serviciile medicului. Recomand cu încredere!",
                    }
                }
            };

            var malePatient = new Patient()
            {
                FirstName = "Andrei",
                LastName = "Ene",
                ImageUrl = "patient2.jpg",
                Job = "Programator",
                PatientReviews = new List<PatientReview>()
                {
                    new()
                    {
                        Message = "Servicii de inalta calitate. Cu siguranta voi recomanda si familiei mele."
                    }
                }
            };

            context.Patients.Add(femalePatient);
            context.Patients.Add(malePatient);
        }
    }


    private async Task SeedUsers()
    {
        var administratorRole = new IdentityRole(Role.Administrator);

        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser
            { Email = "administrator@localhost", FirstName = "Administrator", LastName = "Administrator" };

        if (userManager.Users.All(u => u.Email != administrator.Email))
        {
            await userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }
    }

    private void SeedContactInformation()
    {
        if (!context.ContactInformations.Any())
        {
            context.ContactInformations.Add(new ContactInformation
            {
                Email = "info.terramed.md",
                PhoneNumber = "+373 (22) 202 373",
                Schedule = "Luni - Vineri, 9:00 - 16:00",
                Address = new Address
                {
                    Country = "R.Moldova",
                    City = "Chișinău",
                    Street = "str. Cuza Voda, 44 a"
                }
            });
            ;
        }
    }

    private void SeedSpecialists()
    {
        if (!context.Specialities.Any())
        {
            var surgery = new Speciality
            {
                Id = Guid.NewGuid(),
                Name = "Cirurgie",
                Description = "Cirurgia este o ramură a medicinei care se ocupă cu tratamentul bolilor, leziunilor și malformațiilor prin intervenții chirurgicale."
            };

            var gynechology = new Speciality
            {
                Id = Guid.NewGuid(),
                Name = "Ginecologie",
                Description = "Ginecologia este o ramură a medicinei care se ocupă cu studiul și tratamentul bolilor sistemului reproducător feminin."
            };

            var reproductiveMedicine = new Speciality
            {
                Id = Guid.NewGuid(),
                Name = "Medicină reproductivă",
                Description = "Medicina reproductivă este o ramură a medicinei care se ocupă cu studiul și tratamentul problemelor de fertilitate."
            };

            var ecography = new Speciality
            {
                Id = Guid.NewGuid(),
                Name = "Ecografie",
                Description = "Ecografia este o metodă de diagnostic medical care folosește ultrasunetele pentru a vizualiza structurile interne ale corpului."
            };

            context.Specialities.Add(surgery);
            context.Specialities.Add(gynechology);
            context.Specialities.Add(reproductiveMedicine);
            context.Specialities.Add(ecography);

            context.Medics.Add(new Medic
            {
                FirstName = "Serghei",
                LastName = "Zugravîi",
                ImageUrl = "doctor1.jpg",
                SepecialityId = reproductiveMedicine.Id,
                Speciality = reproductiveMedicine
            });
            context.Medics.Add(new Medic
            {
                FirstName = "Cornelia",
                LastName = "Istrate",
                ImageUrl = "doctor2.jpg",
                SepecialityId = ecography.Id,
                Speciality = ecography
            });
            context.Medics.Add(new Medic
            {
                FirstName = "Elina",
                LastName = "Danilova",
                ImageUrl = "doctor3.jpg",
                SepecialityId = gynechology.Id,
                Speciality = gynechology
            });
            context.Medics.Add(new Medic
            {
                FirstName = "Sergiu",
                LastName = "Bujor",
                ImageUrl = "doctor5.jpg",
                SepecialityId = surgery.Id,
                Speciality = surgery
            });
        }
    }
}