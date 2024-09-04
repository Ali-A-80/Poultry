using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.TemperatureSensors.Commands;
using Poultry.Domain.Repositories.TemperatureSensors;

namespace Poultry.Application.Services.TemperatureSensors.Handlers;

public class DeleteTemperatureSensorHandler : IRequestHandler<TemperatureSensorDeleteCommand, ResultDto<Unit>>
{
    private readonly ITemperatureSensorCommandRepository _temperatureSensorCommandRepository;

    public DeleteTemperatureSensorHandler(ITemperatureSensorCommandRepository temperatureSensorCommandRepository)
    {
        _temperatureSensorCommandRepository = temperatureSensorCommandRepository;
    }
    public async Task<ResultDto<Unit>> Handle(TemperatureSensorDeleteCommand request, CancellationToken cancellationToken)
    {
        var temperatureSensor = await _temperatureSensorCommandRepository.GetById(request.Id, cancellationToken);

        temperatureSensor.IsRemoved = true;
        temperatureSensor.RemoveTime = DateTime.Now;

        await _temperatureSensorCommandRepository.UpdateTemperatureSensor(temperatureSensor, cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }

}
