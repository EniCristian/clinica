using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Common.Exceptions;
using Clinica.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Medics.Commands.CreateMedic;

public class CreateMedicCommand : IRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public Guid SpecialityId { get; set; }
    public decimal ConsultationPrice { get; set; }
    public string? Description { get; set; }
}

public class CreateMedicCommandHandler : IRequestHandler<CreateMedicCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateMedicCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(CreateMedicCommand request, CancellationToken cancellationToken)
    {
        var speciality = await _context.Specialities.FindAsync(request.SpecialityId);
        if (speciality == null)
        {
            throw new NotFoundException(nameof(Speciality), request.SpecialityId);
        }
        var medicExists = await _context.Medics.AnyAsync(x => x.Email == request.Email, cancellationToken);
        if (medicExists)
        {
            throw new ConflictException(nameof(Medic), request.Email);
        }
        
        var medic = new Medic
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Speciality = speciality,
            ConsultationPrice = request.ConsultationPrice,
            Description = request.Description
        };
        _context.Medics.Add(medic);
        await _context.SaveChangesAsync(cancellationToken);
    }
}