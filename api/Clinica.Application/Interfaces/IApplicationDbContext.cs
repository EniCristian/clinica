using Clinica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Address> Addresses { get; }

    DbSet<ContactInformation> ContactInformations { get; }
    
    DbSet<Medic> Medics { get; }
    
    DbSet<Patient> Patients { get; }
    
    DbSet<PatientReview> PatientReviews { get; }
    
    DbSet<Speciality> Specialities { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}