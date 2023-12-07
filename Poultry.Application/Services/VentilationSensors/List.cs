using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.VentilationSensors
{
    public class List
    {
        public class Query : IRequest<ResultDto<List<VentilationSensorResponseDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, ResultDto<List<VentilationSensorResponseDto>>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<List<VentilationSensorResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await _context.VentilationSensors.AsNoTracking()
                    .Select(x => new VentilationSensorResponseDto(x))
                    .ToListAsync(cancellationToken);

                return ResultDto<List<VentilationSensorResponseDto>>.Success(query);
            }
        }
    }
}
