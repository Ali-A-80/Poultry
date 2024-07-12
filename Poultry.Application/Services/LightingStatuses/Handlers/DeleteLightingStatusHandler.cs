using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.LightingStatuses.Commands;
using Poultry.Domain.Repositories.LightingStatuses;

namespace Poultry.Application.Services.LightingStatuses.Handlers;

public class DeleteLightingStatusHandler : IRequestHandler<LightingStatusDeleteCommand, ResultDto<Unit>>
{

    private readonly ILightingStatusCommandRepository _lightingStatusCommandRepository;

    public DeleteLightingStatusHandler(ILightingStatusCommandRepository lightingStatusCommandRepository)
    {
        _lightingStatusCommandRepository = lightingStatusCommandRepository;
    }

    public async Task<ResultDto<Unit>> Handle(LightingStatusDeleteCommand request, CancellationToken cancellationToken)
    {
        var lightingStatus = await _lightingStatusCommandRepository.GetById(request.Id, cancellationToken);

        lightingStatus.IsRemoved = true;
        lightingStatus.RemoveTime = DateTime.Now;

        await _lightingStatusCommandRepository.UpdateLightingStatus(lightingStatus, cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }

}
