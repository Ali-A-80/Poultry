using FluentValidation;
using Poultry.Domain.Entities;

namespace Poultry.Application.Validators
{
    public class LightingStatusValidator : AbstractValidator<LightingStatus>
    {
        public LightingStatusValidator()
        {
            RuleFor(x => x.LightingStatusType).IsInEnum()
                .WithMessage("وضعیت روشنایی را به درستی وارد کنید");

            RuleFor(x => x.Amount).NotEmpty()
                .WithMessage("مقدار را وارد کنید")
                .Must(x => x<=100 && x>=0 ).WithMessage("مقدار وارد شده خارج از محدوده می باشد");
        }
    }
}
