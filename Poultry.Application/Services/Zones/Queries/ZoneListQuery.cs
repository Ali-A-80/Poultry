using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Zones.Dtos;

namespace Poultry.Application.Services.Zones.Queries;


public class ZoneListQuery : IRequest<ResultDto<List<ZoneResponseDto>>>
{

}

