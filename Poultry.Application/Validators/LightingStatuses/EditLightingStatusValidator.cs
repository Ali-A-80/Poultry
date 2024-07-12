using FluentValidation;
using Poultry.Application.Services.LightingStatuses.Commands;
using Poultry.Domain.Repositories.LightingStatuses;

namespace Poultry.Application.Validators.LightingStatuses;

public class EditLightingStatusValidator : AbstractValidator<LightingStatusEditCommand>
{
    private readonly ILightingStatusCommandRepository _lightingStatusCommandRepository;

    public EditLightingStatusValidator(ILightingStatusCommandRepository lightingStatusCommandRepository)
    {
        _lightingStatusCommandRepository = lightingStatusCommandRepository;

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("وضعیت روشنایی با شناسه مورد نظر یافت نشد");

        RuleFor(x => x.LightingStatusType).IsInEnum()
            .WithMessage("وضعیت روشنایی را به درستی وارد کنید");

        RuleFor(x => x.Amount).NotEmpty().Must(x => x <= 100 && x >= 0).WithMessage("مقدار وارد شده خارج از محدوده می باشد");
    }

    private async Task<bool> Exists(long id, CancellationToken cancellationToken)
    {
        return await _lightingStatusCommandRepository.LightingStatusExists(id, cancellationToken);
    }
}
