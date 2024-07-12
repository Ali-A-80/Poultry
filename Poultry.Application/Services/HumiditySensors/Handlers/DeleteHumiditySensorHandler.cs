using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.HumiditySensors.Commands;
using Poultry.Domain.Repositories.HumiditySensors;

namespace Poultry.Application.Services.HumiditySensors.Handlers;

public class DeleteHumiditySensorHandler : IRequestHandler<HumiditySensorDeleteCommand, ResultDto<Unit>>
{
    private readonly IHumiditySensorCommandRepository _humiditySensorCommandRepository;

    public DeleteHumiditySensorHandler(IHumiditySensorCommandRepository humiditySensorCommandRepository)
    {
        _humiditySensorCommandRepository = humiditySensorCommandRepository;
    }

    public async Task<ResultDto<Unit>> Handle(HumiditySensorDeleteCommand request, CancellationToken cancellationToken)
    {
        var humiditySensor = await _humiditySensorCommandRepository.GetById(request.Id, cancellationToken);

        humiditySensor.IsRemoved = true;
        humiditySensor.RemoveTime = DateTime.Now;

        await _humiditySensorCommandRepository.UpdateHumiditySensor(humiditySensor, cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }

}
