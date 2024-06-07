using MediatR;
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
        var query = _chickenQueryRepository.GetChickenList(cancellationToken);

        var result = query.Select(x => new ChickenResponseDto(x)).ToList();

        return ResultDto<List<ChickenResponseDto>>.Success(result);
    }

}
