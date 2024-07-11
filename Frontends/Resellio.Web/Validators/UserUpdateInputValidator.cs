using FluentValidation;
using Resellio.Web.Models;

namespace Resellio.Web.Validators
{
    public class UserUpdateInputValidator : AbstractValidator<UserUpdateInput>
    {
        public UserUpdateInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
        }
    }
}
