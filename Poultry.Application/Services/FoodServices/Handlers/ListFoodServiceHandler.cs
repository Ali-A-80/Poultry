using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.FoodServices.Dtos;
using Poultry.Application.Services.FoodServices.Queries;
using Poultry.Domain.Repositories.FoodServices;

namespace Poultry.Application.Services.FoodServices.Handlers;

public class ListFoodServiceHandler : IRequestHandler<FoodServiceListQuery, ResultDto<List<FoodServiceResponseDto>>>
{
    private readonly IFoodServiceQueryRepository _foodServiceQueryRepository;

    public ListFoodServiceHandler(IFoodServiceQueryRepository foodServiceQueryRepository)
    {
        _foodServiceQueryRepository = foodServiceQueryRepository;
    }

    public async Task<ResultDto<List<FoodServiceResponseDto>>> Handle(FoodServiceListQuery request, CancellationToken cancellationToken)
    {
        var query = _foodServiceQueryRepository.GetAll();

        var result = await query.Select(x => new FoodServiceResponseDto(x)).ToListAsync(cancellationToken);

        return ResultDto<List<FoodServiceResponseDto>>.Success(result);
    }

}
