using FluentValidation;

namespace Clinica.Application.Specialities.Commands.EditSpeciality;

public class EditSpecialityCommandValidator : AbstractValidator<EditSpecialityCommand>
{
    public EditSpecialityCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Description)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.ImageUrl)
            .MaximumLength(200);
        RuleFor(v => v.ConsultationDurationInMinutes)
            .NotEmpty()
            .GreaterThan(x=>0);
    }
}