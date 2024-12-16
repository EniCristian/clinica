using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Medics;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Specialities.Queries;

public record GetSpecialitiesWithActiveMedicsQuery: IRequest<List<SpecialityDto>>;

internal class GetSpecialitiesWithActiveMedicsQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetSpecialitiesWithActiveMedicsQuery, List<SpecialityDto>>
{
    public async Task<List<SpecialityDto>> Handle(GetSpecialitiesWithActiveMedicsQuery request, CancellationToken cancellationToken)
    {
        var specialities = await context.Specialities
            .Include(x => x.Medics)
            .Where(x => x.Medics.Any())
            .ToListAsync(cancellationToken);

        return mapper.Map<List<SpecialityDto>>(specialities);
    }
}