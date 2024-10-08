﻿using FluentValidation;
using Resellio.Web.Models.Catalog;

namespace Resellio.Web.Validators
{
    public class ProductCreateInputValidator : AbstractValidator<ProductCreateInput>
    {
        public ProductCreateInputValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.").ScalePrecision(2, 6).WithMessage("Price format is incorrect.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.PhotoFormFile).NotNull().WithMessage("Picture is required.");
        }
    }
}
