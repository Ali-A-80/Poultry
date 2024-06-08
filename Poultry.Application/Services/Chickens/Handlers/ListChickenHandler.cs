using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.Chickens.Dtos;
using Poultry.Application.Services.Chickens.Queries;
using Poultry.Persistance.Repositories.Chickens;

namespace Poultry.Application.Services.Chickens.Handlers;

public class ListChickenHandler : IRequestHandler<ChickenListQuery, ResultDto<List<ChickenResponseDto>>>
{

    private readonly IChickenQueryRepository _chickenQueryRepository;

    public ListChickenHandler(IChickenQueryRepository chickenQueryRepository)
    {
        _chickenQueryRepository = chickenQueryRepository;
    }

    public async Task<ResultDto<List<ChickenResponseDto>>> Handle(ChickenListQuery request, CancellationToken cancellationToken)
    {
        var query = _chickenQueryRepository.GetAll(cancellationToken);

        var result = await query.Select(x => new ChickenResponseDto(x)).ToListAsync(cancellationToken);

        return ResultDto<List<ChickenResponseDto>>.Success(result);
    }

}
