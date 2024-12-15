using Clinica.Application.Common.Interfaces;
using Clinica.Domain.Entities;
using MediatR;

namespace Clinica.Application.Specialities.Commands.CreateSpeciality;

public class CreateSpecialityCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? ImageUrl { get; set; }
    public uint ConsultationDurationInMinutes { get; set; }
}

public class CreateSpecialityCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateSpecialityCommand, Guid>
{
    public async Task<Guid> Handle(CreateSpecialityCommand request, CancellationToken cancellationToken)
    {
        var entity = new Speciality
        {
            Name = request.Name,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            ConsultationDurationInMinutes = request.ConsultationDurationInMinutes
        };

        context.Specialities.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}