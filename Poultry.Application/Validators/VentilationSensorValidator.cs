using FluentValidation;
using Poultry.Domain.Entities;

namespace Poultry.Application.Validators
{
    public class VentilationSensorValidator : AbstractValidator<VentilationSensor>
    {
        public VentilationSensorValidator()
        {
            RuleFor(x => x.VentilationStatus).IsInEnum().WithMessage("وضعیت تهویه را به درستی وارد کنید");
            RuleFor(x => x.AirFlow).NotEmpty().WithMessage("مقدار جریان هوا را وارد کنید");
        }
    }
}
