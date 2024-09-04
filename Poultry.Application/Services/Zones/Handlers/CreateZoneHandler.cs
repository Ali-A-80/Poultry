using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Zones.Commands;
using Poultry.Application.Services.Zones.Dtos;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.LightingStatuses;
using Poultry.Domain.Repositories.Zones;

namespace Poultry.Application.Services.Zones.Handlers;

public class CreateZoneHandler : IRequestHandler<ZoneCreateCommand, ResultDto<ZoneResponseDto>>
{
    private readonly ILightingStatusCommandRepository _lightingStatusCommandRepository;
    private readonly IZoneCommandRepository _zoneCommandRepository;

    public CreateZoneHandler(ILightingStatusCommandRepository lightingStatusCommandRepository,
                             IZoneCommandRepository zoneCommandRepository)
    {
        _lightingStatusCommandRepository = lightingStatusCommandRepository;
        _zoneCommandRepository = zoneCommandRepository;
    }
    public async Task<ResultDto<ZoneResponseDto>> Handle(ZoneCreateCommand request, CancellationToken cancellationToken)
    {
        var zone = new Zone()
        {
            ZoneType = request.ZoneType
        };

        await _zoneCommandRepository.AddZone(zone, cancellationToken);

        var rand = new Random();

        var lightingStatus = new LightingStatus
        {
            Zone = zone,
            Amount = rand.Next(0, 100),
            LightingStatusType = LightingStatusType.normal
        };

        await _lightingStatusCommandRepository.AddLightingStatus(lightingStatus, cancellationToken);

        return ResultDto<ZoneResponseDto>.Success(new ZoneResponseDto(zone));
    }
}
