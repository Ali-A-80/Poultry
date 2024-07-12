using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.TemperatureSensors.Dtos;
using Poultry.Application.Services.TemperatureSensors.Queries;
using Poultry.Domain.Repositories.TemperatureSensors;

namespace Poultry.Application.Services.TemperatureSensors.Handlers;

public class ListTemperatureSensorHandler : IRequestHandler<TemperatureSensorListQuery, ResultDto<List<TemperatureSensorResponseDto>>>
{

    private readonly ITemperatureSensorQueryRepository _temperatureSensorQueryRepository;

    public ListTemperatureSensorHandler(ITemperatureSensorQueryRepository temperatureSensorQueryRepository)
    {
        _temperatureSensorQueryRepository = temperatureSensorQueryRepository;
    }

    public async Task<ResultDto<List<TemperatureSensorResponseDto>>> Handle(TemperatureSensorListQuery request, CancellationToken cancellationToken)
    {
        var query = _temperatureSensorQueryRepository.GetAll();

        var result = await query.Select(x => new TemperatureSensorResponseDto(x))
            .ToListAsync(cancellationToken);

        return ResultDto<List<TemperatureSensorResponseDto>>.Success(result);
    }

}
