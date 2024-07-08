using FluentValidation;
using Resellio.Web.Models.Catalog;

namespace Resellio.Web.Validators
{
    public class ProductUpdateInputValidator : AbstractValidator<ProductUpdateInput>
    {
        public ProductUpdateInputValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.").ScalePrecision(2, 6).WithMessage("Price format is incorrect.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.Feature.Duration).InclusiveBetween(1, int.MaxValue).WithMessage("Duration is required.");
            RuleFor(x => x.PhotoFormFile).NotNull().WithMessage("Picture is required.");
        }
    }
}
