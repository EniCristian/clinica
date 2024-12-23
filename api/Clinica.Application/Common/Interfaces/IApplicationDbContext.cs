using Clinica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Address> Addresses { get; }
    DbSet<Token> Tokens { get; }

    DbSet<ContactInformation> ContactInformations { get; }
    
    DbSet<Medic> Medics { get; }
    
    DbSet<Patient> Patients { get; }
    DbSet<Appointment> Appointments { get; }

    DbSet<PatientReview> PatientReviews { get; }
    
    DbSet<Speciality> Specialities { get; }
    DbSet<Feedback> Feedbacks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}