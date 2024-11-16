using Clinica.Application.Common.Validators;
using Clinica.Common.Resources;
using FluentValidation;

namespace Clinica.Application.Appointments.Commands;

public class CreateAppointmentCommandValidator: AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentCommandValidator()
    {
        RuleFor(v => v.Email)
            .EmailAddress().WithMessage(Forms.email_validation_invalid);
        RuleFor(v => v.PhoneNumber).SetValidator(new PhoneNumberValidator());
        RuleFor(v => v.Name).SetValidator(new FullNameValidator());
    }
}
