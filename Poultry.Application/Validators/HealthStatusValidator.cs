using FluentValidation;
using Poultry.Domain.Entities;

namespace Poultry.Application.Validators
{
    public class HealthStatusValidator : AbstractValidator<HealthStatus>
    {
        public HealthStatusValidator()
        {
            RuleFor(x => x.BodyTemprature).NotEmpty().WithMessage("دمای بدن را وارد کنید");
            RuleFor(x => x.HealthLevel).IsInEnum().WithMessage("میزان سلامتی را به درستی وارد کنید");
            RuleFor(x => x.CheckupDate).NotEmpty().WithMessage("تاریخ چکاپ را وارد کنید");
        }
    }
}
