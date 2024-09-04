using FluentValidation;
using Poultry.Application.Services.LightingStatuses.Commands;
using Poultry.Domain.Repositories.LightingStatuses;

namespace Poultry.Application.Validators.LightingStatuses;


public class DeleteLightingStatusValidator : AbstractValidator<LightingStatusDeleteCommand>
{
    private readonly ILightingStatusCommandRepository _lightingStatusCommandRepository;

    public DeleteLightingStatusValidator(ILightingStatusCommandRepository lightingStatusCommandRepository)
    {
        _lightingStatusCommandRepository = lightingStatusCommandRepository;

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("وضعیت روشنایی با شناسه مورد نظر یافت نشد");
    }

    private async Task<bool> Exists(long id, CancellationToken cancellationToken)
    {
        return await _lightingStatusCommandRepository.LightingStatusExists(id, cancellationToken);
    }
}

