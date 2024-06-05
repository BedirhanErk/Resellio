using FluentValidation;
using Mentor.Web.Models.Discount;

namespace Mentor.Web.Validators
{
    public class DiscountApplyInputValidator : AbstractValidator<DiscountApplyInput>
    {
        public DiscountApplyInputValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Discount code is required.");
        }
    }
}
