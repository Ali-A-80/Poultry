using FluentValidation;
using Poultry.Application.Services.Zones.Commands;
using Poultry.Domain.Repositories.Zones;

namespace Poultry.Application.Validators.Zones;


public class DeleteZoneValidator : AbstractValidator<ZoneDeleteCommand>
{
    private readonly IZoneCommandRepository _zoneCommandRepository;

    public DeleteZoneValidator(IZoneCommandRepository zoneCommandRepository)
    {
        _zoneCommandRepository = zoneCommandRepository;

        RuleFor(x => x.Id).NotEmpty().WithMessage("شناسه را وارد کنید");

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("ناحیه با شناسه مورد نظر یافت نشد");
    }

    private async Task<bool> Exists(long id, CancellationToken cancellationToken)
    {
        return await _zoneCommandRepository.ZoneExists(id, cancellationToken);
    }
}

