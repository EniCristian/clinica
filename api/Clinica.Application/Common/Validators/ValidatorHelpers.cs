using FluentValidation;

namespace Clinica.Application.Common.Validators;

public class PhoneNumberValidator : AbstractValidator<string>
{
    public PhoneNumberValidator()
    {
        RuleFor(x => x).Matches(@"^[0-9+]*$").WithMessage("Phone number must contain only numbers or + sign");
    }
}

public class FullNameValidator : AbstractValidator<string>
{
    public FullNameValidator()
    {
        RuleFor(x => x).Matches(@"^[a-zA-Z- ]*$").WithMessage("Full name must contain only letters, - sign and spaces")
            .MinimumLength(3).WithMessage("Full name must contain at least 3 characters");
    }
}