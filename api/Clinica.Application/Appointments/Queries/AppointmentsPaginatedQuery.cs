using AutoMapper;
using Clinica.Application.Common.Helpers;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Models;
using MediatR;

namespace Clinica.Application.Appointments.Queries;

public record AppointmentsPaginatedQuery(PaginatedRequest Request) : IRequest<PaginatedResponse<AppointmentDto>>;

internal class AppointmentsPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<AppointmentsPaginatedQuery, PaginatedResponse<AppointmentDto>>
{
    public async Task<PaginatedResponse<AppointmentDto>> Handle(AppointmentsPaginatedQuery request, CancellationToken cancellationToken)
    {
        var appointments = await context.Appointments.GetPaginated(request.Request);

        return new PaginatedResponse<AppointmentDto>
        {
            Items = mapper.Map<List<AppointmentDto>>(appointments.Items),
            Pagination = appointments.Pagination,
            Sort = appointments.Sort
        };
    }
}