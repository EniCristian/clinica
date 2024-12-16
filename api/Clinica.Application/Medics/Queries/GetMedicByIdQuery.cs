using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Common.Exceptions;
using Clinica.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Medics;

public record GetMedicByIdQuery(Guid Id) : IRequest<MedicDto>;

internal class GetMedicByIdQueryHandler : IRequestHandler<GetMedicByIdQuery, MedicDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMedicByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MedicDto> Handle(GetMedicByIdQuery request, CancellationToken cancellationToken)
    {
        var medic = await _context.Medics.Include(x => x.Speciality).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (medic == null)
        {
            throw new NotFoundException(nameof(Medic), request.Id);
        }
        return _mapper.Map<MedicDto>(medic);
    }
}