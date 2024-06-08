using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Zones.Commands;
using Poultry.Persistance.Repositories.Zones;

namespace Poultry.Application.Services.Zones.Handlers;

public class DeleteZoneHandler : IRequestHandler<ZoneDeleteCommand, ResultDto<Unit>>
{
    private readonly IZoneCommandRepository _zoneCommandRepository;

    public DeleteZoneHandler(IZoneCommandRepository zoneCommandRepository)
    {
        _zoneCommandRepository = zoneCommandRepository;
    }
    public async Task<ResultDto<Unit>> Handle(ZoneDeleteCommand request, CancellationToken cancellationToken)
    {
        var zone = await _zoneCommandRepository.GetById(request.Id, cancellationToken);

        zone.IsRemoved = true;
        zone.RemoveTime = DateTime.Now;

        await _zoneCommandRepository.UpdateZone(zone, cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }
}
