using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.Chickens
{
    public class List
    {
        public class Query : IRequest<ResultDto<List<ChickenResponseDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, ResultDto<List<ChickenResponseDto>>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }

            public async Task<ResultDto<List<ChickenResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await _context.Chickens.AsNoTracking()
                    .Include(x => x.HealthStatus)
                    .Select(x => new ChickenResponseDto(x)).ToListAsync(cancellationToken);

                return ResultDto<List<ChickenResponseDto>>.Success(query);
            }
        }
    }
}
