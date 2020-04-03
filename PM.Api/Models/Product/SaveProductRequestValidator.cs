using FluentValidation;

namespace PM.Api.Models.Product
{
    public class SaveProductRequestValidator : AbstractValidator<SaveProductRequest>
    {
        public SaveProductRequestValidator()
        {
            RuleFor(request => request.Product).NotEmpty().InjectValidator();
        }
    }
}
