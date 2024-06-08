using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.VentilationSensors.Commands;
using Poultry.Application.Services.VentilationSensors.Dtos;
using Poultry.Persistance.Repositories.VentilationSensors;

namespace Poultry.Application.Services.VentilationSensors.Handlers;

public class EditVentilationSensorHandler : IRequestHandler<VentilationSensorEditCommand, ResultDto<VentilationSensorResponseDto>>
{

    private readonly IVentilationSensorCommandRepository _ventilationSensorCommandRepository;

    public EditVentilationSensorHandler(IVentilationSensorCommandRepository ventilationSensorCommandRepository)
    {
        _ventilationSensorCommandRepository = ventilationSensorCommandRepository;
    }

    public async Task<ResultDto<VentilationSensorResponseDto>> Handle(VentilationSensorEditCommand request, CancellationToken cancellationToken)
    {
        var ventilationSensor = await _ventilationSensorCommandRepository.GetById(request.Id, cancellationToken);

        ventilationSensor.AirFlow = ventilationSensor.AirFlow;
        ventilationSensor.VentilationStatus = ventilationSensor.VentilationStatus;
        ventilationSensor.UpdateTime = DateTime.Now;

        await _ventilationSensorCommandRepository.UpdateVentilationSensor(ventilationSensor, cancellationToken);

        return ResultDto<VentilationSensorResponseDto>.Success(new VentilationSensorResponseDto(ventilationSensor));
    }
}
