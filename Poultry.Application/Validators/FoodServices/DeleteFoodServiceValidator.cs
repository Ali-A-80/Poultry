using FluentValidation;
using Poultry.Application.Services.FoodServices.Commands;
using Poultry.Domain.Repositories.FoodServices;

namespace Poultry.Application.Validators.FoodServices;

public class DeleteFoodServiceValidator : AbstractValidator<FoodServiceDeleteCommand>
{
    private readonly IFoodServiceCommandRepository _foodServiceCommandRepository;

    public DeleteFoodServiceValidator(IFoodServiceCommandRepository foodServiceCommandRepository)
    {
        _foodServiceCommandRepository = foodServiceCommandRepository;

        RuleFor(x => x.Id).NotEmpty().WithMessage("شناسه را وارد کنید");

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("سرویس مورد نظر یافت نشد");
    }

    private async Task<bool> Exists(long id, CancellationToken cancellationToken)
    {
        return await _foodServiceCommandRepository.FoodServiveExists(id, cancellationToken);
    }

}

