using DigitalOrder.Application.Features.User.Command.Models;
using FluentValidation;

namespace DigitalOrder.Application.Features.User.Command.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        private void ApplyValidationRules()
        {
            // Name Validation
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            // UserName Validation
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores.")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters.");

            // Email Validation
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not a valid email address.");

            // Address Validation (Optional)
            RuleFor(x => x.Address)
                .MaximumLength(100).WithMessage("Address must not exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.Address));

            // Country Validation (Optional)
            RuleFor(x => x.Country)
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.Country));

            // PhoneNumber Validation (Optional)
            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("PhoneNumber must be in a valid international format.")
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber));

        }

        private void ApplyCustomValidationRules()
        {

        }
    }
}
