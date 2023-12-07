using FluentValidation;
using Poultry.Domain.Entities;

namespace Poultry.Application.Validators
{
    public class ZoneValidator : AbstractValidator<Zone>
    {
        public ZoneValidator()
        {

            RuleFor(x => x.ZoneType).IsInEnum().WithMessage("نوع ناحیه را به درستی مشخص کنید");
        }
    }
}
