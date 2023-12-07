using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.FoodServices
{
    public class List
    {
        public class Query : IRequest<ResultDto<List<FoodServiceResponseDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, ResultDto<List<FoodServiceResponseDto>>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<List<FoodServiceResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await _context.FoodServices.AsNoTracking()
                    .Select(x => new FoodServiceResponseDto(x)).ToListAsync(cancellationToken);

                return ResultDto<List<FoodServiceResponseDto>>.Success(query);
            }
        }
    }
}
