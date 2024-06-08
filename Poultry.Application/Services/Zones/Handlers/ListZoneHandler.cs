using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.Zones.Dtos;
using Poultry.Application.Services.Zones.Queries;
using Poultry.Persistance.Repositories.Zones;

namespace Poultry.Application.Services.Zones.Handlers;

public class ListZoneHandler : IRequestHandler<ZoneListQuery, ResultDto<List<ZoneResponseDto>>>
{
    private readonly IZoneQueryRepository _zoneQueryRepository;

    public ListZoneHandler(IZoneQueryRepository zoneQueryRepository)
    {
        _zoneQueryRepository = zoneQueryRepository;
    }

    public async Task<ResultDto<List<ZoneResponseDto>>> Handle(ZoneListQuery request, CancellationToken cancellationToken)
    {

        var query = _zoneQueryRepository.GetAll();

        var result = await query.Select(x => new ZoneResponseDto(x)).ToListAsync(cancellationToken);

        return ResultDto<List<ZoneResponseDto>>.Success(result);
    }
}
