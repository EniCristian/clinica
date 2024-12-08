using AutoMapper;
using Clinica.Application.Common.Helpers;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Models;
using Clinica.Application.Medics;
using MediatR;

namespace Clinica.Application.Specialities.Queries;

public record GetSpecialitiesPaginatedQuery(PaginatedRequest Request) : IRequest<PaginatedResponse<SpecialityDto>>;

internal class GetSpecialitiesPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetSpecialitiesPaginatedQuery, PaginatedResponse<SpecialityDto>>
{
    public async Task<PaginatedResponse<SpecialityDto>> Handle(GetSpecialitiesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var specialities = await context.Specialities.GetPaginated(request.Request);

        return new PaginatedResponse<SpecialityDto>
        {
            Items = mapper.Map<List<SpecialityDto>>(specialities.Items),
            Pagination = specialities.Pagination,
            Sort = specialities.Sort
        };
    }
}