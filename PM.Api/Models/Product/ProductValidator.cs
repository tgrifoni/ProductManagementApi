using FluentValidation;
using System;

namespace PM.Api.Models.Product
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        private const string CodeRegex = @"^[A-Za-z]{3}-\d{4}$";
        private readonly DateTime MinDate = new DateTime(1753, 1, 1);
        private readonly DateTime MaxDate = new DateTime(9999, 12, 31);

        public ProductValidator()
        {
            RuleFor(product => product.Id).GreaterThanOrEqualTo(0);
            RuleFor(product => product.Name).NotEmpty().MaximumLength(100);
            RuleFor(product => product.Code).NotEmpty().Length(8).Matches(CodeRegex);
            RuleFor(product => product.Category).NotEqual(ProductCategoryDTO.Unknown);
            RuleFor(product => product.Description).MaximumLength(200);
            RuleFor(product => product.ReleaseDate).InclusiveBetween(MinDate, MaxDate);
            RuleFor(product => product.Price).NotEmpty().ScalePrecision(2, 7).InclusiveBetween(0.01m, 99999.99m);
            RuleFor(product => product.Rating).InclusiveBetween(0, 5);
        }
    }
}
