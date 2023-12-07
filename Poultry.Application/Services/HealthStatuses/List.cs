using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.HealthStatuses
{
    public class List
    {
        public class Query : IRequest<ResultDto<List<HealthStatusResponseDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, ResultDto<List<HealthStatusResponseDto>>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<List<HealthStatusResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await _context.HealthStatuses.AsNoTracking()
                        .Select(x => new HealthStatusResponseDto(x))
                        .ToListAsync(cancellationToken);

                return ResultDto<List<HealthStatusResponseDto>>.Success(query);
            }
        }
    }
}
