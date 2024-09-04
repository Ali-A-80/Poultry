using FluentValidation;
using Poultry.Application.Services.FoodServices.Commands;

namespace Poultry.Application.Validators.FoodServices;

public class CreateFoodServiceValidator : AbstractValidator<FoodServiceCreateCommand>
{
    public CreateFoodServiceValidator()
    {
        RuleFor(x => x.FoodType).IsInEnum().WithMessage("لطفا نوع غذا را به درستی وارد کنید");
    }
}
