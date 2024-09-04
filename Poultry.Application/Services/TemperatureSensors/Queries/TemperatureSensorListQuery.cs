using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.TemperatureSensors.Dtos;

namespace Poultry.Application.Services.TemperatureSensors.Queries;


public class TemperatureSensorListQuery : IRequest<ResultDto<List<TemperatureSensorResponseDto>>>
{

}

