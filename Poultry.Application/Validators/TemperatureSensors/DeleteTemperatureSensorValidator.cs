using FluentValidation;
using Poultry.Application.Services.TemperatureSensors.Commands;
using Poultry.Domain.Repositories.TemperatureSensors;

namespace Poultry.Application.Validators.TemperatureSensors;


public class DeleteTemperatureSensorValidator : AbstractValidator<TemperatureSensorDeleteCommand>
{
    private readonly ITemperatureSensorCommandRepository _temperatureSensorCommandRepository;

    public DeleteTemperatureSensorValidator(ITemperatureSensorCommandRepository temperatureSensorCommandRepository)
    {
        _temperatureSensorCommandRepository = temperatureSensorCommandRepository;

        RuleFor(x => x.Id).NotEmpty().WithMessage("شناسه را وارد کنید");

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("سنسور دما با شناسه مورد نظر یافت نشد");
    }

    private async Task<bool> Exists(long temperatureSensorId, CancellationToken cancellationToken)
    {
        return await _temperatureSensorCommandRepository.TemperatureSensorExists(temperatureSensorId, cancellationToken);
    }
}

