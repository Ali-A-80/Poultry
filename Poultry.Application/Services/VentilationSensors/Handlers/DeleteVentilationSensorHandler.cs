using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.VentilationSensors.Commands;
using Poultry.Domain.Repositories.VentilationSensors;

namespace Poultry.Application.Services.VentilationSensors.Handlers;

public class DeleteVentilationSensorHandler : IRequestHandler<VentilationSensorDeleteCommand, ResultDto<Unit>>
{

    private readonly IVentilationSensorCommandRepository _ventilationSensorCommandRepository;

    public DeleteVentilationSensorHandler(IVentilationSensorCommandRepository ventilationSensorCommandRepository)
    {
        _ventilationSensorCommandRepository = ventilationSensorCommandRepository;
    }

    public async Task<ResultDto<Unit>> Handle(VentilationSensorDeleteCommand request, CancellationToken cancellationToken)
    {
        var ventilationSensor = await _ventilationSensorCommandRepository.GetById(request.Id, cancellationToken);

        ventilationSensor.IsRemoved = true;
        ventilationSensor.RemoveTime = DateTime.Now;

        await _ventilationSensorCommandRepository.UpdateVentilationSensor(ventilationSensor, cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }

}
