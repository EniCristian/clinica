using AutoMapper;
using Clinica.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Medics;

public record MedicsQuery : IRequest< List<MedicDto>>;

internal class MedicsQueryHandler(IMapper mapper, IApplicationDbContext context) : IRequestHandler<MedicsQuery, List<MedicDto>>
{
    public async Task<List<MedicDto>> Handle(MedicsQuery request, CancellationToken cancellationToken)
    {
       var medics = context.Medics.Include(p=>p.Speciality).ToList();
       return mapper.Map<List<MedicDto>>(medics);
    }
}