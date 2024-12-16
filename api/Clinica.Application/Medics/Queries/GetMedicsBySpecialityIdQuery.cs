using AutoMapper;
using Clinica.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Medics.Queries;

public record GetMedicsBySpecialityIdQuery(Guid SpecialityId) : IRequest<List<MedicDto>>;

internal class GetMedicsBySpecialityIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetMedicsBySpecialityIdQuery, List<MedicDto>>
{
    public async Task<List<MedicDto>> Handle(GetMedicsBySpecialityIdQuery request, CancellationToken cancellationToken)
    {
        var medics = await context.Medics
            .Include(x => x.Speciality)
            .Where(x => x.Speciality.Id == request.SpecialityId)
            .OrderBy(x => x.LastName)
            .ToListAsync(cancellationToken);

        return mapper.Map<List<MedicDto>>(medics);
    }
}