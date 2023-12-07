using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.TemperatureSensors
{
    public class List
    {
        public class Query : IRequest<ResultDto<List<TemperatureSensorResponseDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, ResultDto<List<TemperatureSensorResponseDto>>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<List<TemperatureSensorResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await _context.TemperatureSensors.AsNoTracking()
                    .Select(x => new TemperatureSensorResponseDto(x))
                    .ToListAsync(cancellationToken);

                return ResultDto<List<TemperatureSensorResponseDto>>.Success(query);
            }
        }
    }
}
