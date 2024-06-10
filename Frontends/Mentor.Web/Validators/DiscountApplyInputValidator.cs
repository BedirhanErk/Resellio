using FluentValidation;
using Resellio.Web.Models.Discount;

namespace Resellio.Web.Validators
{
    public class DiscountApplyInputValidator : AbstractValidator<DiscountApplyInput>
    {
        public DiscountApplyInputValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Discount code is required.");
        }
    }
}
