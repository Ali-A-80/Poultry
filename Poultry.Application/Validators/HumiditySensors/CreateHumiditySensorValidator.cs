using FluentValidation;
using Poultry.Application.Services.HumiditySensors.Commands;

namespace Poultry.Application.Validators.HumiditySensors
{
    public class CreateHumiditySensorValidator : AbstractValidator<HumiditySensorCreateCommand>
    {
        public CreateHumiditySensorValidator()
        {
            RuleFor(x => x.HumidityStatus).IsInEnum().WithMessage("وضعیت رطوبت را به درستی وارد کنید");

            RuleFor(x => x.Amount).NotEmpty().WithMessage("مقدار را وارد کنید");
        }
    }
}
