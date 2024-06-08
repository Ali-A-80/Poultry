using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.HealthStatuses.Dtos;
using Poultry.Application.Services.HealthStatuses.Queries;
using Poultry.Persistance.Repositories.HealthStatuses;

namespace Poultry.Application.Services.HealthStatuses.Handlers;

public class ListHealthStatusHandler : IRequestHandler<HealthStatusListQuery, ResultDto<List<HealthStatusResponseDto>>>
{

    private readonly IHealthStatusQueryRepository _healthStatusQueryRepository;

    public ListHealthStatusHandler(IHealthStatusQueryRepository healthStatusQueryRepository)
    {
        _healthStatusQueryRepository = healthStatusQueryRepository;
    }
    public async Task<ResultDto<List<HealthStatusResponseDto>>> Handle(HealthStatusListQuery request, CancellationToken cancellationToken)
    {
        var query = _healthStatusQueryRepository.GetAll();

        var result = await query.Select(x => new HealthStatusResponseDto(x)).ToListAsync(cancellationToken);

        return ResultDto<List<HealthStatusResponseDto>>.Success(result);
    }

}
