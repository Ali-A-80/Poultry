using FluentValidation;
using Poultry.Application.Services.FoodServices.Commands;
using Poultry.Domain.Repositories.FoodServices;

namespace Poultry.Application.Validators.FoodServices;

public class EditFoodServiceValidator : AbstractValidator<FoodServiceEditCommand>
{
    private readonly IFoodServiceCommandRepository _foodServiceCommandRepository;

    public EditFoodServiceValidator(IFoodServiceCommandRepository foodServiceCommandRepository)
    {
        _foodServiceCommandRepository = foodServiceCommandRepository;

        RuleFor(x => x.Id).NotEmpty().WithMessage("شناسه سرویس را وارد کنید");

        RuleFor(x => x.Id).MustAsync(Exits).WithMessage("سرویس با شناسه مورد نظر یافت نشد");

        RuleFor(x => x.Amount).NotNull().WithMessage("لطفا مقدار را وارد کنید");

        RuleFor(x => x.FoodType).IsInEnum().WithMessage("لطفا نوع غذا را به درستی وارد کنید");
    }

    private async Task<bool> Exits(long foodserviceId, CancellationToken cancellationToken)
    {
        return await _foodServiceCommandRepository.FoodServiveExists(foodserviceId, cancellationToken);
    }
}
