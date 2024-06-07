using FluentValidation;
using Poultry.Application.Services.VentilationSensors.Commands;
using Poultry.Persistance.Repositories.VentilationSensors;

namespace Poultry.Application.Validators.VentilationSensors;


public class DeleteVentilationSensorValidator : AbstractValidator<VentilationSensorDeleteCommand>
{
    private readonly IVentilationSensorCommandRepository _ventilationSensorCommandRepository;

    public DeleteVentilationSensorValidator(IVentilationSensorCommandRepository ventilationSensorCommandRepository)
    {
        _ventilationSensorCommandRepository = ventilationSensorCommandRepository;

        RuleFor(x => x.Id).NotEmpty().WithMessage("شناسه را وارد کنید");

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("سنسور تهویه با شناسه مورد نظر یافت نشد");
    }

    private async Task<bool> Exists(long id, CancellationToken cancellationToken)
    {
        return await _ventilationSensorCommandRepository.VentilationSensorExists(id, cancellationToken);
    }
}

