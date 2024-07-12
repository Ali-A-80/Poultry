using FluentValidation;
using Poultry.Application.Services.HealthStatuses.Commands;
using Poultry.Domain.Repositories.HealthStatuses;

namespace Poultry.Application.Validators.HealthStatuses;


public class DeleteHealthStatusValidator : AbstractValidator<HealthStatusDeleteCommand>
{
    private readonly IHealthStatusCommandRepository _healthStatusCommandRepository;

    public DeleteHealthStatusValidator(IHealthStatusCommandRepository healthStatusCommandRepository)
    {
        _healthStatusCommandRepository = healthStatusCommandRepository;

        RuleFor(x => x.Id).NotEmpty().WithMessage("شناسه را وارد کنید");

        RuleFor(x => x.Id).MustAsync(Exits).WithMessage("وضعیت سلامت با شناسه مورد نظر یافت نشد");
    }

    private async Task<bool> Exits(long healthStatusId, CancellationToken cancellationToken)
    {
        return await _healthStatusCommandRepository.HealthStatusExists(healthStatusId, cancellationToken);
    }
}

