﻿using FluentValidation;
using Poultry.Application.Services.TemperatureSensors.Commands;
using Poultry.Persistance.Repositories.TemperatureSensors;

namespace Poultry.Application.Validators.TemperatureSensors;

public class EditTemperatureSensorValidator : AbstractValidator<TemperatureSensorEditCommand>
{
    private readonly ITemperatureSensorCommandRepository _temperatureSensorCommandRepository;

    public EditTemperatureSensorValidator(ITemperatureSensorCommandRepository temperatureSensorCommandRepository)
    {
        _temperatureSensorCommandRepository = temperatureSensorCommandRepository;

        RuleFor(x => x.Id).NotEmpty().WithMessage("شناسه را وارد کنید");

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("سنسور دما با شناسه مورد نظر یافت نشد");

        RuleFor(x => x.TemperatureStatus).IsInEnum().WithMessage("وضعیت دما را به درستی وارد کنید");

        RuleFor(x => x.Amount).NotNull().WithMessage("مقدار را وارد کنید");
    }

    private async Task<bool> Exists(long temperatureSensorId, CancellationToken cancellationToken)
    {
        return await _temperatureSensorCommandRepository.TemperatureSensorExists(temperatureSensorId, cancellationToken);
    }
}