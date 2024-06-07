using FluentValidation;
using Poultry.Application.Services.Chickens.Commands;
using Poultry.Persistance.Repositories.Chickens;

namespace Poultry.Application.Validators.Chickens;

public class EditChickenValidator : AbstractValidator<EditChickenCommand>
{
    private readonly IChickenCommandRepository _chickenCommandRepository;

    public EditChickenValidator(IChickenCommandRepository chickenCommandRepository)
    {
        _chickenCommandRepository = chickenCommandRepository;

        RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("مرغ با شناسه وارد شده وجود ندارد");

        RuleFor(x => x.Gender).NotNull().WithMessage("لطفا جنسیت را وارد کنید");

        RuleFor(x => x.Age).NotEmpty().WithMessage("لطفا مقدار سن را وارد کنید")
            .Must(x => x >= 0 && x <= 255).WithMessage("محدوده سنی را به درستی وارد کنید");

        RuleFor(x => x.ChickenType).IsInEnum().WithMessage("لطفا نوع طیر را به درستی وارد کنید");

        RuleFor(x => x.Weight).NotEmpty().WithMessage("لطفا وزن را وارد کنید");
    }

    private async Task<bool> Exists(long id, CancellationToken cancellationToken)
    {
        return await _chickenCommandRepository.ChickenExists(id, cancellationToken);
    }
}
