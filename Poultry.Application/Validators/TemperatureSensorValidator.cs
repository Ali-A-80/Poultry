using FluentValidation;
using Poultry.Domain.Entities;

namespace Poultry.Application.Validators
{
    public class TemperatureSensorValidator : AbstractValidator<TemperatureSensor>
    {
        public TemperatureSensorValidator()
        {
            RuleFor(x => x.TemperatureStatus).IsInEnum().WithMessage("وضعیت دما را به درستی وارد کنید");
            RuleFor(x => x.Amount).NotEmpty().WithMessage("مقدار را وارد کنید");
        }
    }
}
