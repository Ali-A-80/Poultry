using FluentValidation;
using Poultry.Application.Services.Zones.Commands;

namespace Poultry.Application.Validators.Zones;

public class CreateZoneValidator : AbstractValidator<ZoneCreateCommand>
{
    public CreateZoneValidator()
    {
        RuleFor(x => x.ZoneType).IsInEnum().WithMessage("نوع ناحیه را به درستی مشخص کنید");
    }
}
