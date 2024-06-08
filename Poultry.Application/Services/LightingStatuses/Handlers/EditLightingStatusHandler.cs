using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.LightingStatuses.Commands;
using Poultry.Application.Services.LightingStatuses.Dtos;
using Poultry.Persistance.Repositories.LightingStatuses;

namespace Poultry.Application.Services.LightingStatuses.Handlers;

public class EditLightingStatusHandler : IRequestHandler<LightingStatusEditCommand, ResultDto<LightingStatusResponseDto>>
{

    private readonly ILightingStatusCommandRepository _lightingStatusCommandRepository;

    public EditLightingStatusHandler(ILightingStatusCommandRepository lightingStatusCommandRepository)
    {
        _lightingStatusCommandRepository = lightingStatusCommandRepository;
    }
    public async Task<ResultDto<LightingStatusResponseDto>> Handle(LightingStatusEditCommand request, CancellationToken cancellationToken)
    {
        var lightingStatus = await _lightingStatusCommandRepository.GetById(request.Id, cancellationToken);

        lightingStatus.Amount = lightingStatus.Amount;
        lightingStatus.LightingStatusType = lightingStatus.LightingStatusType;
        lightingStatus.UpdateTime = DateTime.Now;

        await _lightingStatusCommandRepository.UpdateLightingStatus(lightingStatus, cancellationToken);

        return ResultDto<LightingStatusResponseDto>.Success(new LightingStatusResponseDto(lightingStatus));
    }

}
