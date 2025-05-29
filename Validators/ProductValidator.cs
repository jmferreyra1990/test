using backend.DTOs;
using FluentValidation;

namespace backend.Validators
{
  public class ProductValidator : AbstractValidator<ProductDto>
  {
    public ProductValidator()
    {
      RuleFor(p => p.Name).NotEmpty().MinimumLength(2);
      RuleFor(p => p.Price).GreaterThan(0);
    }
  }
}
