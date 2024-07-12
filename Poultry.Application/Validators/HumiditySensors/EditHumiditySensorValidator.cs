using FluentValidation;
using Poultry.Application.Services.HumiditySensors.Commands;
using Poultry.Domain.Repositories.HumiditySensors;

namespace Poultry.Application.Validators.HumiditySensors;

public class EditHumiditySensorValidator : AbstractValidator<HumiditySensorEditCommand>
{
    private readonly IHumiditySensorCommandRepository _humiditySensorCommandRepository;

    public EditHumiditySensorValidator(IHumiditySensorCommandRepository humiditySensorCommandRepository)
    {
        _humiditySensorCommandRepository = humiditySensorCommandRepository;

        RuleFor(x => x.Id).MustAsync(Exits).WithMessage("سنسور رطوبت با شناسه مورد نظر یافت نشد");

        RuleFor(x => x.HumidityStatus).IsInEnum().WithMessage("وضعیت رطوبت را به درستی وارد کنید");
    }

    private async Task<bool> Exits(long id, CancellationToken cancellationToken)
    {
        return await _humiditySensorCommandRepository.HumiditySensorExists(id, cancellationToken);
    }
}
