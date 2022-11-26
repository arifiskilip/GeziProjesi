using Entities.Cocnrete;
using FluentValidation;

namespace Business.ValidationRules.FlunetValidation
{
    public class DestinationValidator : AbstractValidator<Destination>
    {
        public DestinationValidator()
        {
            RuleFor(x=> x.Price).NotEmpty().WithMessage("Fiyat alanı boş geçilemez.");
            RuleFor(x=> x.Price).GreaterThan(0).WithMessage("Fiyat alanı 0 dan büyük olmalı.");
        }
    }
}
