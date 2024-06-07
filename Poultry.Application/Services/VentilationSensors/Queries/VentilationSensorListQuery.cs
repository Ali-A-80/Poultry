using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.VentilationSensors.Dtos;

namespace Poultry.Application.Services.VentilationSensors.Queries;


public class VentilationSensorListQuery : IRequest<ResultDto<List<VentilationSensorResponseDto>>>
{

}

