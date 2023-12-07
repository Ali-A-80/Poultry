using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.LightingStatuses
{
    public class List
    {
        public class Query : IRequest<ResultDto<List<LightingStatusResponseDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, ResultDto<List<LightingStatusResponseDto>>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<List<LightingStatusResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await _context.LightingStatuses.AsNoTracking()
                    .Select(x => new LightingStatusResponseDto(x))
                    .ToListAsync(cancellationToken);

                return ResultDto<List<LightingStatusResponseDto>>.Success(query);
            }
        }
    }
}
