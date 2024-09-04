using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.LightingStatuses.Dtos;
using Poultry.Application.Services.LightingStatuses.Queries;
using Poultry.Domain.Repositories.LightingStatuses;

namespace Poultry.Application.Services.LightingStatuses.Handlers;

public class ListLightingStatusHandler : IRequestHandler<LightingStatusListQuery, ResultDto<List<LightingStatusResponseDto>>>
{
    private readonly ILightingStatusQueryRepository _lightingStatusQueryRepository;

    public ListLightingStatusHandler(ILightingStatusQueryRepository lightingStatusQueryRepository)
    {
        _lightingStatusQueryRepository = lightingStatusQueryRepository;
    }

    public async Task<ResultDto<List<LightingStatusResponseDto>>> Handle(LightingStatusListQuery request, CancellationToken cancellationToken)
    {
        var query = _lightingStatusQueryRepository.GetAll();

        var result = await query.Select(x => new LightingStatusResponseDto(x)).ToListAsync(cancellationToken);

        return ResultDto<List<LightingStatusResponseDto>>.Success(result);
    }

}
