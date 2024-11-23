using AutoMapper;
using Clinica.Application.Common.Helpers;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Models;
using Clinica.Application.Medics;
using Clinica.Application.Specialities.Queries;
using MediatR;

namespace Clinica.Application.Appointments.Queries;

public class GetAllAppointmentsQuery(PaginatedRequest Request) : IRequest<PaginatedResponse<SpecialityDto>>;

internal class GetAllAppointmentsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetSpecialitiesQuery, PaginatedResponse<SpecialityDto>>
{
    public async Task<PaginatedResponse<SpecialityDto>> Handle(GetSpecialitiesQuery request, CancellationToken cancellationToken)
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