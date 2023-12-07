using FluentValidation;
using Poultry.Domain.Entities;

namespace Poultry.Application.Validators
{
    public class HumiditySensorValidator : AbstractValidator<HumiditySensor>
    {
        public HumiditySensorValidator()
        {
            RuleFor(x => x.HumidityStatus).IsInEnum().WithMessage("وضعیت رطوبت را به درستی وارد کنید");
            RuleFor(x => x.Amount).NotEmpty().WithMessage("مقدار را وارد کنید");
        }
    }
}
