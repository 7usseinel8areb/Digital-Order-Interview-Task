using DigitalOrder.Application.Features.User.Command.Models;
using FluentValidation;

namespace DigitalOrder.Application.Features.User.Command.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
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
                .NotEmpty().WithMessage("UserName is required.")
                .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("UserName can only contain letters, numbers, and underscores.")
                .Length(3, 20).WithMessage("UserName must be between 3 and 20 characters.");

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

            // Password Validation
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.");
            //.Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

            // ConfirmPassword Validation
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("ConfirmPassword is required.")
                .Equal(x => x.Password).WithMessage("Passwords do not match.");
        }
        private void ApplyCustomValidationRules()
        {

        }
    }
}
