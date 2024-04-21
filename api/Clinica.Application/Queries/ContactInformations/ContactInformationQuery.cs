using AutoMapper;
using Clinica.Application.Interfaces;
using Clinica.Application.Queries.ContactInformations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Queries.ContactInformation;

public record ContactInformationQuery : IRequest<ContactInformationDto>;

internal class ContactInformationQueryHandler : IRequestHandler<ContactInformationQuery, ContactInformationDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ContactInformationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ContactInformationDto> Handle(ContactInformationQuery request,
        CancellationToken cancellationToken)
    {
        var contactInformation =
            await _context.ContactInformations.Include(p=>p.Address).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        return _mapper.Map<ContactInformationDto>(contactInformation);
    }
}