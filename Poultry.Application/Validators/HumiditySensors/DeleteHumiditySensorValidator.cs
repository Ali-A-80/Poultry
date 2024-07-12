using FluentValidation;
using Poultry.Application.Services.HumiditySensors.Commands;
using Poultry.Domain.Repositories.HumiditySensors;

namespace Poultry.Application.Validators.HumiditySensors;


public class DeleteHumiditySensorValidator : AbstractValidator<HumiditySensorDeleteCommand>
{
    private readonly IHumiditySensorCommandRepository _humiditySensorCommandRepository;

    public DeleteHumiditySensorValidator(IHumiditySensorCommandRepository humiditySensorCommandRepository)
    {
        _humiditySensorCommandRepository = humiditySensorCommandRepository;

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("سنسور رطوبت با شناسه مورد نظر یافت نشد");
    }

    private async Task<bool> Exists(long id, CancellationToken cancellationToken)
    {
        return await _humiditySensorCommandRepository.HumiditySensorExists(id, cancellationToken);
    }
}

