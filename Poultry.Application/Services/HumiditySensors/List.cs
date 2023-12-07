using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.HumiditySensors
{
    public class List
    {
        public class Query : IRequest<ResultDto<List<HumiditySensorResponseDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, ResultDto<List<HumiditySensorResponseDto>>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<List<HumiditySensorResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await _context.HumiditySensors.AsNoTracking()
                    .Select(x => new HumiditySensorResponseDto(x))
                    .ToListAsync(cancellationToken);

                return ResultDto<List<HumiditySensorResponseDto>>.Success(query);
            }
        }
    }
}
