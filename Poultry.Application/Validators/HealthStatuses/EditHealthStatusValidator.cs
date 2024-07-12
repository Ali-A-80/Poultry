using FluentValidation;
using Poultry.Application.Services.HealthStatuses.Commands;
using Poultry.Domain.Repositories.HealthStatuses;

namespace Poultry.Application.Validators.HealthStatuses;

public class EditHealthStatusValidator : AbstractValidator<HealthStatusEditCommand>
{
    private readonly IHealthStatusCommandRepository _healthStatusCommandRepository;

    public EditHealthStatusValidator(IHealthStatusCommandRepository healthStatusCommandRepository)
    {
        _healthStatusCommandRepository = healthStatusCommandRepository;

        RuleFor(x => x.Id).NotEmpty().WithMessage("شناسه را وارد کنید");

        RuleFor(x => x.Id).MustAsync(Exits).WithMessage("وضعیت سلامت با شناسه مورد نظر یافت نشد");

        RuleFor(x => x.BodyTemprature).NotEmpty().WithMessage("دمای بدن را وارد کنید");

        RuleFor(x => x.HealthLevel).IsInEnum().WithMessage("میزان سلامتی را به درستی وارد کنید");

        RuleFor(x => x.CheckupDate).NotEmpty().WithMessage("تاریخ چکاپ را وارد کنید");

    }

    private async Task<bool> Exits(long healthStatusId, CancellationToken cancellationToken)
    {
        return await _healthStatusCommandRepository.HealthStatusExists(healthStatusId, cancellationToken);
    }
}
