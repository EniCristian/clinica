using AutoMapper;
using Clinica.Application.Common.Helpers;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Models;
using Clinica.Application.Medics;
using Clinica.Application.Specialities.Queries;
using MediatR;

namespace Clinica.Application.Appointments.Queries;

public class GetSpecialitiesAppointmentsQuery(PaginatedRequest Request) : IRequest<PaginatedResponse<SpecialityDto>>;

internal class GetAllAppointmentsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetSpecialitiesPaginatedQuery, PaginatedResponse<SpecialityDto>>
{
    public async Task<PaginatedResponse<SpecialityDto>> Handle(GetSpecialitiesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var specialities = await context.Specialities.GetPaginated(request.Request, true);

        return new PaginatedResponse<SpecialityDto>
        {
            Items = mapper.Map<List<SpecialityDto>>(specialities.Items),
            Pagination = specialities.Pagination,
            Sort = specialities.Sort
        };
    }
}