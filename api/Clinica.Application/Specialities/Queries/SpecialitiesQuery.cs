using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Medics;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Specialities.Queries;

public class SpecialitiesQuery() : IRequest<IEnumerable<SpecialityDto>>;

internal class SpecialitiesQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<SpecialitiesQuery, IEnumerable<SpecialityDto>>
{
    public async Task<IEnumerable<SpecialityDto>> Handle(SpecialitiesQuery request, CancellationToken cancellationToken)
    {
        var specialities = await context.Specialities.OrderBy(p=>p.Name).ToListAsync(cancellationToken);
        
        return mapper.Map<IEnumerable<SpecialityDto>>(specialities);
    }
}