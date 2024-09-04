using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.VentilationSensors.Commands;
using Poultry.Application.Services.VentilationSensors.Dtos;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.VentilationSensors;
using Poultry.Domain.Repositories.Zones;

namespace Poultry.Application.Services.VentilationSensors.Handlers;

public class CreateVentilationSensorHandler : IRequestHandler<VentilationSensorCreateCommand, ResultDto<VentilationSensorResponseDto>>
{

    private readonly IVentilationSensorCommandRepository _ventilationSensorCommandRepository;
    private readonly IZoneCommandRepository _zoneCommandRepository;

    public CreateVentilationSensorHandler(IVentilationSensorCommandRepository ventilationSensorCommandRepository,
                                          IZoneCommandRepository zoneCommandRepository)
    {
        _ventilationSensorCommandRepository = ventilationSensorCommandRepository;
        _zoneCommandRepository = zoneCommandRepository;
    }
    public async Task<ResultDto<VentilationSensorResponseDto>> Handle(VentilationSensorCreateCommand request, CancellationToken cancellationToken)
    {
        var zone = await _zoneCommandRepository.GetById(request.ZoneId, cancellationToken);

        if (zone is null)
            return ResultDto<VentilationSensorResponseDto>.Failure(new List<string> { "ناحیه مورد نظر یافت نشد" });

        var ventilationSensor = new VentilationSensor()
        {
            AirFlow = request.AirFlow,
            VentilationStatus = request.VentilationStatus,
            ZoneId = zone.Id
        };

        await _ventilationSensorCommandRepository.AddVentilationSensor(ventilationSensor, cancellationToken);

        return ResultDto<VentilationSensorResponseDto>.Success(new VentilationSensorResponseDto(ventilationSensor));
    }

}
