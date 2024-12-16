using AutoMapper;
using Clinica.Application.Common.Helpers;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Models;
using MediatR;

namespace Clinica.Application.Medics;

public record MedicsPaginatedQuery(PaginatedRequest Request) : IRequest<PaginatedResponse<MedicDto>>;

internal class MedicsPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<MedicsPaginatedQuery, PaginatedResponse<MedicDto>>
{
    public async Task<PaginatedResponse<MedicDto>> Handle(MedicsPaginatedQuery request, CancellationToken cancellationToken)
    {
        var medicsResponse = await context.Medics.GetPaginated(request.Request, true);

        return new PaginatedResponse<MedicDto>
        {
            Items = mapper.Map<List<MedicDto>>(medicsResponse.Items),
            Pagination = medicsResponse.Pagination,
            Sort = medicsResponse.Sort
        };
    }
}