using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.TemperatureSensors.Commands;
using Poultry.Application.Services.TemperatureSensors.Dtos;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.TemperatureSensors;
using Poultry.Domain.Repositories.Zones;

namespace Poultry.Application.Services.TemperatureSensors.Handlers;

public class CreateTemperatureSensorHandler : IRequestHandler<TemperatureSensorCreateCommand, ResultDto<TemperatureSensorResponseDto>>
{

    private readonly ITemperatureSensorCommandRepository _temperatureSensorCommandRepository;
    private readonly IZoneCommandRepository _zoneCommandRepository;

    public CreateTemperatureSensorHandler(ITemperatureSensorCommandRepository temperatureSensorCommandRepository,
                                          IZoneCommandRepository zoneCommandRepository)
    {
        _temperatureSensorCommandRepository = temperatureSensorCommandRepository;
        _zoneCommandRepository = zoneCommandRepository;
    }
    public async Task<ResultDto<TemperatureSensorResponseDto>> Handle(TemperatureSensorCreateCommand request, CancellationToken cancellationToken)
    {
        var zone = await _zoneCommandRepository.GetById(request.ZoneId, cancellationToken);

        if (zone is null)
            return ResultDto<TemperatureSensorResponseDto>.Failure(new List<string> { "ناحیه مورد نظر یافت نشد" });

        var temperatureSensor = new TemperatureSensor()
        {
            Amount = request.Amount,
            TemperatureStatus = request.TemperatureStatus,
            ZoneId = zone.Id
        };

        await _temperatureSensorCommandRepository.AddTemperatureSensor(temperatureSensor, cancellationToken);

        return ResultDto<TemperatureSensorResponseDto>.Success(new TemperatureSensorResponseDto(temperatureSensor));
    }

}
