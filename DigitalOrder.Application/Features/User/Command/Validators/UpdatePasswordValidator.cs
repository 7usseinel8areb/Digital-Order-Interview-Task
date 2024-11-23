using DigitalOrder.Application.Features.User.Command.Models;
using FluentValidation;

namespace DigitalOrder.Application.Features.User.Command.Validators
{
    public class UpdatePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public UpdatePasswordValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        private void ApplyCustomValidationRules()
        {
        }

        private void ApplyValidationRules()
        {
            // CurrentPassword validation (ensure it is not empty)
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Current password is required.");

            // NewPassword validation (ensure it's not empty and meets password complexity rules)
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.")
                .MinimumLength(8).WithMessage("New password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("New password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("New password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("New password must contain at least one digit.");
            //.Matches(@"[\W_]").WithMessage("New password must contain at least one special character.");

            // ConfirmNewPassword validation (ensure it matches the NewPassword)
            RuleFor(x => x.ConfirmNewPassword)
                .Equal(x => x.NewPassword).WithMessage("New password and confirmation password do not match.");

            // Ensure NewPassword is different from CurrentPassword
            RuleFor(x => new { x.CurrentPassword, x.NewPassword })
                .Must(x => x.CurrentPassword != x.NewPassword)
                .WithMessage("New password cannot be the same as the current password.");
        }
    }
}
