using FluentValidation;
using Poultry.Application.Services.TemperatureSensors.Commands;

namespace Poultry.Application.Validators.TemperatureSensors;

public class CreateTemperatureSensorValidator : AbstractValidator<TemperatureSensorCreateCommand>
{
    public CreateTemperatureSensorValidator()
    {
        RuleFor(x => x.TemperatureStatus).IsInEnum().WithMessage("وضعیت دما را به درستی وارد کنید");
    }
}
