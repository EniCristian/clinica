using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Medics;
using MediatR;

namespace Clinica.Application.Specialities.Queries;

public class GetSpecialitiesQuery : IRequest<IEnumerable<SpecialityDto>>;

internal class GetSpecialitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetSpecialitiesQuery, IEnumerable<SpecialityDto>>
{
    public async Task<IEnumerable<SpecialityDto>> Handle(GetSpecialitiesQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<SpecialityDto>>(context.Specialities);
    }
}