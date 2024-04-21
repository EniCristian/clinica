using AutoMapper;
using Clinica.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Queries.Medics;

public record MedicsQuery : IRequest< List<MedicDto>>;

internal class MedicsQueryHandler : IRequestHandler<MedicsQuery, List<MedicDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public MedicsQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<MedicDto>> Handle(MedicsQuery request, CancellationToken cancellationToken)
    {
       var medics = _context.Medics.Include(p=>p.Speciality).ToList();
       return _mapper.Map<List<MedicDto>>(medics);
    }
}