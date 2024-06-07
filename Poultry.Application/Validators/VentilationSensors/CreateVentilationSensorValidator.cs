using FluentValidation;
using Poultry.Application.Services.VentilationSensors.Commands;

namespace Poultry.Application.Validators.VentilationSensors;

public class CreateVentilationSensorValidator : AbstractValidator<VentilationSensorCreateCommand>
{
    public CreateVentilationSensorValidator()
    {
        RuleFor(x => x.VentilationStatus).IsInEnum().WithMessage("وضعیت تهویه را به درستی وارد کنید");

        RuleFor(x => x.AirFlow).NotNull().WithMessage("مقدار جریان هوا را وارد کنید");
    }
}
