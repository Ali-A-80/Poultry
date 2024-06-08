using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.HealthStatuses.Commands;
using Poultry.Persistance.Repositories.HealthStatuses;

namespace Poultry.Application.Services.HealthStatuses.Handlers;

public class DeleteHealthStatusHandler : IRequestHandler<HealthStatusDeleteCommand, ResultDto<Unit>>
{

    private readonly IHealthStatusCommandRepository _healthStatusCommandRepository;

    public DeleteHealthStatusHandler(IHealthStatusCommandRepository healthStatusCommandRepository)
    {
        _healthStatusCommandRepository = healthStatusCommandRepository;
    }

    public async Task<ResultDto<Unit>> Handle(HealthStatusDeleteCommand request, CancellationToken cancellationToken)
    {
        var healthStatus = await _healthStatusCommandRepository.GetById(request.Id, cancellationToken);

        healthStatus.IsRemoved = true;
        healthStatus.RemoveTime = DateTime.Now;

        await _healthStatusCommandRepository.UpdateHealthStatus(healthStatus, cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }

}
