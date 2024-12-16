using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Common.Exceptions;
using Clinica.Domain.Entities;
using MediatR;

namespace Clinica.Application.Medics.Commands.UpdateMedic;

public class UpdateMedicCommand : IRequest
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public Guid SpecialityId { get; set; }
    public decimal ConsultationPrice { get; set; }
    public string? Description { get; set; }
}

internal class UpdateMedicCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateMedicCommand>
{
    public async Task Handle(UpdateMedicCommand request, CancellationToken cancellationToken)
    {
        var speciality = await context.Specialities.FindAsync(request.SpecialityId);
        if (speciality == null)
        {
            throw new NotFoundException(nameof(Speciality), request.SpecialityId);
        }
        var medic = await context.Medics.FindAsync(request.Id);
        if (medic == null)
        {
            throw new NotFoundException(nameof(Medic), request.Id);
        }
        medic.FirstName = request.FirstName;
        medic.LastName = request.LastName;
        medic.PhoneNumber = request.PhoneNumber;
        medic.Speciality = speciality;
        medic.ConsultationPrice = request.ConsultationPrice;
        medic.Description = request.Description;
        await context.SaveChangesAsync(cancellationToken);
    }
}