using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.TemperatureSensors.Commands;
using Poultry.Application.Services.TemperatureSensors.Dtos;
using Poultry.Domain.Repositories.TemperatureSensors;

namespace Poultry.Application.Services.TemperatureSensors.Handlers;

public class EditTemperatureSensorHandler : IRequestHandler<TemperatureSensorEditCommand, ResultDto<TemperatureSensorResponseDto>>
{

    private readonly ITemperatureSensorCommandRepository _temperatureSensorCommandRepository;

    public EditTemperatureSensorHandler(ITemperatureSensorCommandRepository temperatureSensorCommandRepository)
    {
        _temperatureSensorCommandRepository = temperatureSensorCommandRepository;
    }

    public async Task<ResultDto<TemperatureSensorResponseDto>> Handle(TemperatureSensorEditCommand request, CancellationToken cancellationToken)
    {
        var temperatureSensor = await _temperatureSensorCommandRepository.GetById(request.Id, cancellationToken);

        temperatureSensor.Amount = request.Amount;
        temperatureSensor.TemperatureStatus = request.TemperatureStatus;
        temperatureSensor.UpdateTime = DateTime.Now;

        await _temperatureSensorCommandRepository.UpdateTemperatureSensor(temperatureSensor, cancellationToken);

        return ResultDto<TemperatureSensorResponseDto>.Success(new TemperatureSensorResponseDto(temperatureSensor));
    }

}
