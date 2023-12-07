using FluentValidation;
using Poultry.Domain.Entities;

namespace Poultry.Application.Validators
{
    public class FoodServiceValidator : AbstractValidator<FoodService>
    {
        public FoodServiceValidator()
        {

            RuleFor(x => x.Amount).NotEmpty().WithMessage("لطفا مقدار را وارد کنید");
            RuleFor(x => x.FoodType).IsInEnum().WithMessage("لطفا نوع غذا را به درستی وارد کنید");
        }
    }
}
