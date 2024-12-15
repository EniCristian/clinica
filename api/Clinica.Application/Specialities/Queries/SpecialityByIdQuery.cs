using AutoMapper;
using Clinica.Application.Common.Interfaces;
using Clinica.Application.Medics;
using Clinica.Common.Exceptions;
using Clinica.Domain.Entities;
using MediatR;

namespace Clinica.Application.Specialities.Queries;

public record GetSpecialityByIdQuery(Guid Id) : IRequest<SpecialityDto>;

internal class GetSpecialityByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetSpecialityByIdQuery, SpecialityDto>
{
    public async Task<SpecialityDto> Handle(GetSpecialityByIdQuery request, CancellationToken cancellationToken)
    {
        var speciality = await context.Specialities.FindAsync(request.Id, cancellationToken);
        if (speciality == null)
        {
            throw new NotFoundException(nameof(Speciality), request.Id);
        }

        return mapper.Map<SpecialityDto>(speciality);
    }
}