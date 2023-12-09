using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.Zones
{
    public class List
    {
        public class Query : IRequest<ResultDto<List<ZoneResponseDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, ResultDto<List<ZoneResponseDto>>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<List<ZoneResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
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
}
