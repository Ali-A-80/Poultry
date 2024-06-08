using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Zones.Commands;
using Poultry.Application.Services.Zones.Dtos;
using Poultry.Persistance.Repositories.Zones;

namespace Poultry.Application.Services.Zones.Handlers;

public class EditZoneHandler : IRequestHandler<ZoneEditCommand, ResultDto<ZoneResponseDto>>
{
    private readonly IZoneCommandRepository _zoneCommandRepository;

    public EditZoneHandler(IZoneCommandRepository zoneCommandRepository)
    {
        _zoneCommandRepository = zoneCommandRepository;
    }

    public async Task<ResultDto<ZoneResponseDto>> Handle(ZoneEditCommand request, CancellationToken cancellationToken)
    {
        var zone = await _zoneCommandRepository.GetById(request.Id, cancellationToken);

        zone.ZoneType = request.ZoneType;
        zone.UpdateTime = DateTime.Now;

        await _zoneCommandRepository.UpdateZone(zone, cancellationToken);

        return ResultDto<ZoneResponseDto>.Success(new ZoneResponseDto(zone));
    }
}
