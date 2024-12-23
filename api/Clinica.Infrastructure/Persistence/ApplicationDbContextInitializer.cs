using Clinica.Domain.Constants;
using Clinica.Domain.Entities;
using Clinica.Infrastructure.Persistence.SeedProviders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
        context.Appointments.AddRange(AppointmentsSeedProvider.Appointments);

        await context.SaveChangesAsync();
    }

    private void AddPatients()
    {
        if (!context.Patients.Any())
        {
            var femalePatient = new Patient()
            {
                FullName = "Maria Didenco",
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
                FullName = "Andrei Ene",
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
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser
        {
            Email = "administrator@localhost",
            EmailConfirmed = true,
            UserName = "administrator@localhost"
        };

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
        }
    }

    private void SeedSpecialists()
    {
        if (!context.Specialities.Any())
        {
            context.Specialities.Add(SpecialitiesSeedProvider.Surgery);
            context.Specialities.Add(SpecialitiesSeedProvider.Gynechology);
            context.Specialities.Add(SpecialitiesSeedProvider.ReproductiveMedicine);
            context.Specialities.Add(SpecialitiesSeedProvider.Ecography);
            context.Specialities.Add(SpecialitiesSeedProvider.Dermatology);
            context.Specialities.Add(SpecialitiesSeedProvider.Neurology);
            context.Specialities.Add(SpecialitiesSeedProvider.Cardiology);
            context.Specialities.Add(SpecialitiesSeedProvider.Ophthalmology);
            context.Specialities.Add(SpecialitiesSeedProvider.Otorhinolaryngology);
            context.Specialities.Add(SpecialitiesSeedProvider.Urology);

            context.Medics.Add(MedicsSeedProviders.ReproductiveMedic);
            context.Medics.Add(MedicsSeedProviders.GynecologyMedic2);
            context.Medics.Add(MedicsSeedProviders.EcographyMedic);
            context.Medics.Add(MedicsSeedProviders.GynecologyMedic);
            context.Medics.Add(MedicsSeedProviders.SurgeryMedic);
        }
    }
}