using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.HumiditySensors.Dtos;

namespace Poultry.Application.Services.HumiditySensors.Queries;

public class HumiditySensorListQuery : IRequest<ResultDto<List<HumiditySensorResponseDto>>>
{

}

