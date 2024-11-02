using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Medics;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Specialities.Queries;

public record GetSpecialitiesQuery : IRequest<IEnumerable<SpecialityDto>>;
internal class GetSpecialitiesQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetSpecialitiesQuery, IEnumerable<SpecialityDto>>
{
    public async Task<IEnumerable<SpecialityDto>> Handle(GetSpecialitiesQuery request, CancellationToken cancellationToken)
    {
        var specialities = await context.Specialities.ToListAsync(cancellationToken);
        return mapper.Map<IEnumerable<SpecialityDto>>(specialities);
    }
}