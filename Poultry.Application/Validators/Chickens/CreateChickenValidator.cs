using FluentValidation;
using Poultry.Application.Services.Chickens.Commands;

namespace Poultry.Application.Validators.Chickens;

public class CreateChickenValidator : AbstractValidator<CreateChickenCommand>
{
    public CreateChickenValidator()
    {
        RuleFor(x => x.Age).Must(x => x >= 0 && x <= 255).WithMessage("محدوده سنی را به درستی وارد کنید");

        RuleFor(x => x.ChickenType).IsInEnum().WithMessage("لطفا نوع طیر را به درستی وارد کنید");
    }
}
