using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.HumiditySensors.Commands;
using Poultry.Application.Services.HumiditySensors.Dtos;
using Poultry.Persistance.Repositories.HumiditySensors;

namespace Poultry.Application.Services.HumiditySensors.Handlers;

public class EditHumiditySensorHandler : IRequestHandler<HumiditySensorEditCommand, ResultDto<HumiditySensorResponseDto>>
{

    private readonly IHumiditySensorCommandRepository _humiditySensorCommandRepository;

    public EditHumiditySensorHandler(IHumiditySensorCommandRepository humiditySensorCommandRepository)
    {
        _humiditySensorCommandRepository = humiditySensorCommandRepository;
    }

    public async Task<ResultDto<HumiditySensorResponseDto>> Handle(HumiditySensorEditCommand request, CancellationToken cancellationToken)
    {
        var humiditySensor = await _humiditySensorCommandRepository.GetById(request.Id, cancellationToken);

        humiditySensor.Amount = humiditySensor.Amount;
        humiditySensor.HumidityStatus = humiditySensor.HumidityStatus;
        humiditySensor.UpdateTime = DateTime.Now;

        await _humiditySensorCommandRepository.UpdateHumiditySensor(humiditySensor, cancellationToken);

        return ResultDto<HumiditySensorResponseDto>.Success(new HumiditySensorResponseDto(humiditySensor));
    }

}
