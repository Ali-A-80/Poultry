using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.HumiditySensors.Dtos;
using Poultry.Application.Services.HumiditySensors.Queries;
using Poultry.Domain.Repositories.HumiditySensors;

namespace Poultry.Application.Services.HumiditySensors.Handlers;

public class ListHumiditySensorHandler : IRequestHandler<HumiditySensorListQuery, ResultDto<List<HumiditySensorResponseDto>>>
{
    private readonly IHumiditySensorQueryRepository _humiditySensorQueryRepository;

    public ListHumiditySensorHandler(IHumiditySensorQueryRepository humiditySensorQueryRepository)
    {
        _humiditySensorQueryRepository = humiditySensorQueryRepository;
    }

    public async Task<ResultDto<List<HumiditySensorResponseDto>>> Handle(HumiditySensorListQuery request, CancellationToken cancellationToken)
    {
        var query = _humiditySensorQueryRepository.GetAll();

        var result = await query.Select(x => new HumiditySensorResponseDto(x)).ToListAsync(cancellationToken);

        return ResultDto<List<HumiditySensorResponseDto>>.Success(result);
    }

}
