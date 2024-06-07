using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.FoodServices.Dtos;
using Poultry.Application.Services.FoodServices.Queries;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.FoodServices.Handlers;

public class ListFoodServiceHandler : IRequestHandler<FoodServiceListQuery, ResultDto<List<FoodServiceResponseDto>>>
{
    private readonly DatabaseContext _context;

    public ListFoodServiceHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<List<FoodServiceResponseDto>>> Handle(FoodServiceListQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.FoodServices.AsNoTracking()
            .Select(x => new FoodServiceResponseDto(x)).ToListAsync(cancellationToken);

        return ResultDto<List<FoodServiceResponseDto>>.Success(query);
    }

}
