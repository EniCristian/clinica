using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Common.Exceptions;
using Clinica.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Medics.Queries;

public record GetMedicByIdQuery(Guid Id) : IRequest<MedicDto>;

internal class GetMedicByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetMedicByIdQuery, MedicDto>
{
    public async Task<MedicDto> Handle(GetMedicByIdQuery request, CancellationToken cancellationToken)
    {
        var medic = await context.Medics.Include(x => x.Speciality).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (medic == null)
        {
            throw new NotFoundException(nameof(Medic), request.Id);
        }
        return mapper.Map<MedicDto>(medic);
    }
}