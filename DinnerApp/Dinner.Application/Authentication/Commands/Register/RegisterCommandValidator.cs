using DinnerApp.Application.Authentication.Commands.Register;
using FluentValidation;

namespace Dinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.email).NotEmpty().EmailAddress();
            RuleFor(x => x.password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.firstName).NotEmpty();
            RuleFor(x => x.lastName).NotEmpty();
        }
    }
}