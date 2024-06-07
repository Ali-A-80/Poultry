using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.Zones.Dtos;
using Poultry.Application.Services.Zones.Queries;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.Zones.Handlers;

public class List
{

    public class Handler : IRequestHandler<ZoneListQuery, ResultDto<List<ZoneResponseDto>>>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<ZoneResponseDto>>> Handle(ZoneListQuery request, CancellationToken cancellationToken)
        {

            var query = await _context.Zones
                .Include(x => x.LightingStatus)
                .Include(x => x.TemperatureSensors)
                .Include(x => x.HumiditySensors)
                .Include(x => x.VentilationSensors)
                .AsNoTracking()
                .Select(x => new ZoneResponseDto(x))
                .ToListAsync(cancellationToken);

            return ResultDto<List<ZoneResponseDto>>.Success(query);
        }
    }
}
