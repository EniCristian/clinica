using Clinica.Application.Common.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Infrastructure.Common;
using Clinica.Infrastructure.Identity;
using Clinica.Infrastructure.Interceptors;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Clinica.Infrastructure.Persistence;

public class ApplicationDbContext(
    DbContextOptions options,
    IOptions<OperationalStoreOptions> operationalStoreOptions,
    IMediator mediator,
    AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
    : ApiAuthorizationDbContext<ApplicationUser>(options,
        operationalStoreOptions), IApplicationDbContext
{
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<ContactInformation> ContactInformations => Set<ContactInformation>();
    
    public DbSet<Medic> Medics => Set<Medic>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Appointment> Appointments  => Set<Appointment>();
    public DbSet<PatientReview> PatientReviews => Set<PatientReview>();

    public DbSet<Speciality> Specialities => Set<Speciality>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}