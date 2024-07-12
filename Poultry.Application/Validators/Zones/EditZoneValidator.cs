using FluentValidation;
using Poultry.Application.Services.Zones.Commands;
using Poultry.Domain.Repositories.Zones;

namespace Poultry.Application.Validators.Zones;

public class EditZoneValidator : AbstractValidator<ZoneEditCommand>
{
    private readonly IZoneCommandRepository _zoneCommandRepository;

    public EditZoneValidator(IZoneCommandRepository zoneCommandRepository)
    {
        _zoneCommandRepository = zoneCommandRepository;

        RuleFor(x => x.Id).NotEmpty().WithMessage("شناسه را وارد کنید");

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("ناحیه با شناسه مورد نظر یافت نشد");

        RuleFor(x => x.ZoneType).IsInEnum().WithMessage("نوع ناحیه را به درستی مشخص کنید");
    }

    private async Task<bool> Exists(long id, CancellationToken cancellationToken)
    {
        return await _zoneCommandRepository.ZoneExists(id, cancellationToken);
    }
}
