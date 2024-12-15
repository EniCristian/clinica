using Clinica.Application.Common.Interfaces;
using Clinica.Common.Exceptions;
using Clinica.Domain.Entities;
using MediatR;

namespace Clinica.Application.Specialities.Commands.EditSpeciality;

public class EditSpecialityCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public uint ConsultationDurationInMinutes { get; set; }
}

public class EditSpecialityCommandHandler(IApplicationDbContext context)
    : IRequestHandler<EditSpecialityCommand>
{
    public async Task Handle(EditSpecialityCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Specialities.FindAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Speciality));
        }

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.ImageUrl = request.ImageUrl;
        entity.ConsultationDurationInMinutes = request.ConsultationDurationInMinutes;

        await context.SaveChangesAsync(cancellationToken);
    }
}