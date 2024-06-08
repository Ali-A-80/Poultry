using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.HumiditySensors.Commands;
using Poultry.Application.Services.HumiditySensors.Dtos;
using Poultry.Domain.Entities;
using Poultry.Persistance.Repositories.HumiditySensors;
using Poultry.Persistance.Repositories.Zones;

namespace Poultry.Application.Services.HumiditySensors.Handlers;

public class CreateHumiditySensorHandler : IRequestHandler<HumiditySensorCreateCommand, ResultDto<HumiditySensorResponseDto>>
{
    private readonly IHumiditySensorCommandRepository _humiditySensorCommandRepository;
    private readonly IZoneCommandRepository _zoneCommandRepository;

    public CreateHumiditySensorHandler(IHumiditySensorCommandRepository humiditySensorCommandRepository, IZoneCommandRepository zoneCommandRepository)
    {
        _humiditySensorCommandRepository = humiditySensorCommandRepository;
        _zoneCommandRepository = zoneCommandRepository;
    }

    public async Task<ResultDto<HumiditySensorResponseDto>> Handle(HumiditySensorCreateCommand request, CancellationToken cancellationToken)
    {
        var zone = await _zoneCommandRepository.GetById(request.ZoneId, cancellationToken);

        if (zone is null)
            return ResultDto<HumiditySensorResponseDto>.Failure(new List<string> { "ناحیه مورد نظر یافت نشد" });

        var humiditySensor = new HumiditySensor()
        {
            Amount = request.Amount,
            HumidityStatus = request.HumidityStatus,
            ZoneId = zone.Id
        };

        await _humiditySensorCommandRepository.AddHumiditySensor(humiditySensor, cancellationToken);

        return ResultDto<HumiditySensorResponseDto>.Success(new HumiditySensorResponseDto(humiditySensor));
    }

}
