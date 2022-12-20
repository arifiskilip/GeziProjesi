using Entities.Cocnrete;
using FluentValidation;

namespace Business.ValidationRules.FlunetValidation
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x=> x.PersonCount).NotEmpty()
                .WithMessage("Kişi Sayısı Boş Geçilemez.");
            RuleFor(x=> x.PersonCount).GreaterThanOrEqualTo(1)
                .WithMessage("En Az Bir Kişi Olmalı.");
        }
    }
}
