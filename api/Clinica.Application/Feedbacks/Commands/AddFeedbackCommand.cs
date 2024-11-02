using Clinica.Application.Common.Interfaces;
using Clinica.Application.Common.Services;
using Clinica.Domain.Entities;
using MediatR;

namespace Clinica.Application.Feedbacks.Commands;

public record AddFeedbackCommand: IRequest
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Message { get; set; }
    public required string Subject { get; set; }
}

internal class AddFeedbackCommandHandler(IApplicationDbContext dbContext, IDateTimeService dateTimeService) : IRequestHandler<AddFeedbackCommand>
{
    public async Task Handle(AddFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = new Feedback
        {
            FullName = request.FullName,
            Email = request.Email,
            Message = request.Message,
            Subject = request.Subject,
            Date = dateTimeService.NowUtc

        };

        dbContext.Feedbacks.Add(feedback);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}