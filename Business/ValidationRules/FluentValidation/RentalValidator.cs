using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        { 
            RuleFor(u => u.CarId).NotEmpty();
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.RentDate).NotEmpty();
        }
    }
}