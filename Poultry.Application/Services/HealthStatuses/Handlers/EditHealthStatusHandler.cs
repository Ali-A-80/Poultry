using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.HealthStatuses.Commands;
using Poultry.Application.Services.HealthStatuses.Dtos;
using Poultry.Domain.Repositories.HealthStatuses;

namespace Poultry.Application.Services.HealthStatuses.Handlers;

public class EditHealthStatusHandler : IRequestHandler<HealthStatusEditCommand, ResultDto<HealthStatusResponseDto>>
{

    private readonly IHealthStatusCommandRepository _healthStatusCommandRepository;

    public EditHealthStatusHandler(IHealthStatusCommandRepository healthStatusCommandRepository)
    {
        _healthStatusCommandRepository = healthStatusCommandRepository;
    }

    public async Task<ResultDto<HealthStatusResponseDto>> Handle(HealthStatusEditCommand request, CancellationToken cancellationToken)
    {

        var healthStatus = await _healthStatusCommandRepository.GetById(request.Id, cancellationToken);

        healthStatus.BodyTemprature = request.BodyTemprature;
        healthStatus.CheckupDate = request.CheckupDate;
        healthStatus.HealthLevel = request.HealthLevel;
        healthStatus.UpdateTime = DateTime.Now;

        await _healthStatusCommandRepository.UpdateHealthStatus(healthStatus, cancellationToken);

        return ResultDto<HealthStatusResponseDto>.Success(new HealthStatusResponseDto(healthStatus));
    }

}
