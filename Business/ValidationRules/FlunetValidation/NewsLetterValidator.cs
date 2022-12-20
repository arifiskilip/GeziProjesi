using Entities.Cocnrete;
using FluentValidation;

namespace Business.ValidationRules.FlunetValidation
{
    public class NewsLetterValidator : AbstractValidator<NewsLetter>
    {
        public NewsLetterValidator()
        {
            RuleFor(x=> x.Email).NotEmpty().WithMessage("Email adresi boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Doğru bir email formatı girin.");
        }
    }
}
