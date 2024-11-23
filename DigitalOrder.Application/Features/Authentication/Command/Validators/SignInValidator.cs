using DigitalOrder.Application.Features.Authentication.Command.Models;
using FluentValidation;

namespace DigitalOrder.Application.Features.Authentication.Command.Validators
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        public SignInValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        private void ApplyCustomValidationRules()
        {
        }

        private void ApplyValidationRules()
        {
            // UserName Validation
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("UserName can only contain letters, numbers, and underscores.")
                .MinimumLength(3).WithMessage("UserName must be at least 3 characters length");

            // Password Validation
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
        }


    }
}
